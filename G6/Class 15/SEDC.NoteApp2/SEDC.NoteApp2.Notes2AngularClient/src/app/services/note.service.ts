import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { NoteDto } from './../models/note.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(
    private httpClient: HttpClient,
    private userService: UserService) { }

  GetNotesForUser(): Observable<NoteDto> {
    //const userId = 1; // For homework add API method to read this information from token

    const path = environment.apiEndPoint + '/Note/foruser';
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + this.userService.userToken
      })
    }

    return this.httpClient.get<NoteDto>(path, options)
  }
}
