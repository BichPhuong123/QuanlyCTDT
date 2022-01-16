import Vue from 'vue';

import AdminkhoahocComponent from './KhoahocList.vue';
import AdminmonhocComponent from './MonhocList.vue';
import CreatemonhocComponent from './create.vue';
import CreatemuctieuComponent from './create_muctieu.vue';
import CreatenoidungComponent from './create_noidung.vue';
import EditComponent from './edit.vue';
import EditmuctieuComponent from './edit_muctieu.vue';
import EditnoidungComponent from './edit_noidung.vue';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial)

new Vue({
    el: "#app",
    components: {
        AdminkhoahocComponent,
        AdminmonhocComponent,
        CreatemonhocComponent,
        CreatemuctieuComponent,
        CreatenoidungComponent,
        EditComponent,
        EditmuctieuComponent,
        EditnoidungComponent
    }
})


