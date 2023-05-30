import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {MenuComponent} from "./menu/menu.component";
import {ProductsComponent} from "./products/products.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'menu', component: MenuComponent},
  {path: 'product', component: ProductsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule {
}
