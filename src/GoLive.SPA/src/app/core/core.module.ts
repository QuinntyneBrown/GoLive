import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { OverlayRefProvider } from './overlay-ref-provider';
import { OverlayRefWrapper } from './overlay-ref-wrapper';

const declarations = [

];

const entryComponents = [

];

const providers = [
  OverlayRefProvider,
  OverlayRefWrapper
];

@NgModule({
  declarations,
  entryComponents,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    SharedModule	
  ],
  providers,
})
export class CoreModule { }
