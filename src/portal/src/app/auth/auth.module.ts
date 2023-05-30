import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import {TokenInterceptor} from "./interceptors/token.interceptor";
import {HTTP_INTERCEPTORS} from "@angular/common/http";



@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
  ]
})
export class AuthModule { }
