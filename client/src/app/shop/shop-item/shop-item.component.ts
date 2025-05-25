import { Component, Input } from '@angular/core';
import { Product } from '../../shared/Models/Product';
import { CartService } from '../../cart/cart.service';

@Component({
  selector: 'app-shop-item',
  standalone: false,
  templateUrl: './shop-item.component.html',
  styleUrl: './shop-item.component.css'
})
export class ShopItemComponent {
  constructor(private service:CartService){}
  @Input() Product: Product;
  SetBasketValue (){
    this.service.addItemtoBasket(this.Product);
  }
}
