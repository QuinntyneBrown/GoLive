import { Component, ChangeDetectorRef } from "@angular/core";
import { Subject, Observable } from "rxjs";
import { CustomerService } from './customer.service';
import { Customer } from './customer.model';
import { UpsertCustomerOverlay } from './upsert-customer-overlay';
import { MatTableDataSource } from '@angular/material';
import { tap } from 'rxjs/operators';

@Component({
  templateUrl: "./customers-page.component.html",
  styleUrls: ["./customers-page.component.css"],
  selector: "app-customers-page"
})
export class CustomersPageComponent { 
  constructor(
    private readonly _customerService: CustomerService,
    private readonly _upsertCustomerOverlay: UpsertCustomerOverlay,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ) { }

  public dataSource = new MatTableDataSource<Customer>([]);

  ngOnInit() {
    this._customerService
      .get()
      .pipe(
        tap(x => {
          this.dataSource = new MatTableDataSource<Customer>(x);
        })
      )
      .subscribe();
  }

  public columnsToDisplay: string[] = ['customerId','name','isLive'];
  
  public onDestroy: Subject<void> = new Subject<void>();

  public open($event:any) {
    this._upsertCustomerOverlay.create()
      .subscribe();
  }

  ngOnDestroy() {
    this.onDestroy.next();	
  }
}
