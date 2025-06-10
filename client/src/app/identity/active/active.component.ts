import { AfterViewInit, Component } from '@angular/core';
import { ActiveAccount } from '../../shared/Models/ActiveAccount';
import { ActivatedRoute } from '@angular/router';
import { IdentityService } from '../identity.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-active',
  standalone: false,
  templateUrl: './active.component.html',
  styleUrl: './active.component.css'
})
export class ActiveComponent implements AfterViewInit{
activeParam = new ActiveAccount();

constructor(private router:ActivatedRoute,
  private service:IdentityService,
  private toast:ToastrService,
  private route:Router
){}
  ngAfterViewInit(): void {
this.router.queryParams.subscribe(param=>{
  this.activeParam.email=param['email'];
  this.activeParam.token=param['code'];
})
this.service.active(this.activeParam).subscribe({
  next:(value)=>{
    console.log(value);
    this.toast.success("Your account is activated","SUCCESS");
    this.route.navigateByUrl('/Account/Login');
  },
  error:(err)=>{
    console.log(err);
    this.toast.error("Your account is not activated , validation expired","ERROR")
  }
})
  }
}
