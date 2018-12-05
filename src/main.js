import Vue from 'vue';
import VueLazyload from 'vue-lazyload';
import App from './App.vue';
import router from './router';
import store from './store';

Vue.config.productionTip = false;

Vue.use(VueLazyload, {
  preLoad: 1.3,
  error: '/img/error.png',
  loading: '/img/loading.gif',
  attempt: 1,
});

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app');
