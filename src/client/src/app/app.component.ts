import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<mat-card><router-outlet></router-outlet></mat-card>`,
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor() {
  }

}

