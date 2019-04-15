import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ClientsComponent } from './clients/clients.component';
import { ChatComponent } from './chat/chat.component';
import { NavComponent } from './nav/nav.component';
import { NavigationBarComponent } from './template/navigation-bar/navigation-bar.component';

import { MaterialModule } from './shared/material.module';
import { FaModule } from './shared/fa.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientsComponent,
    ChatComponent,
    NavComponent,
    NavigationBarComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    MaterialModule,
    FaModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
