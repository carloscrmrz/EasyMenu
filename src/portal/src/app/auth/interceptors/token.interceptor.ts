import {Inject, Injectable} from '@angular/core';
import {APP_BASE_HREF} from '@angular/common';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AuthService} from "../auth.service";


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService,
              @Inject(APP_BASE_HREF) public baseHref: string) {
  }

  private static addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
        Accept: 'application/json'
      }
    });
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // if (this.authService.userIsLoggedIn()) {
    //   req = TokenInterceptor.addToken(req, this.authService.token);

    return next.handle(req);
    }
    // return next.handle(req)
    //   .pipe(
    //     tap(() => this.authService.resetInactivityTimer()),
    //     catchError(err => {
    //       const controlledMsg = err.status === HTTP_STATUS_UNAUTHORIZED || err.status === HTTP_STATUS_INTERNAL_SERVER_ERROR;
    //       if (err instanceof HttpErrorResponse && controlledMsg) {
    //         let key;
    //         if (err.status === HTTP_STATUS_UNAUTHORIZED) {
    //           key = 'general.expiration-time';
    //           this.authService.userLogout();
    //         } else if (err.status === HTTP_STATUS_INTERNAL_SERVER_ERROR) {
    //           key = 'general.default-error-message';
    //         }
    //         this.translateService.get(key).subscribe((message: any) =>
    //           this.messagesService.openSnackBar(message));
    //       }
    //       return throwError(() => err);
    //     })
    //   );
}
