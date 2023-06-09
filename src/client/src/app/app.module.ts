import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';

import {LandingComponent} from './components/landing/landing.component';
import {MenuComponent} from './components/menu/menu.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatGridListModule} from "@angular/material/grid-list";
import {MatCardModule} from "@angular/material/card";
import {HttpClientModule} from "@angular/common/http";
import {ReactiveFormsModule} from "@angular/forms";
import {environment} from "../environments/environment";
import {EasymenuModule} from "../../projects/easymenu/src/lib/easymenu.module";

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatCardModule,
    ReactiveFormsModule,
    EasymenuModule.forRoot({
      apiUrl: environment.apiUrl
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
