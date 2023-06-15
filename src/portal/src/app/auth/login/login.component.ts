import {Component, OnInit} from '@angular/core';
import {UntypedFormBuilder, Validators} from "@angular/forms";
import {CurrentUser} from "../../models/current-user.model";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  private HTTP_STATUS_AUTHENTICATION_TIME_OUT = 419;

  HOME_URL = 'menu';
  loginForm = this.fb.group({
    userLogin: ['', Validators.compose([Validators.required])],
    userPass: ['', Validators.compose([Validators.required])]
  });

  needChangePsw = false;
  currentUser = new CurrentUser();

  constructor(protected fb: UntypedFormBuilder,
              protected router: Router,
              protected authService: AuthService) {
  }

  ngOnInit() {
    this.authService.cleanSession();
    this.setPasswordLengthValidator();
  }

  signIn() {
    this.authService.userLogin(this.loginForm.value)
      .subscribe({
        next: () => {
          this.router.navigate([this.HOME_URL]);
        },
        error:
          (error: HttpErrorResponse) => {
            if (error.status === this.HTTP_STATUS_AUTHENTICATION_TIME_OUT) {
              this.currentUser = new CurrentUser(error.error);
              this.needChangePsw = true;
              this.loginForm.reset();
            } else {
              this.loginForm.get('userPass')?.setValue('');
            }
          }
      });
  }

  get loginFormInvalid() {
    return this.loginForm.invalid;
  }

  private setPasswordLengthValidator() {
    const control = this.loginForm.get('userPass');
    control?.addValidators([Validators.minLength(4), Validators.maxLength(27)]);
    this.loginForm.updateValueAndValidity();
  }
}
