import Vue from 'vue';
import Vuex from 'vuex';

import notes from './modules/notes'
import users from './modules/users'
import test from './modules/test'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        notes,
        users,
        test
    }
})