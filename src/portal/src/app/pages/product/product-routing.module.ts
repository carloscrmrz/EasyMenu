import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ProductListComponent} from "./product-list/product-list.component";
import {ProductDetailComponent} from "./product-detail/product-detail.component";

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: ProductListComponent
      },

      {
        path: 'add',
        component: ProductDetailComponent
      },
      {
        path: 'view/:id',
        component: ProductDetailComponent
      },
      {
        path: 'edit/:id',
        component: ProductDetailComponent
      },
      {
        path: '**',
        redirectTo: ''
      }
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
