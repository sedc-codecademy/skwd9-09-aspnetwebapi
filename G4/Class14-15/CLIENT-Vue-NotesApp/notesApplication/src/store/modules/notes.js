import notes from '../../data/notes'

export default {
    state: {
        notes: notes,
        note: null
    },
    getters: {
        notes: (state) => {
            return state.notes
        },
        userId: (state) => {
            return state.users.currentUser
        }
    },
    mutations: {
        setNotes (state, payload) {
            state.notes = payload.notes;
        },
        setNewNote (state, payload) {
            state.notes.push(payload);
            console.log(payload);
            console.log(state.notes)
        },
        detailNote(state, payload) {
            state.note = payload
            console.log(payload)
            console.log(state.note)
        },
        deleteNote(state, payload) {
            state.notes = payload
        },
        updateNotes(state, payload) {
            state.notes = payload
        }
    },
    actions: {
        loadNotes: async ({commit}) => {
            //get token from local storage
            const token = localStorage.getItem('token');
            console.log('token from LS', token);
            // http request to our API
            const data = await fetch('http://localhost:19794/api/notes', {
                method: 'GET',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
            });
            // let currentUser = users.filter(user => user.email === payload.email && user.password === payload.password)[0]
            const notes = await data.json();
            console.log(notes)
            commit('setNotes', { notes });
        },
        addNote: async (context, payload) => {
            // payload = {
            //  text: 'sfdgsgs',
            //  tag: 2   
            // }

            const { text, color, tag } = payload;
            // console.log(context.state.getters.userId)
            const bodyObj = JSON.stringify({
                Text: text,
                Color: color,
                Tag: tag,
                UserId: 1
            });
            console.log(bodyObj);

            //get token from local storage
            const token = localStorage.getItem('token');

            const data = await fetch('http://localhost:19794/api/notes', {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}` // Bearer ajfse84549385rrefhsefr4h85349549rfusrefs
                },
                body: bodyObj
            });
            console.log(data.status)
            return true;
        },
        getNote: (context, payload) => {
            // console.log(payload);
            // console.log(notes)
            let paramId = Number(Object.values(payload))
            let noteDetail = notes.filter(note => note.noteId === paramId)[0]
            // console.log(payload.value);
            // console.log(paramId)
            console.log(noteDetail)
            context.commit('detailNote', noteDetail);
        },
        removeNote: (context, payload) => {
            let newNotes = notes.filter(note => note.noteId !== payload.noteId);
            console.log(newNotes)
            context.commit('deleteNote', newNotes);
        },
        noteEdit: (context, payload) => {
            const noteIndex = notes.findIndex(x => x.noteId === payload.noteId)
            let newNotes = [...notes]
            newNotes[noteIndex] = {
                title: payload.title,
                text: payload.text,
                noteId: payload.noteId,
                userId: payload.userId
            }
            console.log(payload.noteId)
            console.log(noteIndex)
            console.log(newNotes[noteIndex])
            console.log(newNotes)
            context.commit('updateNotes', newNotes);
        }
    }

}