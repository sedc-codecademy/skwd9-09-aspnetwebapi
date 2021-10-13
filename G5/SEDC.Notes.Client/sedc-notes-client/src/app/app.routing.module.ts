import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CreateNoteComponent } from "./components/create-note/create-note.component";
import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";

const routes: Routes = [
    {path: 'home', pathMatch: 'full', component: HomeComponent},
    {path: 'register', pathMatch: 'full', component: RegisterComponent},
    {path: 'login', pathMatch: 'full', component: LoginComponent},
    {path: 'create-note', pathMatch: 'full', component: CreateNoteComponent}
    
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}