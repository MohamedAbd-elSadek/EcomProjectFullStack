import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../enviroment/enviroment';
import { ActiveAccount } from '../shared/Models/ActiveAccount';
import { ResetPassword } from '../shared/Models/ResetPassword';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private http:HttpClient) { }
  baseURL = environment.apiUrl;

  register(form:any){
    return this.http.post(this.baseURL+"/user/register",form);
  }

  active(param:ActiveAccount){
    return this.http.post(this.baseURL+"/user/active-account",param)
  }

  login(form:any){
    return this.http.post(this.baseURL+"/user/login",form)
  }
  forgetPassword(email:string){
    return this.http.get(this.baseURL+"/user/forget-password?email="+email)
  }

  ResetPassword(param: ResetPassword) {
  // Tell HttpClient to expect a plain text response
  return this.http.post(this.baseURL + "/user/reset-password", param, { 
    responseType: 'text' 
  });
}
}
