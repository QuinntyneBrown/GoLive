import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomersPageComponent } from './customers/customers-page.component';
import { LoginPageComponent } from './identity/login-page.component';
import { HubClientGuard } from './core/hub-client-guard';
import { AuthGuard } from './core/auth.guard';

const routes: Routes = [
  {
    path: "",
    component: CustomersPageComponent,
    canActivate: [AuthGuard, HubClientGuard],
  },
  {
    path: "login",    
    component: LoginPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
