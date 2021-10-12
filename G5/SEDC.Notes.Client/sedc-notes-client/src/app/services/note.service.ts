import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { NoteRequestModel } from "../models/note.models";

@Injectable()
export class NoteService {

    constructor(private _httpClient: HttpClient) {}

    createNote(model: NoteRequestModel, token: string) : Observable<any> {
        let url = `${environment.apiServerBaseUrl}api/note/createnote`;

        let headers = new HttpHeaders({
            'Content-Type' : 'application/json', 
            'Authorization' : `Bearer ${token}`
        })

        return this._httpClient.post(url, model, { headers })
    }

}