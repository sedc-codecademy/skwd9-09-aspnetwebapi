import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { LoginDto } from '../models/login.model';
import { TokenDto } from '../models/token.model';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  login(loginDto: LoginDto): Observable<TokenDto> {
    const path = environment.apiEndPoint + '/User/authenticate';
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

    return this.httpClient.post<TokenDto>(path, loginDto, options);
  }
}
