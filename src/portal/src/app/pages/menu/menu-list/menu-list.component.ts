import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {MenuService} from "../../../services/menu.service";
import {Observable} from "rxjs";
import {Menu} from "../../../models/menu.model";

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.scss']
})
export class MenuListComponent {
  displayedColumns = ['menuId', 'menuStatus', 'actions'];
  menuList$: Observable<Menu[]> = this.menuService.all();
  statusMap: Readonly<any> = Object.freeze(
    {
      1: 'Activo',
      2: 'Desactivado'
    });


  constructor(protected router: Router,
              private menuService: MenuService) {
  }

  add() {
    this.router.navigate(['menu', 'add']);
  }

  view(id: number) {
    this.router.navigate(['menu', 'view', id]);
  }

  edit(id: number) {
    this.router.navigate(['menu', 'edit', id]);
  }

  delete(id: number) {
    this.menuService.delete(id).subscribe({
      next: () => {
        this.menuList$ = this.menuService.all();
      }
    });
  }

  activate(id: number) {
    this.menuService.makeMenuPrincipal(id).subscribe({
      next: () => {
        this.menuList$ = this.menuService.all();
      }
    })
  }
}
