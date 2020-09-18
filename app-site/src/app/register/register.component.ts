import { Component, OnInit } from '@angular/core';
import {LoginRegisterService} from '../services/login-register.service';
import { IUserReg } from '../_models/userRegister';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: any = {}

  //injecting LoginRegisterService
  constructor(private loginRegister: LoginRegisterService) { }

  ngOnInit(): void {
  }

  //register method
  register(){
    this.loginRegister.register(this.user).subscribe(() =>{
      console.log('registration successful');
    }, error => {
      console.log(error)
    })
  }

  //method to cancel registration
  cancel(){
    console.log("cancelled")
  }



}
