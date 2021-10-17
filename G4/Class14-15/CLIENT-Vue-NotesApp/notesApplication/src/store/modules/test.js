export default {
    state: {
      userUrl: false,
    },
  
    getters: {
      getUserUrl: state => state.userUrl,
    },
  
    mutations: {
      setUserUrl(state, payload) {
        state.userUrl = payload.url
      },
    },
  
    actions: {
      getUserUrl (context, payload) {
        console.log(payload.url)
        context.commit('setUserUrl', { url: payload.url })
      }
    }
  }