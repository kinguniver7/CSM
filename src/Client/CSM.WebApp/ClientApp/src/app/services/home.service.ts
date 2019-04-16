import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getUserHome(): Observable<any> {
    return this.http.get(this.baseUrl + "api/home/testuserrole");
  }

  getAdminHome(): Observable<any> {
    return this.http.get(this.baseUrl + "api/home/testadminrole");
  }

  getHome(): Observable<any> {
    return this.http.get(this.baseUrl + "api/home/get");
  }
}
