import { Component } from "@angular/core";
import { Subject } from "rxjs";
import { CustomerService } from './customer.service';
import { Customer } from './customer.model';
import { UpsertCustomerOverlay } from './upsert-customer-overlay';
import { MatTableDataSource } from '@angular/material';
import { tap, takeUntil } from 'rxjs/operators';

@Component({
  templateUrl: "./customers-page.component.html",
  styleUrls: ["./customers-page.component.css"],
  selector: "app-customers-page"
})
export class CustomersPageComponent { 
  constructor(
    private readonly _customerService: CustomerService,
    private readonly _upsertCustomerOverlay: UpsertCustomerOverlay
  ) { }

  public dataSource = new MatTableDataSource<Customer>([]);

  ngOnInit() {
    this._customerService
      .get()
      .pipe(
        tap(x => {
          this.dataSource = new MatTableDataSource<Customer>(x);
        }),
        takeUntil(this.onDestroy)
      )
      .subscribe();
  }

  public columnsToDisplay: string[] = ['customerId', 'name', 'isLive'];
  
  public onDestroy: Subject<void> = new Subject<void>();

  public createOverlay($event: any = {}) {    
    this._upsertCustomerOverlay.create({
      source: {
        customerId: $event.customerId
      }
    })
    .pipe(
      tap(x => {
        let data = this.dataSource.data.slice(0);
        // upsert customer to data
        this.dataSource = new MatTableDataSource<Customer>(data);
      }),
      takeUntil(this.onDestroy)
    )
    .subscribe();
  }

  ngOnDestroy() {
    this.onDestroy.next();	
  }
}
