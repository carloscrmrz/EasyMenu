import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MenuDetailComponent} from "./menu-detail/menu-detail.component";
import {MenuListComponent} from "./menu-list/menu-list.component";

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: MenuListComponent
      },

      {
        path: 'add',
        component: MenuDetailComponent
      },
      {
        path: 'view/:id',
        component: MenuDetailComponent
      },
      {
        path: 'edit/:id',
        component: MenuDetailComponent
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
export class MenuRoutingModule {
}
