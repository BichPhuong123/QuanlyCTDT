import Vue from 'vue';
import HomeComponent from './home.vue';
import AboutComponent from './aboutus.vue';

new Vue({
    el: "#app",
    components: {
        HomeComponent,
        AboutComponent
    }
})