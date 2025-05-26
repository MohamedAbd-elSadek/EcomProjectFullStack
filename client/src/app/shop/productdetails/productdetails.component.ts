import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from '../../shared/Models/Product';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CartService } from '../../cart/cart.service';

@Component({
  selector: 'app-productdetails',
  standalone: false,
  templateUrl: './productdetails.component.html',
  styleUrl: './productdetails.component.css'
})
export class ProductdetailsComponent implements OnInit {
  constructor(
    private readonly shopService: ShopService,
    private readonly route: ActivatedRoute,
    private readonly spinner: NgxSpinnerService,
    private readonly toast:ToastrService,
    private readonly cartSerive:CartService
  ) {}
  product: Product;
  quantity:number=1;

  ngOnInit(): void {
    this.GetProduct();
  }

  GetProduct() {
    this.spinner.show();
    this.shopService.getProductDetails(this.route.snapshot.paramMap.get('id'))
      .subscribe({
        next: (value: Product) => {
          this.product = value;
          this.spinner.hide();
        },
        error: () => {
          this.spinner.hide();
        }
      });
  }

  IncrementBasket(){
    if(this.quantity<10){
      this.quantity++;
    }else {
      this.toast.error("You Can't Add More Than 10 Items","ERROR");
    }
    
    
  }

  DecrementBasket(){
    if(this.quantity>1){
      this.quantity--;
      this.toast.warning("Item was Removed","Warning");
    }
    else {
      this.toast.error("The minimum count of Items is 1","WARNING");
    }

  }

  AddToCart(){
    this.cartSerive.addItemtoBasket(this.product,this.quantity);
    this.toast.success("You have Added "+this.quantity+ " items of "+this.product.name,"Success");
  }
}
