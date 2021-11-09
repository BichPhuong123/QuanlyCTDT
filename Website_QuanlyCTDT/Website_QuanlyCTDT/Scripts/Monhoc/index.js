import Vue from 'vue';
import KhoahocComponent from './KhoahocList.vue';
import MonhocComponent from './MonhocList.vue';
import DetailComponent from './Detail.vue';
import MuctieuComponent from './Muctieu.vue';
new Vue({
    el: "#app",
    components: {
        KhoahocComponent,
        MonhocComponent,
        DetailComponent,
        MuctieuComponent
    }
})