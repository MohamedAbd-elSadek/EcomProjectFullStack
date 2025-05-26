import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Basket, BasketItem, BasketTotal, CustomerBasket } from '../shared/Models/Basket';
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
  private basketSourceTotal = new BehaviorSubject<BasketTotal>(null)
  basketTotal$ = this.basketSourceTotal.asObservable();

  calculateTotal(){
    const basket = this.GetCurrentValue();
    const shipping =0;
    const subtotal = basket.basketItems.reduce((a,c)=>{
      return (c.price * c.quantity) +a
    },0)
    const total = shipping +subtotal;
    this.basketSourceTotal.next({
      shipping,subtotal,total
    })
  }

  GetBasket(id:string){
   return this.http.get(this.baseURL+'/baskets/'+id).pipe(
      map((value:Basket)=>{
        this.basketSource.next(value);
        // console.log(value);
        this.calculateTotal();
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
        this.calculateTotal();
        
        
      },
      error(err){
        console.log(err);
        
      }
    })
  }
  GetCurrentValue(){
    return this.basketSource.value;
  }

 

  addItemtoBasket(product: Product, quantity: number = 1) {
  const itemToAdd: BasketItem = this.mapProductToBasketItem(product, quantity);
  let basket = this.GetCurrentValue();

  if (!basket || !basket.id) {
    basket = this.CreateBasket();
    this.basketSource.next(basket); // ✅ Immediately emit it here
  }

  basket.basketItems = this.AddorUpdate(basket.basketItems, itemToAdd, quantity);
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

  incrementQuantity(item:BasketItem){
    const basket = this.GetCurrentValue();
    const itemIndex = basket.basketItems.findIndex(i=>i.id === item.id);
    basket.basketItems[itemIndex].quantity++;
    this.SetBasket(basket);
  }

  DecrementQuantity(item:BasketItem){
    const basket = this.GetCurrentValue();
    const itemIndex = basket.basketItems.findIndex(i=>i.id === item.id);
    if(basket.basketItems[itemIndex].quantity == 1){
      this.removeItemFromBasket(item);
    }else {
    basket.basketItems[itemIndex].quantity--;
    this.SetBasket(basket);
    }
    
  }
  removeItemFromBasket(item: BasketItem) {
    const basket = this.GetCurrentValue();
    if(basket.basketItems.some(i=>i.id === item.id)){
      basket.basketItems = basket.basketItems.filter(i=>i.id != item.id);
      if (basket.basketItems.length >0){
        this.SetBasket(basket);
    }else{
        this.DeleteBasketItem(basket);
    }
    }
    
  }
  DeleteBasketItem(basket: Basket) {
    return this.http.delete(this.baseURL+'/baskets/'+basket.id).subscribe({
      next:(value)=>{
        this.basketSource.next(null); 
        localStorage.removeItem('BasketId');
      },
      error:(err)=>{
        console.log(err);
        
      }
    })
  }
}
