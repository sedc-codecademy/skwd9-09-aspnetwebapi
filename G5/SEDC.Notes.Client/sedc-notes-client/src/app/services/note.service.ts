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
        let headers = this.createHeaders(token);

        return this._httpClient.post(url, model, { headers })
    }

    getNotes(token: string) : Observable<any> {
        let url = `${environment.apiServerBaseUrl}api/note/getnotes`;
        let headers = this.createHeaders(token);

        return this._httpClient.get(url, { headers });
    }

    deletNote(id: number, token: string) : Observable<any> {


        let url = `${environment.apiServerBaseUrl}api/note/deletenotebyid?id=${id}`;
        let headers = this.createHeaders(token);

        return this._httpClient.delete(url, { headers })
    }


    private createHeaders(token: string) : HttpHeaders
    {
        return new HttpHeaders({
            'Content-Type' : 'application/json', 
            'Authorization' : `Bearer ${token}`
        })
    }

}