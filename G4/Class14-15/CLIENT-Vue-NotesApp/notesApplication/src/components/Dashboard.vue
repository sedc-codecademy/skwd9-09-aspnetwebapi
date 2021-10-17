<template>
    <div>
        <h1 v-if="userLogged">Welcome {{ userFullName }}</h1>
        <h1>Here's our notes app!</h1>
        <app-header></app-header>
  
        <router-view class="content"></router-view>
    </div>
</template>

<script>
    import Header from './Header.vue'
    import jwt_decode from 'jwt-decode'

    export default {
        components: {
            appHeader: Header
        },
        computed: {
            userLogged() {
                const token = localStorage.getItem('token')
                return token ? true :false;
            },
            userFullName() {
                const token = localStorage.getItem('token')
                const decoded = jwt_decode(token);
                console.log(decoded.nameid);
                return decoded.userFullName
            }
        },
        created() {
            this.$store.dispatch('loadNotes');
            const token = localStorage.getItem('token')
                if (!token) {
                    this.$router.push('/');
                }
        }
    }
</script>

<style lang="scss">
    .content {
        margin-top: 100px;
    }

</style>