import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuRoutingModule } from './menu-routing.module';
import { MenuListComponent } from './menu-list/menu-list.component';
import { MenuDetailComponent } from './menu-detail/menu-detail.component';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from "@angular/material/icon";
import {MatTableModule} from "@angular/material/table";
import {CdkDrag, CdkDropList} from "@angular/cdk/drag-drop";


@NgModule({
  declarations: [
    MenuListComponent,
    MenuDetailComponent
  ],
  imports: [
    CommonModule,
    MenuRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatTableModule,
    CdkDrag,
    CdkDropList
  ]
})
export class MenuModule { }
