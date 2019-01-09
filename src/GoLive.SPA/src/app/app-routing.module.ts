import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomersPageComponent } from './customers/customers-page.component';

const routes: Routes = [
  {
    path: "",
    component: CustomersPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
