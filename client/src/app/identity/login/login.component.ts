import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IdentityService } from '../identity.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

formGroup:FormGroup;
emailModel:string ='';

constructor(private fb:FormBuilder,
  private service:IdentityService,
  private toast:ToastrService,
  private route:Router
){}
  ngOnInit(): void {
this.FormValidation();
  }

FormValidation(){
  this.formGroup=this.fb.group({
    email:['',[Validators.required,Validators.email]],
    password :['',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]]
  })
}

get email() {
    return this.formGroup.get('email');
  }

  

  get password(){
    return this.formGroup.get('password');
  }

  Login(){
    if(this.formGroup.valid){
this.service.login(this.formGroup.value).subscribe({
      next:(value) =>{
        console.log(value);
        this.toast.success("Login Succeed","Sucess");
        this.route.navigateByUrl("/")
      },
      error:(err) =>{
        console.log(err);
        this.toast.error(err.error.detail,"Error");
      }
    })
    }
    
  }

  SendEmailForgetPassword(){
    this.service.forgetPassword(this.emailModel).subscribe({
      next : (value) =>{
        console.log(value);
        this.toast.success("Email Sent Successfully","Success");
        
      },
      error :(err) =>{
        console.log(err);
        this.toast.error("Something went wrong","Error");
      }
    })
  }

}
