import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};

  constructor() { }

  ngOnInit(): void {
  }

  //register method
  register(){
    console.log(this.model);
  }

  //method to cancel registration
  cancel(){
    console.log("cancelled")
  }



}
