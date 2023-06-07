import {Component, OnInit} from '@angular/core';
import {Section} from "../../../models/section.model";
import {SectionService} from "../../../services/section.service";
import {ActivatedRoute} from "@angular/router";
import {CdkDragDrop, copyArrayItem, moveItemInArray} from "@angular/cdk/drag-drop";
import {MenuService} from "../../../services/menu.service";
import {Menu} from "../../../models/menu.model";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-menu-detail',
  templateUrl: './menu-detail.component.html',
  styleUrls: ['./menu-detail.component.scss']
})
export class MenuDetailComponent implements OnInit {
  sections: Array<Section>;
  menu: Menu;
  menuId: number;
  isReadOnly: boolean = false;
  isAdd: boolean = false;

  constructor(private sectionService: SectionService,
              private menuService: MenuService,
              private activatedRoute: ActivatedRoute,
              private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.isReadOnly =
      this.activatedRoute.snapshot.url[0].path === 'view';
    this.isAdd =
      this.activatedRoute.snapshot.url[0].path === 'add';

    this.menuId = this.activatedRoute.snapshot.params['id'];

    this.sectionService.all().subscribe({
      next: (sections) => this.sections = sections,
      error: () => this.sections = [],
    });

    this.menuService.get(this.menuId).subscribe({
      next: (menu: Menu) => this.menu = menu,
      error: () => this.menu = new Menu(),
    })
  }

  drop(event: CdkDragDrop<any>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const sectionId = event.previousContainer.data[event.previousIndex].sectionId;
      this.menuService.addSectionToMenu(this.menuId, sectionId).subscribe({
        next: () => {
          this.snackBar.open('Guardado exitosamente', 'aceptar', {
            duration: 2000,
          });
        },
        error: () => {
          event.container.data.splice(event.currentIndex, 1);
          this.snackBar.open('Ocurrió un error', 'aceptar', {
            duration: 2000,
          });
        }
      })

      copyArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
  }

  exit(section: Section) {
    const sectionId = section.sectionId ?? 0;
    this.menuService.deleteSectionFromMenu(this.menu.menuId, sectionId).subscribe({
      next: () => {
        this.menuService.get(this.menuId).subscribe({
          next: (menu: Menu) => this.menu = menu,
        })
        this.snackBar.open('Eliminado exitosamente', 'aceptar', {
          duration: 2000,
        })
      },
    })
  }
}
