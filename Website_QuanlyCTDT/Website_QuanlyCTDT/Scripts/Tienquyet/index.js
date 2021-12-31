import Vue from 'vue';
import TienquyetComponent from './TienquyetList.vue';
import DetailComponent from './Detail.vue';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial)
new Vue({
    el: "#app",
    components: {
        TienquyetComponent,
        DetailComponent 
    }
})