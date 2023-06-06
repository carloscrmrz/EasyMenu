import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Section} from "../models/section.model";

@Injectable({
  providedIn: 'root'
})
export class SectionService {
  private readonly apiUrl = `https://localhost:7245/section`;

  constructor(private http: HttpClient) {
  }

  all(): Observable<Array<Section>> {
    // @ts-ignore
    return this.http.get<Array<Section>>(this.apiUrl);
  }

  get(sectionId: number): Observable<Section> {
    return this.http.get<Section>(`${this.apiUrl}/${sectionId}`);
  }

  create(section: Section): Observable<Section> {
    return this.http.post<Section>(`${this.apiUrl}`, section);
  }

  update(section: Section): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}`, section);
  }

  delete(sectionId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${sectionId}`);
  }
}
