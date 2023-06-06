import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Menu} from "../models/menu.model";

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private readonly apiUrl = `https://localhost:7245/menu`;

  constructor(private http: HttpClient) {
  }

  all(): Observable<Array<Menu>> {
    // @ts-ignore
    return this.http.get<Array<Menu>>(this.apiUrl);
  }

  get(menuId: number): Observable<Menu> {
    return this.http.get<Menu>(`${this.apiUrl}/${menuId}`);
  }

  create(menu: Menu): Observable<Menu> {
    return this.http.post<Menu>(`${this.apiUrl}`, menu);
  }

  update(menu: Menu): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}`, menu);
  }

  delete(menuId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${menuId}`);
  }
}
