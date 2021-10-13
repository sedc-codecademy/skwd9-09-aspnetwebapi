import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userFullName: string = "username"

  ngOnInit() {
    let userNameFromLocalStorage = localStorage.getItem("fullname")?.toString()
    this.userFullName = userNameFromLocalStorage ?? "username"
  }


}
