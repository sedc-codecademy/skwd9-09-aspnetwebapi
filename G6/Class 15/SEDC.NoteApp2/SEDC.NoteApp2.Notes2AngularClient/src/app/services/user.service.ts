import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { LoginDto } from '../models/login.model';
import { TokenDto } from '../models/token.model';
import { environment } from './../../environments/environment'
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userToken: string;

  constructor(
    private httpClient: HttpClient,
    private router: Router) { }

  login(loginDto: LoginDto) {
    const path = environment.apiEndPoint + '/User/authenticate';
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

    this.httpClient.post<TokenDto>(path, loginDto, options)
      .subscribe(
        (data: TokenDto) => {
          this.userToken = data.token;
          this.router.navigate(['notes']);
        },
        (error) => {
          console.log(error);
        });
  }
}
