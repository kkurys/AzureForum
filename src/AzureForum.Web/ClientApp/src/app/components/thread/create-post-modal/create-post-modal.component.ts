import { Component, Inject } from '@angular/core';
import { PostsService } from '../../../services/posts.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

@Component({
  selector: 'app-create-post-modal',
  templateUrl: './create-post-modal.component.html'
})


export class CreatePostModalComponent {
  newPostForm: FormGroup;
  message: string;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CreatePostModalComponent>,
    private postService: PostsService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      content: [
        '',
        [Validators.required]
      ]
    });
  }
  submit() {
    this.postService
      .createPost(this.data.threadId, this.newPostForm.controls.content.value)
      .subscribe(result => {
        this.dialogRef.close("ok");
      }, error => this.message = "Wystąpił błąd");
  }
}
