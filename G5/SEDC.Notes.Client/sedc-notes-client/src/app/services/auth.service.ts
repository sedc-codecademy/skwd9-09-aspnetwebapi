import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { LoginRequestModel, RegisterRequestModel } from "../models/auth.models";

@Injectable()
export class AuthService {

    constructor(private _httpClient: HttpClient) {}

    register(model: RegisterRequestModel) : Observable<any> {

        let url = `${environment.apiServerBaseUrl}api/user/register`;
        return this._httpClient.post(url, model)
    }

    login(model: LoginRequestModel) : Observable<any> {
        let url = `${environment.apiServerBaseUrl}api/user/authenticate`;
        return this._httpClient.post(url, model)
    } 


}