import Vue from 'vue';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";


import HomeComponent from './home.vue';
import AboutComponent from './aboutus.vue';

Vue.use(VueMaterial)
new Vue({

    el: "#app",
    components: {
        
        HomeComponent,
        AboutComponent
    }
})

