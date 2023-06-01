import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SectionRoutingModule } from './section-routing.module';
import { SectionListComponent } from './section-list/section-list.component';
import { SectionDetailComponent } from './section-detail/section-detail.component';


@NgModule({
  declarations: [
    SectionListComponent,
    SectionDetailComponent
  ],
  imports: [
    CommonModule,
    SectionRoutingModule
  ]
})
export class SectionModule { }
