import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MenuService} from "../../services/menu.service";
import {Observable, of} from "rxjs";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  restaurantName: string = '';
  menu$: Observable<any>;
  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.restaurantName = this.route.snapshot.paramMap.get('name') ?? '';
    this.route.data.subscribe({
      next: ({ menu }) => {
        this.menu$ = of(menu)
      }
    })
  }
}
