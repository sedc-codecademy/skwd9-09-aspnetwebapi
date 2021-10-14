import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {

  @Input() note: any

  @Output() emitter = new EventEmitter()

  token: string = ""

  constructor(private _noteService: NoteService,
              private _router: Router) { }

  ngOnInit(): void {
    this.token = localStorage.getItem("token") ?? ""
  }

  deleteNote() {
    this._noteService.deletNote(this.note.id, this.token).subscribe({
      next: data => console.log(data.message),
      error: err => console.warn(err.error),
      complete: () => {
        this.emitter.emit()
      }
    })
  }

}