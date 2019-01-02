import { Component } from '@angular/core';
import { PostsService } from '../../../services/posts.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

@Component({
  selector: 'app-create-thread-modal',
  templateUrl: './create-thread-modal.component.html'
})


export class CreateThreadModalComponent {
  newPostForm: FormGroup;
  message: string;
  constructor(
    public dialogRef: MatDialogRef<CreateThreadModalComponent>,
    private postService: PostsService,
    private formBuilder: FormBuilder) {
    this.newPostForm = this.formBuilder.group({
      topic: [
        '',
        [Validators.required]
      ],
      content: [
        '',
        [Validators.required]
      ]
    });
  }
  submit() {
    this.postService
      .createThread(this.newPostForm.controls.topic.value, this.newPostForm.controls.content.value)
      .subscribe(result => {
        this.dialogRef.close();
      }, error => this.message = "Wystąpił błąd");
  }
}
