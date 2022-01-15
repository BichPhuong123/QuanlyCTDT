import Vue from 'vue';

import AdminkhoahocComponent from './KhoahocList.vue';

import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial)

new Vue({
    el: "#app",
    components: {
        AdminkhoahocComponent,
      
    }
})


