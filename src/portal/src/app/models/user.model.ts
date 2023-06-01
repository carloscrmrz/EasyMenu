import {Tenant} from "./tenant.model";

export class User {
  userId: number;
  userLogin?: string;
  tenantId: number;
  tenant: Tenant;

  constructor(user: any = {}) {
    Object.assign(this, user);
    this.tenant = new Tenant(user?.tenant);
  }
}
