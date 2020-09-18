import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginRegisterService {
  //base Url
  private baseUrl: string =  'http://localhost:5000/api/customer/login';



  //inject HttpClientModule in the constructor
  constructor(private http: HttpClient) { }

  //login method. This method returns a token
  login(user: any): Observable<any>{
    return this.http.post(this.baseUrl, user)
           .pipe(
             map((response: any) => {
               const model = response;
               if(model) {
                 localStorage.setItem('token', model.token); //set the token to the local storage.
               }

             })

           );    

  }

}
