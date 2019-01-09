import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { OverlayService } from './overlay.service';
import { OverlayRefProvider } from './overlay-ref-provider';

const declarations = [

];

const entryComponents = [

];

const providers = [
  OverlayRefProvider
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
