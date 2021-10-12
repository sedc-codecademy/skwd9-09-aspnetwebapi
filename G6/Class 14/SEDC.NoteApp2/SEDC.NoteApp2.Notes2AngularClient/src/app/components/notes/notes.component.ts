import { Component, OnInit } from '@angular/core';
import { NoteService } from 'src/app/services/note.service';
import { NoteDto } from './../../models/note.model';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {

  notesForUser: NoteDto[] = []

  constructor(
    private notesService: NoteService) { }

  ngOnInit(): void {
    this.notesService.GetNotesForUser().subscribe(
      (data: any) => {
        data.forEach((item: NoteDto) => {
          let noteDto = new NoteDto();

          noteDto.id = item.id;
          noteDto.text = item.text;
          noteDto.color = item.color;
          noteDto.tag = item.tag;
          noteDto.userId = item.userId;
          noteDto.userFullName = item.userFullName;

          this.notesForUser.push(noteDto);
        });
      }
    )
  }

}
