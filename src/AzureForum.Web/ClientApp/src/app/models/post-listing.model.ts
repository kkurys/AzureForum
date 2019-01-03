import { Post } from './post.model';

export class PostListing {
  constructor(
    public threadTopic: string,
    public totalCount: number,
    public posts: Post[]
  ) { }
}
