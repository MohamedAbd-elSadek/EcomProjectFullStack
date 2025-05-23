import { Injectable, OnInit } from '@angular/core';
import { environment } from '../../enviroment/enviroment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../shared/Models/Product';
import { Category } from '../shared/Models/Category';
import { ProductParam } from '../shared/Models/ProductParam';

@Injectable({
  providedIn: 'root'
})
export class ShopService implements OnInit {

constructor(private readonly http:HttpClient){

  }

  category:Category[];
  getCategory(){
    return this.http.get<Category[]>(environment.apiUrl + '/category');
  }

  prodUrl =environment.apiUrl + '/product?sort=&categoryId=&PageSize=4&PageNumber=1&search=';

  product:Product[];

  getProduct(ProductParam?: ProductParam) {
    let param = new HttpParams();
    if(ProductParam?.categoryId){
      param = param.set("categoryId", ProductParam.categoryId);
    }
    if(ProductParam?.sortingOption) {
      param = param.set("sort", ProductParam.sortingOption);
    }
    if(ProductParam?.search){
      param = param.set("search", ProductParam.search);
    }
    if(ProductParam?.pageNumber){
      param = param.set("PageNumber", ProductParam.pageNumber);
    }
    if(ProductParam?.pageSize){
      param = param.set("PageSize", ProductParam.pageSize);
    }
    return this.http.get<{ data: Product[], totalCount: number }>(environment.apiUrl + '/product', { params: param });
  }


  ngOnInit(): void {
this.getCategory();
this.getProduct();
}
}
