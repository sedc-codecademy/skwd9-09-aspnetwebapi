<template>
  <div>
      <b-navbar toggleable="lg" type="dark" variant="info">
    <!-- <b-navbar-brand href="#">NavBar</b-navbar-brand> -->

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <router-link to="/dashboard/notes" active-class="active" tag="b-nav-item">My notes</router-link>
        <router-link to="/dashboard/addNote" active-class="active" tag="b-nav-item">Add New Note</router-link>
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <router-link to="/" tag="b-nav-item"><a style="color: white" @click="resetUser" class="link">Log Out</a></router-link>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
  </div>
</template>

<script>
export default {
  methods: {
    resetUser() {
        this.$store.dispatch('logOut')
    }
  }
}
</script>

<style lang="scss" scoped>

</style>