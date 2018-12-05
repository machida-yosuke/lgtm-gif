import Vue from 'vue';
import Router from 'vue-router';
import Gallery from './views/Gallery.vue';
import About from './views/About.vue';
import Camera from './views/Camera.vue';

Vue.use(Router);
export default new Router({
  routes: [
    {
      path: '/',
      name: 'gallery',
      component: Gallery,
    },
    {
      path: '/about',
      name: 'about',
      component: About,
    },
    {
      path: '/camera',
      name: 'camera',
      component: Camera,
    },
  ],
});
