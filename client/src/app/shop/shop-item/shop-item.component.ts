import { Component, Input } from '@angular/core';
import { Product } from '../../shared/Models/Product';

@Component({
  selector: 'app-shop-item',
  standalone: false,
  templateUrl: './shop-item.component.html',
  styleUrl: './shop-item.component.css'
})
export class ShopItemComponent {
  @Input() Product: Product;
  isPhotoExpanded = false;
}
