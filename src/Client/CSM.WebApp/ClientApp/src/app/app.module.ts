import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ClientsComponent } from './clients/clients.component';
import { ChatComponent } from './chat/chat.component';
import { MainTemplateComponent } from './template/main-template/main-template.component';

import { MaterialModule } from './shared/material.module';
import { FaModule } from './shared/fa.module';
import { LoginComponent } from './security/login/login.component';
import { JwtInterceptor } from './security/interceptors/jwt.interceptor';
import { ErrorInterceptor } from './security/interceptors/error.interceptor';
import { SignupComponent } from './security/signup/signup.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientsComponent,
    ChatComponent,
    LoginComponent,
    MainTemplateComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    MaterialModule,
    FaModule,
    FormsModule,
    ReactiveFormsModule
  ], 
  providers: [
   {
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptor,    
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true,
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
