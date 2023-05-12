import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LandingComponent} from "../components/landing/landing.component";
import {MenuComponent} from "../components/menu/menu.component";
import {MenuResolver} from "../resolvers/menu.resolver";

const routes: Routes = [
  {
    path: '', component: LandingComponent
  },
  {
    path: 'menu/:name', component: MenuComponent, resolve: { menu: MenuResolver }
  },
  {
    path: '**', redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule {
}
