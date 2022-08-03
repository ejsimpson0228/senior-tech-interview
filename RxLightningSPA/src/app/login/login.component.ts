import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  error: string | null = null;
  isLoading = false;
  loginForm = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required])
  })

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.isLoading = true;
    this.authService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe(
      (response: any) => {
        localStorage.setItem('Bearer', response.bearer);
        this.router.navigateByUrl('/patients');
      },
      error => {
        if (error.status === 401) {
          this.error = 'Invalid credentials';
        } else {
          this.error = 'There was an error logging you in';
        }
        this.loginForm.reset();
        this.isLoading = false;
      }
    );
  }

}
