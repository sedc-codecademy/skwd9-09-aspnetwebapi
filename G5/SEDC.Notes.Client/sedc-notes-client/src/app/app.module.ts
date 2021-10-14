import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { NavComponent } from './components/nav-component/nav.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';
import { CreateNoteComponent } from './components/create-note/create-note.component';
import { NoteService } from './services/note.service';
import { GetNotesComponent } from './components/get-notes/get-notes.component';
import { NoteComponent } from './components/note/note.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    CreateNoteComponent,
    GetNotesComponent,
    NoteComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CollapseModule.forRoot(),
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService,
    NoteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
