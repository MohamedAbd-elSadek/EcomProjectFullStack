import { Injectable, OnInit } from '@angular/core';
import { environment } from '../../enviroment/enviroment';
import { HttpClient } from '@angular/common/http';
import { Product } from '../shared/Models/Product';

@Injectable({
  providedIn: 'root'
})
export class ShopService implements OnInit {

constructor(private readonly http:HttpClient){

  }

 CatUrl = environment.apiUrl + '/category';
  category:any;
  getCategory(){
    return this.http.get(this.CatUrl);
  }

  prodUrl =environment.apiUrl + '/product?sort=&categoryId=&PageSize=4&PageNumber=1&search=';

  product:Product[];

  getProduct(){
    return this.http.get<Product[]>(this.prodUrl);
  }
  ngOnInit(): void {
this.getCategory();
this.getProduct();
}
}
