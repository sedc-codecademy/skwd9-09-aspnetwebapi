import users from '../../data/users';
import jwt_decode from 'jwt-decode';

export default {
    state: {
        users : users,
        currentUser: null,
        isLogged: false,
        userFullname: ''
    },
    getters: {
        isUserLogged: state => state.isLogged,
    },
    mutations: {
        setLoggedUser(state, payload) {
            state.isLogged = true,
            state.currentUser = payload.currentUser,
            state.userFullname = payload.currentUserFullname
            // state.loggedUser = payload.currentUser
            // console.log(state.loggedUser)
        },
        addUser (state, payload) {
            state.users.push(payload);
            // console.log(payload);
            // console.log(state.notes)
        },
        resetUser(state) {
            state.currentUser = null
            state.isLogged = false
        }
    },
    actions: {
        login: async (context, payload) => {
            console.log(users)
            console.log(payload.username)
            const { username, password } = payload;
            const bodyObj = JSON.stringify({
                Username: username,
                Password: password
            })
            // http request to our API
            const data = await fetch('http://localhost:19794/api/users/login', {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: bodyObj
            });
            // let currentUser = users.filter(user => user.email === payload.email && user.password === payload.password)[0]
            const token = await data.text();
            console.log(token)
            // console.log(token.body)
            
    
            // console.log(currentUser)
            if(token) {
                // here we store token in Application tab/Local storage
                localStorage.setItem('token', token);
                // decoding token
                const decoded = jwt_decode(token);
                console.log(decoded.nameid);

                context.commit('setLoggedUser', 
                { 
                    isLogged: true, 
                    currentUser: parseInt(decoded.nameid),
                    currentUserFullname: decoded.userFullName
                })
                return token ? true : false
            }
            
        },
        register: (context, payload) => {
            let newUser = {
                email: payload.email,
                username: payload.username,
                password: payload.password,
                userId: payload.userId + 1
            }
            context.commit('addUser', newUser)
        },
        logOut: (context) => {
            // localStorage.removeItem('token'); // remove only one key
            localStorage.clear(); // remove everything from LS
            context.commit('resetUser')
        }
    },
}

// http://localhost:19794/api/users