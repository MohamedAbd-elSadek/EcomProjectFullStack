import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { RouterModule } from '@angular/router';
import { OrdertotalComponent } from './Component/ordertotal/ordertotal.component';



@NgModule({
  declarations: [
    OrdertotalComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    RouterModule
  ],
  exports:[PaginationModule,OrdertotalComponent]
})
export class SharedModule { }
