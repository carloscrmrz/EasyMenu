import {Status} from "./enums/status.enum";

export class Product {
  productId?: number;
  productName: string;
  description: string;
  price: number;
  position: number;
  status: Status;
  constructor(product: any = {}) {
    Object.assign(this, product);
  }
}
