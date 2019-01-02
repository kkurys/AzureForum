import { User } from './user.model';

export class PostThread {
  constructor(
    public id: string,
    public topic: string,
    public createdBy: User,
    public repliesCount: number
    ) { }
}
