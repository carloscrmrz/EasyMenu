import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {
  private storage: Map<string, any> = new Map<string, any>();

  setJsonValue(key: string, value: any): void {
    this.storage.set(key, value);
  }

  getJsonValue(key: string): any {
    return this.storage.get(key);
  }

  removeJsonValue(key: string): void {
    this.storage.delete(key);
  }

  clear(): Promise<any> {
    return Promise.resolve(this.storage.clear());
  }
}
