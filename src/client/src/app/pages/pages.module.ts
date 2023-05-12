import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {PagesRoutingModule} from './pages-routing.module';
import {MenuResolver} from "../resolvers/menu.resolver";

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PagesRoutingModule
  ],
})
export class PagesModule {
}

