import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { UserLogin } from '../_models/userLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  loginUrl = environment.APIBaseUrl + 'login';

  constructor(private http: HttpClient, private router: Router) { }

  login(email: string, password: string) {
    let userLogin = new UserLogin(email, password);
    return this.http.post(this.loginUrl, userLogin);
  }

  logout() {
    this.router.navigate(['']);
    localStorage.removeItem('Bearer');
  }
}
