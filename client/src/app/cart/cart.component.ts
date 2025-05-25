import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { Basket, BasketItem } from '../shared/Models/Basket';

@Component({
  selector: 'app-cart',
  standalone: false,
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{
  constructor(private readonly service:CartService){}

  basket:Basket
  ngOnInit(): void {
    this.service.basket$.subscribe({
      next:(value) =>{
        this.basket = value;
      },
      error(err){
        console.log(err);
        
      }
    })
  }

  incrementQuantity(item:BasketItem){
    item.quantity++;
  }
  DecrementQuantity(item:BasketItem){
    if(item.quantity>=1){
    item.quantity--;
    }
  }
  RemoveBasket(item:BasketItem){

  }

}
