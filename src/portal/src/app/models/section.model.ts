import {Product} from "./product.model";
import {Status} from "./enums/status.enum";

export class Section {
  sectionId?: number;
  sectionName: string;
  imageUrl: string;
  products: Array<Product>;
  status: Status;
  constructor(section: any = {}) {
    Object.assign(this, section);
    this.products = section.products?.map((p: any) => {
      return new Product(p);
    }) ?? [];
  }


}
