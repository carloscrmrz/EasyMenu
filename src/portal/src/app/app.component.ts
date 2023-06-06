import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isMenuOpen = true;

  constructor() {
  }

  inToolbarMenuToggle() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
