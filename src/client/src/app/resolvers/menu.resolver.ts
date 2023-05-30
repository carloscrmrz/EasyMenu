import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {MenuService} from "../services/menu.service";
import {Menu} from "../model/menu.model";


// @Injectable({
//   providedIn: 'root'
// })
// export class MenuResolver implements Resolve<Menu> {
//
//   constructor(private menuService: MenuService) {}
//
//   // resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Menu> {
//   //
//   // }
// }
