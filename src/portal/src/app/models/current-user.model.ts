import {User} from "./user.model";

export class CurrentUser {
  user?: User;
  token?: string;

  constructor(currentUser: any = {}) {
    Object.assign(this, currentUser);
    this.user = new User(currentUser?.user);
  }
}
