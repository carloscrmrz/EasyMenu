import {Status} from "./enums/status.enum";

export class Tenant {
  tenantId?: number;
  tenantName: string;
  subPath: string;
  address: string;
  telephone: number;
  status: Status;
  constructor(product: any = {}) {
    Object.assign(this, product);
  }
}
