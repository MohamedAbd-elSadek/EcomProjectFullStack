import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AppModule } from '../app.module';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { loaderInterceptor } from './Interceptor/loader.interceptor';



@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule
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
