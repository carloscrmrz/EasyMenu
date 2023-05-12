import { Component } from '@angular/core';
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {
  email = new FormControl<string>('', [Validators.email, Validators.required])
  constructor() {
  }
}
