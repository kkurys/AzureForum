export class CreatePostRequest {
  constructor(
    public threadId: string,
    public content: string) { }
}
