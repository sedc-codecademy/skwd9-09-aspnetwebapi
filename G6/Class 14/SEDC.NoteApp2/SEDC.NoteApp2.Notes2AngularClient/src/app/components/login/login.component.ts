import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginDto } from 'src/app/models/login.model';
import { TokenDto } from 'src/app/models/token.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  userLoginSubmit() {
    let loginDto = new LoginDto();
    loginDto.username = this.loginForm.value.username;
    loginDto.password = this.loginForm.value.password;

    this.userService.login(loginDto)
      .subscribe(
        (data: TokenDto) => {
          console.log("UserToken: ", data);
        },
        (error) => {
          console.log(error);
        })
  }
}
