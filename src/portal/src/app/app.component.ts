import { Component } from '@angular/core';
import {AuthService} from "./auth/auth.service";
import {Subscription} from "rxjs";

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
