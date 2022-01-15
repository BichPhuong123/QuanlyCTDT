import Vue from 'vue';
import AdmintienquyetComponent from './TienquyetList.vue';
import CreateComponent from './create.vue';
import EditComponent from './edit.vue';
import CreatetienquyetComponent from './create_tienquyet.vue';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial)
new Vue({
    el: "#app",
    components: {
        AdmintienquyetComponent,
        CreateComponent,
        CreatetienquyetComponent,
        EditComponent
    }
})