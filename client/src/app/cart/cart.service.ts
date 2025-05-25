import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Basket } from '../shared/Models/Basket';
import { environment } from '../../enviroment/enviroment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private readonly http:HttpClient) { }
  baseURL = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket>(null)
  basket = this.basketSource.asObservable();

  GetBasket(id:string){
   return this.http.get(this.baseURL+'/baskets/'+id).pipe(
      map((value:Basket)=>{
        this.basketSource.next(value);
      })
    )
  }
  SetBasket(basket:Basket){
    return this.http.post(this.baseURL+'baskets/',basket).subscribe({
      next:(value:Basket)=>{
        this.basketSource.next(value);
      },
      error(err){
        console.log(err);
        
      }
    })
  }
  GetCurrentValue(){
    return this.basketSource.value;
  }
}
