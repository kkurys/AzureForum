import { Post } from './post.model';

export class PostListing {
  constructor(
    public totalCount: number,
    public posts: Post[]
  ) { }
}
