import {Component} from '@angular/core';
import {Observable} from "rxjs";
import {Section} from "../../../models/section.model";
import {SectionService} from "../../../services/section.service";
import {ActivatedRoute} from "@angular/router";
import {CdkDragDrop, moveItemInArray, transferArrayItem} from "@angular/cdk/drag-drop";
import {MenuService} from "../../../services/menu.service";
import {Menu} from "../../../models/menu.model";

@Component({
  selector: 'app-menu-detail',
  templateUrl: './menu-detail.component.html',
  styleUrls: ['./menu-detail.component.scss']
})
export class MenuDetailComponent {
  sections$: Observable<Array<Section>> = this.sectionService.all();
  menu$: Observable<Menu> = this.menuService.get(this.activatedRoute.snapshot.params['id']);

  constructor(private sectionService: SectionService,
              private menuService: MenuService,
              private activatedRoute: ActivatedRoute) {
  }

  drop(event: CdkDragDrop<number[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
  }
}
