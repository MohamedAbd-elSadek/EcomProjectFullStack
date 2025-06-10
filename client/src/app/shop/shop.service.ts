import { Injectable } from '@angular/core';
import { environment } from '../../enviroment/enviroment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../shared/Models/Product';
import { Category } from '../shared/Models/Category';
import { ProductParam } from '../shared/Models/ProductParam';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private readonly http: HttpClient) {}

  getCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(environment.apiUrl + '/category');
  }

  
  getProduct(productParam?: ProductParam): Observable<{ data: Product[], totalCount: number }> {
    let params = new HttpParams();

    if (productParam?.categoryId) {
      params = params.set("categoryId", productParam.categoryId);
    }
    if (productParam?.sortingOption) {
      params = params.set("sort", productParam.sortingOption);
    }
    if (productParam?.search) {
      params = params.set("search", productParam.search);
    }
    if (productParam?.pageNumber) {
      params = params.set("PageNumber", productParam.pageNumber.toString());
    }
    if (productParam?.pageSize) {
      params = params.set("PageSize", productParam.pageSize.toString());
    }

    return this.http.get<{ data: Product[], totalCount: number }>(
      environment.apiUrl + '/product',
      { params: params }
    );
  }

  getProductDetails(productId: string): Observable<Product> {
    return this.http.get<Product>(environment.apiUrl + '/product/' + productId);
  }

  
}
