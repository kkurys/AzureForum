import { User } from './user.model';

export class Post {
  constructor(
    public id: string,
    public content: string,
    public createdBy: User,
    public createdOn: Date
  ) { }
}
