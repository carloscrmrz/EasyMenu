import {Component, OnInit} from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {UntypedFormBuilder, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  HOME_URL = 'home';
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
    // this.loadingService.show('general.loading-data');
    this.authService.userLogin(this.loginForm.value)
      .subscribe(() => {
        this.router.navigate([this.HOME_URL]);
      }, (error: HttpErrorResponse) => {
        if (error.status === HTTP_STATUS_AUTHENTICATION_TIME_OUT) {
          this.currentUser = new CurrentUser(error.error);
          this.needChangePsw = true;
          this.loginForm.reset();
        } else {
          this.loginForm.get('userPass').setValue('');
        }
      });
  }

  changePsw(changePswModel: UserChangePsw) {
    this.loadingService.show();
    changePswModel.userId = this.currentUser?.user?.userId;
    this.authService.changePsw(changePswModel)
      .pipe(
        finalize(() => this.loadingService.hide()),
      )
      .subscribe(() => {
        this.currentUser = null;
        this.needChangePsw = false;
        const message = this.translateService.instant('auth.pass-update-success');
        this.messagesService.openSnackBar(message);
      });
  }

  get loginFormInvalid() {
    return this.loginForm.invalid;
  }

  private setPasswordLengthValidator() {
    const control = this.loginForm.get('userPass');
    control.addValidators([Validators.minLength(6), Validators.maxLength(27)]);
    this.loginForm.updateValueAndValidity();
  }
}
