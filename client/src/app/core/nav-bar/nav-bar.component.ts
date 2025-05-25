import { Component, OnInit } from '@angular/core';
import { CartService } from '../../cart/cart.service';
import { log } from 'console';
import { Observable } from 'rxjs';
import { Basket } from '../../shared/Models/Basket';

@Component({
  selector: 'app-nav-bar',
  standalone: false,
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  constructor (private service:CartService){

  }

  ngOnInit(): void {
    const basketId = localStorage.getItem('BasketId');
    this.service.GetBasket(basketId).subscribe({
      next:(value) => {
        console.log(value);
        this.count = this.service.basket$;
        
        
      },
      error:(err) =>{
        console.log(err);
        
      }
    })
  }
navbarOpen = false;
visible = false;

toggleNavbar() {
  this.navbarOpen = !this.navbarOpen;
}

ToggleDropDown() {
  this.visible = !this.visible;
}

count:Observable<Basket>


 
}
