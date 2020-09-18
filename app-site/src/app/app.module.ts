import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from '@angular/common/http'

//importing components
import { AppComponent } from './app.component';
import { LoginRegisterComponent } from './login-register/login-register.component';

//importing services
import {LoginRegisterService} from './services/login-register.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [LoginRegisterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
