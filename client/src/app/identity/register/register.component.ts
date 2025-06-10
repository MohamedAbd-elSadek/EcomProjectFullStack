import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IdentityService } from '../identity.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{
FormGroup:FormGroup
constructor(private readonly fb:FormBuilder,
  private service:IdentityService,
  private toast : ToastrService,
  private route:Router
){}
  ngOnInit(): void {
this.formValidation();
  }

formValidation(){
  this.FormGroup=this.fb.group({
    UserName:['',[Validators.required,Validators.minLength(6)]],
    email:['',[Validators.required,Validators.email,]],
    FirstName:['',[Validators.required,Validators.minLength(3)]],
    LastName :['',[Validators.required,Validators.minLength(3)]],
    password :['',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]]
  })
}

get _username() {
    return this.FormGroup.get('UserName');
  }

  get email() {
    return this.FormGroup.get('email');
  }

  get FirstName(){
    return this.FormGroup.get('FirstName');
  }

  get LastName(){
    return this.FormGroup.get('LastName');
  }

  get password(){
    return this.FormGroup.get('password');
  }

  Submit(){
    if(this.FormGroup.valid){
      this.service.register(this.FormGroup.value).subscribe({
        next :(value) => {
          console.log(value);
          this.toast.success("Registeration Success, Please Confirm your email","success".toUpperCase())
          this.route.navigateByUrl('/Account/Login');

        },
        error :(err:any) => {
          console.log(err);
          this.toast.error(err.error,"error".toUpperCase())

        }
      })
    }
  }

}
