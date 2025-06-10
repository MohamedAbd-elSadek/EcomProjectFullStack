import { Component, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements AfterViewInit {
   constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

  // The method is now async to support dynamic import()
 
  ngAfterViewInit(): void {
    // Check if the code is running in a browser environment
    if (isPlatformBrowser(this.platformId)) {
      // Dynamically import Bootstrap and initialize the carousel within the .then() block
      // to keep the ngAfterViewInit signature synchronous.
      import('bootstrap').then(bootstrap => {
        const carouselElement = document.getElementById('carouselExampleCaptions');
        if (carouselElement) {
          new bootstrap.Carousel(carouselElement, {
            interval: 5000, // Set the time between slides (in milliseconds)
            wrap: true      // Whether the carousel should cycle continuously
          });
        }
      }).catch(err => console.error('Bootstrap import failed', err));
    }
  }
    }
  

