import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {SectionDetailComponent} from "./section-detail/section-detail.component";
import {SectionListComponent} from "./section-list/section-list.component";

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: SectionListComponent
      },

      {
        path: 'add',
        component: SectionDetailComponent
      },
      {
        path: 'view/:id',
        component: SectionDetailComponent
      },
      {
        path: 'edit/:id',
        component: SectionDetailComponent
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
export class SectionRoutingModule {
}
