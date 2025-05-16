import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  standalone: false,
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  navbarOpen = false;
visible = false;

toggleNavbar() {
  this.navbarOpen = !this.navbarOpen;
}

ToggleDropDown() {
  this.visible = !this.visible;
}
 
}
