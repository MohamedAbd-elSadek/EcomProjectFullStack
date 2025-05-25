import { v4 as uuidv4 } from 'uuid';

export interface Basket {
  id: string
  basketItems: BasketItem[]
}

export interface BasketItem {
  id: string
  name: string
  image: string
  quantity: number
  price: number
  category: string
}

export class CustomerBasket implements Basket {
    id= uuidv4();
    basketItems: BasketItem[]
    
}