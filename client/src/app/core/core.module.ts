import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AppModule } from '../app.module';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { loaderInterceptor } from './Interceptor/loader.interceptor';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatBadgeModule} from '@angular/material/badge';



@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatIconModule,
    MatBadgeModule,
    MatButtonModule
  ],
  exports:[NavBarComponent],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useValue: loaderInterceptor,
      multi: true
    }
  ]
})
export class CoreModule { }
