import { Component } from '@angular/core';
import {SectionService} from "../../../services/section.service";
import {ProductService} from "../../../services/product.service";
import {Observable} from "rxjs";
import {Section} from "../../../models/section.model";
import {Product} from "../../../models/product.model";
import {ActivatedRoute} from "@angular/router";
import {CdkDragDrop, moveItemInArray, transferArrayItem} from "@angular/cdk/drag-drop";

@Component({
  selector: 'app-section-detail',
  templateUrl: './section-detail.component.html',
  styleUrls: ['./section-detail.component.scss']
})
export class SectionDetailComponent {
  sections$: Observable<Section> = this.sectionService.get(this.activatedRoute.snapshot.params['id']);
  products$: Observable<Array<Product>> = this.productService.all();
  constructor(private sectionService: SectionService,
              private productService: ProductService,
              private activatedRoute: ActivatedRoute) {}

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
