import Home from './components/Home.vue'
import Login from './components/login-register/Login.vue'
import Register from './components/login-register/Register.vue'
import Dashboard from './components/Dashboard.vue'
import NewNote from './components/notes/NewNote.vue'
import Notes from './components/notes/Notes.vue'
import NoteDetail from './components/notes/NoteDetail.vue'
import EditNote from './components/notes/EditNote.vue'


export const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },
    { path: '/register', component: Register},
    { path: '/dashboard', component: Dashboard, children: [
        { path: 'notes', component: Notes },
        { path: 'addNote', component: NewNote },
        { path: 'noteDetail/:id', component: NoteDetail},
        { path: 'editNote', component: EditNote}
    ]}
]