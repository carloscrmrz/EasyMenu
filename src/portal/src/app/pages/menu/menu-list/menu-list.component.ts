import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {MenuService} from "../../../services/menu.service";

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.scss']
})
export class MenuListComponent {
  displayedColumns = ['menuId', 'actions'];
  menuList = this.menuService.all();

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
      next: (result) => {
        this.menuList = this.menuService.all();
      }
    });
  }
}
