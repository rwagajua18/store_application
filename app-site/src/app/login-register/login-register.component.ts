import { Component, OnInit } from '@angular/core';
import {LoginRegisterService} from '../services/login-register.service';

@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent implements OnInit {

  user: any = {};

  //inject login-register service in the constructor
  constructor(private loginRegisterService: LoginRegisterService) { }

  ngOnInit(): void {
  }

  login(){
    this.loginRegisterService.login(this.user).subscribe(next =>{
      console.log("logged in succefully");
    }, error => {
      console.log("Failed to login");
    });
  }
    //check if a user is logged in by accessing the token.
    loggedIn(){
      const token = localStorage.getItem("token");
      return !!token;
    }

    //method to logout by removing the token
    logout(){
      localStorage.removeItem('token');
      console.log("logged out")
    }
    
  

}
