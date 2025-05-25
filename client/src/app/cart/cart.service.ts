import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Basket, BasketItem, CustomerBasket } from '../shared/Models/Basket';
import { environment } from '../../enviroment/enviroment';
import { Product } from '../shared/Models/Product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private readonly http:HttpClient) { }
  baseURL = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket>(null)
  basket$ = this.basketSource.asObservable();

  GetBasket(id:string){
   return this.http.get(this.baseURL+'/baskets/'+id).pipe(
      map((value:Basket)=>{
        this.basketSource.next(value);
        // console.log(value);
        
        return value;
        
      })
    )
  }
  SetBasket(basket:Basket){
    console.log('Basket being sent:', basket);
    return this.http.post(this.baseURL+'/baskets/',basket).subscribe({
      next:(value:Basket)=>{
        this.basketSource.next(value);
        // console.log(value);
        
        
      },
      error(err){
        console.log(err);
        
      }
    })
  }
  GetCurrentValue(){
    return this.basketSource.value;
  }

  addItemtoBasket(product:Product,quantity:number=1){
    const itemToAdd:BasketItem= this.mapProductToBasketItem(product,quantity);
    let basket = this.GetCurrentValue() 
    if (basket.id == null){
      basket = this.CreateBasket();
    }
    
    basket.basketItems = this.AddorUpdate(basket.basketItems,itemToAdd,quantity);
    return this.SetBasket(basket);
  }
  AddorUpdate(baskeItems: BasketItem[], itemToAdd: BasketItem, quantity: number): BasketItem[] {
    const index= baskeItems.findIndex(i=>i.id === itemToAdd.id)
    if (index == -1){
      itemToAdd.quantity = quantity;
      baskeItems.push(itemToAdd);
    }else {
      baskeItems[index].quantity += quantity;

    }
    return baskeItems;
  }
  private CreateBasket():Basket {
    const _basket  = new CustomerBasket();
    localStorage.setItem("BasketId",_basket.id);
    return _basket;
  }

  private mapProductToBasketItem(product: Product, quantity: number): BasketItem {
    return {
      id:product.productId,
      category:product.categoryName,
      image:product.photos[0].photoPath,
      quantity:quantity,
      name:product.name,
      price:product.price,
      description:product.description
    }
  }
}
