import { Component, OnInit } from '@angular/core';
import {ResetPassword} from "../../shared/Models/ResetPassword"
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IdentityService } from '../identity.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reset-password',
  standalone: false,
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.css'
})
export class ResetPasswordComponent implements OnInit {
  ResetValue = new ResetPassword();
  formGroup:FormGroup

  constructor(private readonly  router:ActivatedRoute,
    private readonly fb:FormBuilder,
    private readonly  service:IdentityService,
    private readonly  route:Router,
    private readonly  toast : ToastrService
  ){}
ngOnInit(): void {
  this.router.queryParams.subscribe(param=>{
    this.ResetValue.email=param['email'];
    this.ResetValue.token=param['code'];
  });

  this.FormValidation();
}

FormValidation(){
  this.formGroup=this.fb.group({
    password:['',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]],
    confirmPassword:['',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]],
    
  },
  {validator:this.PasswordMatchValidation}
)
}

get password(){
    return this.formGroup.get('password');
  }
  get confirmPassword(){
    return this.formGroup.get('confirmPassword');
  }

  PasswordMatchValidation(form:FormGroup){
    const passwordControl = form.get('password');
    const confirmPasswordControl = form.get('confirmPassword');
    if (passwordControl.value === confirmPasswordControl.value ){
      confirmPasswordControl.setErrors(null);
    }else{
      confirmPasswordControl.setErrors({passwordMisMatch:true});
    }
  }

  Submit(){
    if (this.formGroup.valid){
      this.ResetValue.password=this.formGroup.value.password;
      this.service.ResetPassword(this.ResetValue).subscribe({
        next:(value) =>{
          this.toast.success("Password Reset Sucess","Success")
          this.route.navigateByUrl("/Account/Login")
        },
        error :(err) =>{
          console.log(err);
          this.toast.error(err.error.text,"Error")
        }
      })
    }
  }

}
