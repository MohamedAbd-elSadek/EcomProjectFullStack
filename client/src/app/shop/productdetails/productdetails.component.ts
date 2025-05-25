import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from '../../shared/Models/Product';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-productdetails',
  standalone: false,
  templateUrl: './productdetails.component.html',
  styleUrl: './productdetails.component.css'
})
export class ProductdetailsComponent implements OnInit {
  constructor(
    private readonly shopService: ShopService,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService
  ) {}
  product: Product;

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
}
