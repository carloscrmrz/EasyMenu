import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Product} from "../models/product.model";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  // private readonly apiUrl = `${environment.apiUrl}/product`;
  private readonly apiUrl = `https://localhost:7245/product`;

  constructor(private http: HttpClient) {
  }

  all(): Observable<Array<Product>> {
    // @ts-ignore
    return this.http.get<Array<Product>>(this.apiUrl);
  }

  get(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${productId}`);
  }

  create(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.apiUrl}`, product);
  }

  update(product: Product): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}`, product);
  }

  delete(productId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${productId}`);
  }
}
