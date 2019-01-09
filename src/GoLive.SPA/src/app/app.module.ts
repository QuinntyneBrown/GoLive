import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { baseUrl } from './core/constants';
import { CustomersModule } from './customers/customers.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CustomersModule
  ],
  providers: [{
    provide: baseUrl,
    useValue:"https://localhost:44324/"
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
