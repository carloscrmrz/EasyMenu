import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {
    path: 'menu',
    loadChildren: () =>
      import('./menu/menu.module').then(m => m.MenuModule)
  },
  {
    path: 'section',
    loadChildren: () =>
      import('./section/section.module').then(m => m.SectionModule)
  },
  {
    path: 'product',
    loadChildren: () =>
      import('./product/product.module').then(m => m.ProductModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule {
}
