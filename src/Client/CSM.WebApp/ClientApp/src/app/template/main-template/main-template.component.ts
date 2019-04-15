import { Component, OnInit, OnDestroy, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/security/services/authentication.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-main-template',
  templateUrl: './main-template.component.html',
  styleUrls: ['./main-template.component.scss']
})
export class MainTemplateComponent implements OnInit, OnDestroy {
  //private
  private subscription: Subscription;

  //public
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
  userLogin: string;
  isAuthorized: boolean = false;

  @ViewChild('drawer') sidenav: any;

  constructor(private breakpointObserver: BreakpointObserver, private service: AuthenticationService) {    
  }
  
  ngOnInit() {
    this.subscription =  this.service.currentUser.subscribe((value) => {
      if (value && !this.isAuthorized) {
        this.relogin();
      }
    });
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  toggleSidenav() {
    this.sidenav.toggle();
  }

  relogin() {
    this.userLogin = this.service.jwtUser.sub;
    this.isAuthorized = this.service.isAuthorized;
  }


  logOut() {
    this.service.logout(true);
  }

}
