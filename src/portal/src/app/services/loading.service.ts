import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

export interface LoadingData {
  show: boolean;
  message?: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private loaderSubject: BehaviorSubject<LoadingData> = new BehaviorSubject<LoadingData>({show: false});
  public loading$: Observable<LoadingData> = this.loaderSubject.asObservable();

  constructor() {
  }

  show(key: string = 'Cargando...') {
    this.loaderSubject.next({show: true, message: key});
  }

  hide() {
    this.loaderSubject.next({show: false});
  }
}
