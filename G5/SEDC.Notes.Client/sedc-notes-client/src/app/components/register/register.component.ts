import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterRequestModel } from 'src/app/models/auth.models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm = new FormGroup({
    Username: new FormControl('', Validators.required),
    FirstName: new FormControl('', Validators.required),
    LastName: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required),
    ConfirmPassword: new FormControl('', Validators.required),
  })

  constructor(private _authService: AuthService, 
              private _router: Router) {}

  
  onSubmit() {
    let usernameValue = this.registerForm.value.Username;
    let firstName = this.registerForm.value.FirstName;
    let lastName = this.registerForm.value.LastName;
    let password = this.registerForm.value.Password;
    let confirmPassword = this.registerForm.value.ConfirmPassword;

    let registerRequestModel = new RegisterRequestModel(usernameValue, password, confirmPassword, firstName, lastName);

    this._authService.register(registerRequestModel).subscribe({
      next: data => console.log(data),
      error: err => {
        console.warn(err.error)
      },
      complete: () => {
        this._router.navigate(["/login"])
      }
    })

  }



}
