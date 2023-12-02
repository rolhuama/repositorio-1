import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserResponse } from '../models/auth/user-response.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private data: UserResponse;

  private userSubject = new BehaviorSubject<any>(null)
  user$ = this.userSubject.asObservable();
  private isAuthenticated = new BehaviorSubject<boolean>(false);

  constructor() {
    // Recuperar los datos del almacenamiento local al iniciar el servicio
    const storedData = localStorage.getItem('currentUser');
    this.data = storedData ? JSON.parse(storedData) : null;

    if (this.data) {
      this.userSubject.next(this.data);
    }

    this.isAuthenticated.next(!!localStorage.getItem('currentUser'));

  }

  setUser(user: any) {

    if (user.picture=="") {
      user.picture=null
    }

    localStorage.setItem('currentUser', JSON.stringify(user))
    localStorage.setItem('tokenExpires', JSON.stringify(user.tokenExpires))    
    this.data =user
    this.userSubject.next(user)
    this.isAuthenticated.next(true);
  }

  getUser() {
    return this.data
  }

  clearUser() {
    this.isAuthenticated.next(false);
    localStorage.removeItem('currentUser')
    localStorage.removeItem('tokenExpires')
    this.userSubject.next(null)
  }

  clearAll() {
    this.isAuthenticated.next(false);
    localStorage.clear()
  }

  isAuthenticatedUser(): Observable<boolean> {
    return this.isAuthenticated;
  }


}
