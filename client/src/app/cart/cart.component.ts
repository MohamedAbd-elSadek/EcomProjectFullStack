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
  trackByIndex(index: number, item: any): number {
  return index;
}

  RemoveItemFromBasket(item:BasketItem){
    this.service.removeItemFromBasket(item);
  }

  IncrementQuantity(item:BasketItem){
    this.service.incrementQuantity(item);
    
  }

  DecrementQuantity(item:BasketItem){
    this.service.DecrementQuantity(item);
    
  }

}
