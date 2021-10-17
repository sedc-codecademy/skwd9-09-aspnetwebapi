import Vue from 'vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import { routes } from './routes'
import store from './store/store'

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)


Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes
})

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})

// new Vue({
//   router,
//   store,
//   render: h => h(App),
// }).$mount('#app')
