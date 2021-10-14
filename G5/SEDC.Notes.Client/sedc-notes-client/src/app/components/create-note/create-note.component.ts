import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NoteRequestModel } from 'src/app/models/note.models';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.css']
})
export class CreateNoteComponent implements OnInit {

  token: string = ""

  serverMessage: string = ""

  createNoteForm = new FormGroup({
    Text: new FormControl('', Validators.required),
    Color: new FormControl('', Validators.required),
    TagType: new FormControl('', Validators.required),
  })

  constructor(private _noteService: NoteService, 
              private _router: Router) { }

  ngOnInit(): void {
    let token = localStorage.getItem("token")

    if (!token) {
      this._router.navigate(['/login'])
    }

    this.token = token ?? ""
  }

  onSubmit() {

    let text = this.createNoteForm.value.Text
    let color = this.createNoteForm.value.Color
    let tagType = this.createNoteForm.value.TagType

    let noteRequestModel = new NoteRequestModel(text, color, parseInt(tagType))

    this._noteService.createNote(noteRequestModel, this.token).subscribe({
      next: data => {
        this.serverMessage = data.message;
      },
      error: err => console.warn(err.error)
    })
  }

}
