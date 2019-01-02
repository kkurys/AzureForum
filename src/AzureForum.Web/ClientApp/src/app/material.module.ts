import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatSelectModule
  }
  from '@angular/material';

@NgModule({
  imports: [
    MatCardModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatSelectModule
  ],
  exports: [
    MatCardModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatSelectModule
  ]
})
export class MaterialModule { }
