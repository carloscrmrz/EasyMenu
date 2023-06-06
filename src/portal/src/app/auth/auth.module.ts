import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TokenInterceptor} from "./interceptors/token.interceptor";
import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatError, MatFormFieldModule} from "@angular/material/form-field";
import {LoginComponent} from "./login/login.component";
import {AuthService} from "./auth.service";


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
  ],
  providers: [
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: TokenInterceptor,
    //   multi: true
    // },
  ]
})
export class AuthModule { }
