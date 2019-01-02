import { PostThread } from './post-thread.model';

export class ThreadListing {
  constructor(
    public totalCount: number, 
    public postThreads: PostThread[]) { }
}
