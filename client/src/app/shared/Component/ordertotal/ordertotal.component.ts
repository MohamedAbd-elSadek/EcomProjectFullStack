import { Component, OnInit } from '@angular/core';
import { BasketTotal } from '../../Models/Basket';
import { CartService } from '../../../cart/cart.service';

@Component({
  selector: 'app-ordertotal',
  standalone: false,
  templateUrl: './ordertotal.component.html',
  styleUrls: ['./ordertotal.component.css']
})
export class OrdertotalComponent implements OnInit {
  constructor(private cartService:CartService){}

  basketTotal:BasketTotal
  ngOnInit(): void {
    this.cartService.basketTotal$.subscribe({
      next:(value)=>{
        this.basketTotal=value;
      },
      error:(err)=>{
        console.log(err);
        
      }
    })
  }

}
