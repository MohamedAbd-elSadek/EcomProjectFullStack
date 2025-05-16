import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/Models/Product';

@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {
  constructor(private readonly shopService:ShopService){

  }
  ngOnInit(): void {
   this.getAllProducts();
  }

  product:Product[]

  getAllProducts(){
    this.shopService.getProduct().subscribe({
      next:((value:Product[])=>{
        this.product=value;
      })
    })
  }
}
