import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  constructor(private service:NgxSpinnerService) { }

  RequestCount=0;

  showLoading(){
    this.service.show(undefined,{
       bdColor : "rgba(0, 0, 0, 0.8)",
      size : "medium",
      color : "#fff",
       type : "ball-grid-beat",
      fullScreen:true

    })
  }

  hideLoading(){
    if(this.RequestCount <= 0){
      this.RequestCount=0;
      this.service.hide();
    }
  }


}
