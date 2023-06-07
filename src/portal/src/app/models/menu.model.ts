import {Status} from "./enums/status.enum";
import {Section} from "./section.model";

export class Menu {
  menuId: number;
  tenantId: number;
  status: Status;
  sections: Array<Section>;

  constructor(menu : any = {}) {
    Object.assign(this, menu);
    this.status = menu.status;
    this.sections = menu.sections?.map((s: any) => {
      return new Section(s);
    });
  }
}
