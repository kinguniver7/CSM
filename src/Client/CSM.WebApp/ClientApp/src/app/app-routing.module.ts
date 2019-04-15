import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClientsComponent } from './clients/clients.component';
import { ChatComponent } from './chat/chat.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'clients', component: ClientsComponent },
  { path: 'chat', component: ChatComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
