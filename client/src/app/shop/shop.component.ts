import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/Models/Product';
import { Photo } from '../shared/Models/Photo';

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
  photo:Photo[]

  getAllProducts(){
    this.shopService.getProduct().subscribe({
      next:((value:Product[])=>{
        this.product=value;
        console.log(this.product);
      })
    })
  }

}
