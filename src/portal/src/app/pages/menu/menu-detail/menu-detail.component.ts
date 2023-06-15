import {Component, OnInit} from '@angular/core';
import {Section} from "../../../models/section.model";
import {SectionService} from "../../../services/section.service";
import {ActivatedRoute, Router} from "@angular/router";
import {CdkDragDrop, copyArrayItem, moveItemInArray} from "@angular/cdk/drag-drop";
import {MenuService} from "../../../services/menu.service";
import {Menu} from "../../../models/menu.model";
import {MatSnackBar} from "@angular/material/snack-bar";
import {UntypedFormBuilder, UntypedFormGroup, Validators} from "@angular/forms";
import {finalize, forkJoin, Observable} from "rxjs";
import {LoadingService} from "../../../services/loading.service";

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
  addSections: Section[] = [];

  menuData: UntypedFormGroup = this.fb.group({
    menuId: [0],
    tenantId: [1],
    status: [0, Validators.required]
  });

  constructor(private sectionService: SectionService,
              private activatedRoute: ActivatedRoute,
              private loadingService: LoadingService,
              private menuService: MenuService,
              private fb: UntypedFormBuilder,
              private snackBar: MatSnackBar,
              private router: Router) {}

  ngOnInit(): void {
    this.isReadOnly =
      this.activatedRoute.snapshot.url[0].path === 'view';
    this.isAdd =
      this.activatedRoute.snapshot.url[0].path === 'add';

    if (this.isReadOnly) {
      this.menuData.disable()
    }

    this.menuId = this.activatedRoute.snapshot.params['id'];

    this.sectionService.all().subscribe({
      next: (sections) => this.sections = sections,
      error: () => this.sections = [],
    });

    this.menuService.get(this.menuId).subscribe({
      next: (menu: Menu) => this.setFormData(menu),
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

  setFormData(menu: Menu) {
    if (menu) {
      this.menu = new Menu(menu);
      this.menuData.patchValue(menu);
    }
    this.menuData.updateValueAndValidity();
  }

  save() {
    this.loadingService.show();

    const rawMenu = this.menuData.getRawValue();
    this.setFormData(rawMenu);

    const menuObservable: Observable<any> = this.isAdd
      ? this.menuService.create(this.menu)
      : this.menuService.update(this.menu);

    menuObservable.pipe(
      finalize(() => this.loadingService.hide())
    ).subscribe(
      {
        next: (menu: Menu) => {
          this.snackBar.open('Guardado exitosamente', 'aceptar', {
            duration: 2000,
          });
          this.menuId = menu.menuId!;

          const sectionSubscription$: Observable<boolean>[] = [];
          if (this.addSections.length > 0) {
            this.addSections.forEach(s => {
              sectionSubscription$.push(
                this.menuService.addSectionToMenu(this.menuId, s.sectionId!)
              )
            });
          }

          forkJoin({...sectionSubscription$})
            .subscribe({
              next: () => this.router.navigate(['section'])
            });
        },
        error: () => {
          this.snackBar.open('Ocurrió un error', 'aceptar', {
            duration: 2000,
          });
        }
      });


  }

  back() {
    this.router.navigate(['menu']);
  }

}
