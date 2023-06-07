import {Component, OnInit} from '@angular/core';
import {ProductService} from "../../../services/product.service";
import {Product} from "../../../models/product.model";
import {UntypedFormBuilder, UntypedFormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {finalize, Observable} from "rxjs";
import {LoadingService} from "../../../services/loading.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  isReadOnly: boolean = false;
  isAdd: boolean = false;

  product$: Product;
  productData: UntypedFormGroup = this.fb.group({
    productId: [0],
    tenantId: [1],
    productName: ['', Validators.required],
    description: [''],
    price: [0, Validators.required],
    position: [0],
    status: [0, Validators.required]
    });
  constructor(private productService: ProductService,
              private fb: UntypedFormBuilder,
              private activatedRoute: ActivatedRoute,
              private loadingService: LoadingService,
              private snackBar: MatSnackBar,
              private router: Router) {}

  ngOnInit(): void {
    this.isReadOnly =
      this.activatedRoute.snapshot.url[0].path === 'view';
    this.isAdd =
      this.activatedRoute.snapshot.url[0].path === 'add';

    if (this.isAdd) {
      const newProduct = new Product();
      this.setFormData(newProduct);
      this.productData.get('productId')?.disable();

      return;
    }

    this.productService.get(this.activatedRoute.snapshot.params['id']).subscribe({
      next: (product) => {
        this.setFormData(product);
        if (this.isReadOnly) {
          this.productData.disable();
        }
        this.productData.get('productId')?.disable();
      }
    });
  }

  setFormData(product: Product) {
    if (product) {
      this.product$ = new Product(product);
      this.productData.patchValue(product);
    }
    this.productData.updateValueAndValidity();
  }

  save() {
    this.loadingService.show();

    const rawProduct = this.productData.getRawValue();
    this.setFormData(rawProduct);

    const productObservable: Observable<any> = this.isAdd
      ? this.productService.create(this.product$)
      : this.productService.update(this.product$);

    productObservable.pipe(
      finalize(() => this.loadingService.hide())
    ).subscribe(
      {
        next: () => {
          this.snackBar.open('Guardado exitosamente', 'aceptar', {
            duration: 2000,
          });
          this.router.navigate(['products']);
        },
        error: () => {
          this.snackBar.open('Ocurrió un error', 'aceptar', {
            duration: 2000,
          });
        }
      });
  }

  get invalid(): boolean {
    return this.productData.invalid;
  }
}
