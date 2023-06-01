import {Injectable} from "@angular/core";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {map, Observable, of} from "rxjs";
import {catchError, tap} from "rxjs/operators";
import {CurrentUser} from "../models/current-user.model";
import {Login} from "../models/login.model";

@Injectable()
export class AuthService {
  // private apiUrl = `${environment.portalApiUrl}/auth`;
  private apiUrl = `https://localhost:7245/auth`;
  public currentUser: User | null;

  constructor(private http: HttpClient,
              private router: Router) {
  }

  get currentUser$(): Observable<User> {
    return this.currentUser ? of(this.currentUser) : this.http.get<User>(`${this.apiUrl}/current`)
      .pipe(
        tap(user => {
          this.setCurrentUser(user);
        }),
      );
  }

  userLogin(loginModel: Login) {
    return this.http.post<CurrentUser>(`${this.apiUrl}`, loginModel)
      .pipe(
        map(authInfo => {
          return new CurrentUser(authInfo);
        }),
        tap((authResponse: CurrentUser) => {
          this.setCurrentUser(authResponse.user);
        }),
        catchError((error: HttpErrorResponse) => {
          throw error;
        })
      );
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
    return this.router.navigate(['login']).then((canNavigate) => {
      if (canNavigate) {
        this.cleanSession();
      }
    });
  }

  async cleanSession() {
    this.currentUser = null;
    localStorage.clear();
  }

  public setCurrentUser(user: User | undefined) {
    // this.sessionStorageService.setJsonValue('user', user.userInfo);
    // this.sessionStorageService.setJsonValue('userLogin', user.userLogin);
    // this.sessionStorageService.setJsonValue('institutionRolexRefId', user.institutionRolexRefId);
    // this.sessionStorageService.setJsonValue('showNotifyfExpPsw', user.showNotifyfExpPsw);
    // this.sessionStorageService.setJsonValue('daysToExpire', user.daysToExpire);
    this.currentUser = new User(user);
    // this.requestCacheService.cacheExpirationTime = user?.cacheExpirationTime;
  }
}
