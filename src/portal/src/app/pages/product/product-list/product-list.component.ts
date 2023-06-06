import { Component } from '@angular/core';
import {ProductService} from "../../../services/product.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent {

  displayedColumns = ['productId', 'productName', 'actions'];
  productList$ = this.productService.all();
  constructor(protected router: Router,
    private productService: ProductService) {
  }

  add() {
    this.router.navigate(['product', 'add']);
  }

  view(id: number) {
    this.router.navigate(['product', 'view', id]);
  }

  edit(id: number) {
    this.router.navigate(['product', 'edit', id]);
  }

  delete(id: number) {
    this.productService.delete(id).subscribe({
      next: (result) => {
        this.productList$ = this.productService.all();
        result ? console.log('Deleted') : console.log('Not deleted');
      }
    });
  }
}
