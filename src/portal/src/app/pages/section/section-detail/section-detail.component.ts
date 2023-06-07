import {Component} from '@angular/core';
import {SectionService} from "../../../services/section.service";
import {ProductService} from "../../../services/product.service";
import {Section} from "../../../models/section.model";
import {Product} from "../../../models/product.model";
import {ActivatedRoute, Router} from "@angular/router";
import {CdkDragDrop, copyArrayItem, moveItemInArray} from "@angular/cdk/drag-drop";
import {LoadingService} from "../../../services/loading.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-section-detail',
  templateUrl: './section-detail.component.html',
  styleUrls: ['./section-detail.component.scss']
})
export class SectionDetailComponent {
  section: Section;
  products: Array<Product>;
  sectionId: number;
  isReadOnly: boolean = false;
  isAdd: boolean = false;

  constructor(private sectionService: SectionService,
              private productService: ProductService,
              private activatedRoute: ActivatedRoute,
              private loadingService: LoadingService,
              private snackBar: MatSnackBar) {
    this.isReadOnly =
      this.activatedRoute.snapshot.url[0].path === 'view';
    this.isAdd =
      this.activatedRoute.snapshot.url[0].path === 'add';

    this.loadingService.show();
    this.sectionId = this.activatedRoute.snapshot.params['id'];
    this.sectionService.get(this.sectionId).subscribe({
      next: (section) => this.section = section,
    })

    this.productService.all().subscribe({
      next: (products) => this.products = products,
    })
    this.loadingService.hide();
  }

  drop(event: CdkDragDrop<any>, section: Section) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const productId = event.previousContainer.data[event.previousIndex].productId;
      this.sectionService.addProductToSection(section.sectionId!, productId).subscribe({
        next: () => {
          // this.router.navigate(['section', 'edit', section.sectionId]);
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

  exit(product: Product) {
    const productId = product.productId ?? 0;
    this.sectionService.deleteProductFromSection(this.sectionId, productId).subscribe({
      next: () => {
        this.sectionService.get(this.sectionId).subscribe({
          next: (section) => this.section = section,
        });

        this.snackBar.open('Eliminado exitosamente', 'aceptar', {
          duration: 2000,
        })
      },
    })
  }
}
