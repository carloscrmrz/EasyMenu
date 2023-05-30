import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MenuService} from "../../services/menu.service";
import {Observable, of} from "rxjs";
import {Menu} from "../../model/menu.model";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  restaurantName: string = '';
  menu$: Observable<Menu>;
  constructor(private route: ActivatedRoute,
              private menuService: MenuService) {
  }

  ngOnInit(): void {
    this.restaurantName = this.route.snapshot.paramMap.get('name') ?? '';
    this.menu$ = this.menuService.getMenu(this.restaurantName);
  }
}
