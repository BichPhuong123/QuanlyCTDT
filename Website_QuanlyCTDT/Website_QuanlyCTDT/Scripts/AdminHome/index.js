import Vue from 'vue';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

import LoginComponent from './login.vue';

import AdminhomeComponent from './home.vue';

Vue.use(VueMaterial)
new Vue({

    el: "#app",
    components: {
        
        AdminhomeComponent,
        LoginComponent
    }
})

