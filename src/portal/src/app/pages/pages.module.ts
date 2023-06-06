import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { HomeComponent } from './home/home.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";



@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class PagesModule { }
