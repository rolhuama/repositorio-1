import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GoogleResponse } from '../models/auth/google-response.model';
import { UserResponse } from '../models/auth/user-response.model';
import { UserRequest } from '../models/auth/user-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = environment.app.apiUrl;
  private header = new HttpHeaders().set('Content-Type', 'application/json')


  constructor(
    private http: HttpClient
  ) {

   }
  
  login(request: UserRequest){
    

    return this.http.post<UserResponse>(this.apiUrl + `auth/LoginUser`, request,{headers: this.header, withCredentials:true });
  }

  loginGoogle(request: GoogleResponse){

    return this.http.post<UserResponse>(this.apiUrl + `auth/logingoogle`, request,{headers: this.header, withCredentials:true });
  }



}
