<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="info">
            <div class="col s12 login-container">
                <h3> NotesApp</h3>
            </div>
        </b-navbar>
        <div class="middleHome">
            <h1>Welcome to NotesApp</h1>
            <img alt="Vue logo" src="../assets/notesLogo.png" class="logo">
        </div>
        <div class="footerContainer">
            <div class="footerBtns">
                <router-link to="/login" class="btn btn-info">Login</router-link>
                <router-link to="/register" class="btn btn-primary">Register</router-link>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
    .middleHome {
        margin-top: 100px;

        h1 {
            margin-bottom: 60px;
        }
    }

    .footerContainer {
        display: flex;
        justify-content: center;

        .footerBtns {
            width: 300px;
            margin-top: 150px;
            display: flex;
            justify-content: space-around;

            .btn {
                width: 120px;
            }
        }

    }
    
    .logo {
        width: 200px;
    }

</style>