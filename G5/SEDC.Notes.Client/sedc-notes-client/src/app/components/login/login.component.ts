import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequestModel } from 'src/app/models/auth.models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm = new FormGroup({
    Username: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required)
  })


  constructor(private _authService: AuthService, 
              private _router: Router) { }

  onSubmit() {
    let username = this.loginForm.value.Username
    let password = this.loginForm.value.Password

    let loginRequestModel = new LoginRequestModel(username, password)

    this._authService.login(loginRequestModel).subscribe({
      next: data => {
        localStorage.setItem("id", data.id)
        localStorage.setItem("fullname", data.fullName)
        localStorage.setItem("token", data.token)

        console.log(data)
      },
      error: err => console.warn(err.error),
      complete: () => {
        this._router.navigate(["/home"])
      }
    })
  }
}
