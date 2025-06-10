import { Component, AfterViewInit, OnDestroy, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements AfterViewInit, OnDestroy {
  private customCarouselInterval: any;

  constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

  ngAfterViewInit(): void {
    // This check ensures that the code inside only runs in a browser environment,
    // preventing "document is not defined" errors during Server-Side Rendering (SSR).
    if (isPlatformBrowser(this.platformId)) {
      // --- Bootstrap Carousel Initialization ---
      // We dynamically import the Bootstrap library here.
      import('bootstrap').then(bootstrap => {
        const carouselElement = document.getElementById('carouselExampleCaptions');
        if (carouselElement) {
          new bootstrap.Carousel(carouselElement, {
            interval: 5000, // Time between slides in milliseconds
            wrap: true      // Allows the carousel to cycle continuously
          });
        }
      }).catch(err => console.error('Bootstrap dynamic import failed', err));

      this.initializeCustomCarousel();
    }
  }

  initializeCustomCarousel(): void {
    const radioButtons = document.querySelectorAll<HTMLInputElement>('input[name="slides"]');
    if (radioButtons.length > 0) {
      this.customCarouselInterval = setInterval(() => {
        let currentIndex = -1;
        radioButtons.forEach((radio, index) => {
          if (radio.checked) {
            currentIndex = index;
          }
        });

        // Calculate the index of the next slide
        const nextIndex = (currentIndex + 1) % radioButtons.length;
        
        // Check the next radio button to trigger the CSS transition
        radioButtons[nextIndex].checked = true;

      }, 5000); // Change slide every 5 seconds
    }
  }

  ngOnDestroy(): void {
    if (this.customCarouselInterval) {
      clearInterval(this.customCarouselInterval);
    }
  }
}
