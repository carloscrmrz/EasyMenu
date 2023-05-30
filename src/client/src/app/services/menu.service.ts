import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, of} from "rxjs";
import {Menu} from "../model/menu.model";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  // private mockMenu = [
  //   {
  //     name: 'Menu1',
  //     description: '',
  //     price: 0,
  //     children: [
  //       {
  //         name: 'Steak',
  //         description: 'A normal steak',
  //         price: 0,
  //         children: []
  //       },
  //       {
  //         name: 'Banana',
  //         description: 'It\'s yellow, normally.',
  //         price: 0,
  //         children: []
  //       },
  //       {
  //         name: 'Pasta',
  //         description: 'Mamma Mia',
  //         price: 0,
  //         children: []
  //       },
  //       {
  //         name: 'Orange Juice',
  //         description: 'Orange like the color or like the fruit?',
  //         price: 0,
  //         children: []
  //       },
  //       {
  //         name: 'Tacos',
  //         description: 'Yeah! We also sell those.',
  //         price: 0,
  //         children: []
  //       },
  //       {
  //         name: 'Banana 2',
  //         description: 'It was so good it needed a sequel',
  //         price: 0,
  //         children: []
  //       }
  //     ]
  //   },
  //   // {
  //   //   name: 'Menu2',
  //   //   description: '',
  //   //   price: 0,
  //   //   children: [
  //   //     {
  //   //       name: 'Pozole',
  //   //       description: 'That\' what Elites say',
  //   //       price: 10,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Apple',
  //   //       description: 'Tim Cook approves.',
  //   //       price: 0,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Pasta',
  //   //       description: 'Mamma Mia \n-Mario',
  //   //       price: 0,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Apple Juice',
  //   //       description: 'Like Cider but without alcohol, sad',
  //   //       price: 0,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Tacos',
  //   //       description: 'Yeah! We also sell those.',
  //   //       price: 0,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Lasagna',
  //   //       description: 'Garfield likes this one',
  //   //       price: 5,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Manzana',
  //   //       description: 'Yeah! We also sell those.',
  //   //       price: 0,
  //   //       children: []
  //   //     },
  //   //     {
  //   //       name: 'Lasagna',
  //   //       description: 'Garfield likes this one',
  //   //       price: 5,
  //   //       children: []
  //   //     }
  //   //   ]
  //   // }
  // ]
  private readonly apiUrl = `${environment.apiUrl}/Menu`;

  constructor(public http: HttpClient) {
  }

  getMenu(name: string | null): Observable<Menu> {
    if (name) {
      return this.http.get<Menu>(`${this.apiUrl}/${name}`);
    }
    return this.http.get<Menu>(`${this.apiUrl}/EasyMenu`);
  }
}
