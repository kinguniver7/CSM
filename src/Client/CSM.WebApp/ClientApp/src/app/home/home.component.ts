import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home.service';
import { AuthenticationService } from '../security/services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private service: AuthenticationService) { }

  ngOnInit() {
    
    //this.service.getHome(401).subscribe((res) => {
    //  console.log(res);
    //});
  }

}
