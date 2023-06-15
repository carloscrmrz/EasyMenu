import {Component} from '@angular/core';
import {SectionService} from "../../../services/section.service";
import {ProductService} from "../../../services/product.service";
import {Section} from "../../../models/section.model";
import {Product} from "../../../models/product.model";
import {ActivatedRoute, Router} from "@angular/router";
import {CdkDragDrop, copyArrayItem, moveItemInArray, transferArrayItem} from "@angular/cdk/drag-drop";
import {LoadingService} from "../../../services/loading.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {UntypedFormBuilder, UntypedFormGroup, Validators} from "@angular/forms";
import {finalize, forkJoin, Observable, ObservableInput, Subscription} from "rxjs";
import {SubscriptSizing} from "@angular/material/form-field";

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
  addProducts: Product[] = [];
  completeCatalogs: boolean = false;

  sectionData: UntypedFormGroup = this.fb.group({
    sectionId: [0],
    tenantId: [1],
    sectionName: ['', Validators.required],
    imageUrl: [''],
    status: [0, Validators.required]
  });

  constructor(private sectionService: SectionService,
              private productService: ProductService,
              private activatedRoute: ActivatedRoute,
              private loadingService: LoadingService,
              private snackBar: MatSnackBar,
              private fb: UntypedFormBuilder,
              private router: Router) {
    this.isReadOnly =
      this.activatedRoute.snapshot.url[0].path === 'view';
    this.isAdd =
      this.activatedRoute.snapshot.url[0].path === 'add';

    if (this.isReadOnly) {
      this.sectionData.disable()
    }

    this.loadingService.show();
    this.sectionId = this.activatedRoute.snapshot.params['id'];
    if (this.sectionId) {
      this.sectionService.get(this.sectionId).subscribe({
        next: (section) => this.setFormData(section),
      });
    } else {
      this.section = new Section({});
    }
    this.productService.all().subscribe({
      next: (products) => {
        this.products = products;
        this.completeCatalogs = true;
      }
    })
    this.loadingService.hide();
  }

  drop(event: CdkDragDrop<any>, section: Section) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const productId = event.previousContainer.data[event.previousIndex].productId;
      if (!this.isAdd) {
        console.log('here')
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
        });

        copyArrayItem(
          event.previousContainer.data,
          event.container.data,
          event.previousIndex,
          event.currentIndex,
        );

      } else {
        const product = this.products.find(p => p.productId == productId)!;
        this.addProducts.push(product);

        transferArrayItem(
          event.previousContainer.data,
          event.container.data,
          event.previousIndex,
          event.currentIndex,
        );
      }

    }
  }

  get invalid(): boolean {
    return this.sectionData.invalid;
  }

  setFormData(section: Section) {
    if (section) {
      this.section = new Section(section);
      this.sectionData.patchValue(section);
    }
    this.sectionData.updateValueAndValidity();
  }

  save() {
    this.loadingService.show();

    const rawProduct = this.sectionData.getRawValue();
    this.setFormData(rawProduct);

    const sectionObservable: Observable<any> = this.isAdd
      ? this.sectionService.create(this.section)
      : this.sectionService.update(this.section);

    sectionObservable.pipe(
      finalize(() => this.loadingService.hide())
    ).subscribe(
      {
        next: (section: Section) => {
          this.snackBar.open('Guardado exitosamente', 'aceptar', {
            duration: 2000,
          });
          this.sectionId = section.sectionId!;

          const productSubscriptions: Observable<boolean>[] = [];
          if (this.addProducts.length > 0) {
            this.addProducts.forEach(p => {
              productSubscriptions.push(
                this.sectionService.addProductToSection(this.sectionId, p.productId!)
              )
            });
          }

          forkJoin({...productSubscriptions})
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
    this.router.navigate(['section']);
  }

  exit(product: Product) {
    if (this.isReadOnly) return;

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
