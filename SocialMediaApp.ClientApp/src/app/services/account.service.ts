import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterRequest } from '../interfaces/RegisterRequest';
import { LoginRequest } from '../interfaces/LoginRequest';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private router: Router) { }

  register(request: RegisterRequest) {
    return this.http.post('/api/account/register', request);
  }

  login(request: LoginRequest): Observable<any> {
    return this.http.post('/api/account/login', request).pipe(
      tap((response: any) => {
        if (response.token !== null) {
          localStorage.setItem('auth_token', response.token);
          this.router.navigate(['/home']);
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('auth_token');
    this.router.navigate(['/login']);
  }

  public isLoggedIn() {
    if (localStorage.getItem('auth_token') !== null) {
      return true;
    }
    return false;
  }
}
