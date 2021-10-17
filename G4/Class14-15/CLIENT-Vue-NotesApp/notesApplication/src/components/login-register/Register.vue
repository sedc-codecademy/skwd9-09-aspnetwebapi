<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="info">
            <router-link to="/"><b-icon-arrow-left font-scale="3" style="color: white"></b-icon-arrow-left></router-link>
             <div class="col s12 login-container">
                <h3> Register </h3>
            </div>
        </b-navbar>
        <form @submit.prevent="register" class="form">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email address</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"
                v-model="email" required>
                <br>
            </div>
            <div class="mb-3">
                <label for="exampleInputUsername" class="form-label">Username</label>
                <input type="email" class="form-control" id="exampleInputUsername" aria-describedby="usernameHelp"
                v-model="username" required>
                <br>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <input type="password" class="form-control" id="exampleInputPassword1" v-model="password" required>
            </div>
            <br>
            <button type="submit" class="btn btn-primary" @click="register">Register</button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: '',
                username: '',
                password: ''
            }
        },
        computed: {
            users() {
                return this.$store.state.users.users
            }
        },
        methods: {
            register() {
                this.$store.dispatch('register', {
                    email: this.email,
                    username: this.username,
                    password: this.password,
                    userId: this.users.length     
                })
                this.$router.push('/login')
            }
        }
    }
</script>

<style lang="scss">
    .register-form {
        margin-top: 180px;
    }

</style>