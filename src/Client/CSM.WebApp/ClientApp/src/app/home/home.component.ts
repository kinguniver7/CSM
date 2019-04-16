import { Component, OnInit } from '@angular/core';
import { HomeService } from '../services/home.service';
import { AuthenticationService } from '../security/services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private service: HomeService, private authService: AuthenticationService) { }

  ngOnInit() {

    //console.log(this.authService.jwtUser);
    
    //this.service.getUserHome().subscribe((res) => {
    //  console.log(res);
    //});

    //this.service.getAdminHome().subscribe((res) => {
    //  console.log(res);
    //});

    //this.service.getHome().subscribe((res) => {
    //  console.log(res);
    //});
  }

}
