import {Injectable} from "@angular/core";
import {User} from "../models/user.model";
import {HttpClient, HttpErrorResponse, HttpStatusCode} from "@angular/common/http";
import {Router} from "@angular/router";
import {SessionStorageService} from "./session-storage.service";
import {map, Observable, of} from "rxjs";
import {catchError, tap} from "rxjs/operators";
import {CurrentUser} from "../models/current-user.model";
import {Login} from "../models/login.model";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public static readonly AUTH_TOKEN = 'token';
  private apiUrl = `https://localhost:4201/portal-api/auth`;

  public currentUser: User | null;

  constructor(private http: HttpClient,
              private router: Router,
              private sessionStorageService: SessionStorageService) {

  }

  get currentUser$(): Observable<User> {
    return this.currentUser
      ? of(this.currentUser)
      : this.http.get<User>(`${this.apiUrl}/current`)
        .pipe(
          tap(user => this.setCurrentUser(user)),
        );
  }

  get token(): string {
    return this.sessionStorageService.getJsonValue(AuthService.AUTH_TOKEN);
  }

  // get inactivityTimer$(): Observable<any> {
  //   // return super.genericInactivityTimer$(() => this.userLogout());
  // }

  userLogin(loginModel: Login) {
    // console.log(loginModel)
    return new Observable<CurrentUser>((obs) => {
        obs.next(new CurrentUser({user: new User({userId: 1, userLogin: 'admin', tenantId: 1})}));
    });
    // return this.http.post<CurrentUser>(`${this.apiUrl}`, loginModel)
    //   .pipe(
    //     map(authInfo => new CurrentUser(authInfo)),
    //     tap((authResponse: CurrentUser) => {
    //       this.setSessionItems(authResponse);
    //       this.setCurrentUser(authResponse.user!);
    //     }),
    //     catchError((error: HttpErrorResponse) => {
    //       if (error.status === HttpStatusCode.Unauthorized) {
    //         // this.messagesService.openSnackBar(error.error.message);
    //       }
    //
    //       if (error.status === HttpStatusCode.Forbidden) {
    //         // this.messagesService.openSnackBar(error.error.message);
    //       }
    //       if (error.status === 419) {
    //         this.setSessionItems(error.error);
    //       }
    //       throw error;
    //     })
    //   );
  }

  // changePsw(changePsw: UserChangePsw) {
  //   const options = {
  //     headers: new HttpHeaders()
  //       .set('Authorization', `Bearer ${this.token}`)
  //   };
  //   return this.http.post<UserChangePsw>(`${this.apiUrl}/changePsw`, changePsw, options)
  //     .pipe(
  //       catchError((response: HttpErrorResponse) => {
  //         if (response.status === HttpStatusCode.InternalServerError) {
  //           this.messagesService.openSnackBar('auth.pass-update-error');
  //         }
  //         if (response.status === HttpStatusCode.BadRequest) {
  //           this.messagesService.openSnackBar(response.error.message);
  //         }
  //         throw response;
  //       }),
  //       tap(() => this.cleanSession()),
  //     );
  // }

  userLogout() {
    return this.router.navigate(['login']).then((canNavigate: any) => {
      if (canNavigate) {
        this.cleanSession();
      }
    });
  }

  get daysToExpire(): string {
    return this.sessionStorageService.getJsonValue('daysToExpire');
  }

  // public isAuthenticated(): boolean {
  //   return !this.jwtHelper.isTokenExpired(this.token);
  // }
  //
  // userIsLoggedIn(): boolean {
  //   const isExpired = this.jwtHelper.isTokenExpired(this.token);
  //   return !isExpired;
  // }

  async cleanSession() {
    this.currentUser = null;
    localStorage.clear();
    await this.sessionStorageService.clear();
  }

  public setCurrentUser(user: User) {
    this.sessionStorageService.setJsonValue('userLogin', user.userLogin);
    this.sessionStorageService.setJsonValue('tenantId', user.tenantId);

    this.currentUser = new User(user);
  }

  private setSessionItems(authResult: CurrentUser) {
    this.sessionStorageService.setJsonValue(AuthService.AUTH_TOKEN, authResult.token);
  }
}
