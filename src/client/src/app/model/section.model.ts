import {Product} from "./product.model";

export class Section {
  sectionId: number;
  sectionName: string;
  imageUrl?: string;
  products: Array<Product>;
}
