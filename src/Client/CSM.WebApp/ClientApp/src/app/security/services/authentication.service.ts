import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, config } from 'rxjs';
import { map, retry } from 'rxjs/operators';

import * as jwt_decode from 'jwt-decode';

import { User } from 'src/app/models/user';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): any {
    return this.currentUserSubject.value;
  }

  public get currentUserObsrv(): any {
    return this.currentUserSubject;
  }

  public get isAuthorized(): boolean {
    return (localStorage.getItem('currentUser') !== null);
  }

  public get jwtUser(): any {
    return this.currentUserSubject.value && this.currentUserSubject.value.token ? jwt_decode(this.currentUserSubject.value.token):"";
  }

  login(email: string, password: string) {

    return this.http.post<any>(`${this.baseUrl}api/account/login`, { email, password })
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));
  }

  logout(isServer: boolean = false) {
    if (isServer) {
      this.http.post<any>(this.baseUrl + "api/account/LogOff", null).toPromise().then(res => {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
        location.reload(true);
      });

    } else {
      this.currentUserSubject.next(null);
    }
    
    
  }
}
