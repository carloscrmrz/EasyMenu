import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SectionRoutingModule } from './section-routing.module';
import { SectionListComponent } from './section-list/section-list.component';
import { SectionDetailComponent } from './section-detail/section-detail.component';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from "@angular/material/icon";
import {MatTableModule} from "@angular/material/table";
import {CdkDrag, CdkDropList} from "@angular/cdk/drag-drop";
import {ReactiveFormsModule} from "@angular/forms";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatInputModule} from "@angular/material/input";
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {MatButtonToggleModule} from "@angular/material/button-toggle";


@NgModule({
  declarations: [
    SectionListComponent,
    SectionDetailComponent
  ],
  imports: [
    CommonModule,
    SectionRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatTableModule,
    CdkDropList,
    CdkDrag,
    ReactiveFormsModule,
    MatGridListModule,
    MatInputModule,
    MatSlideToggleModule,
    MatButtonToggleModule
  ]
})
export class SectionModule { }
