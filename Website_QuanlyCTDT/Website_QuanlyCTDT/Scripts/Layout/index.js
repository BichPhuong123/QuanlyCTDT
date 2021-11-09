import Vue from 'vue';
import VueRouter from 'vue-router';
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";
import TopNavbar from "./TopNavbar.vue";
import ContentFooter from "./ContentFooter.vue";
import SideBar from "./SidebarPlugin";
import MobileMenu from "./MobileMenu.vue";


const router = new VueRouter({
    mode: 'history',
    base: '/',
   
    linkExactActiveClass: "nav-item active"
});
Vue.use(VueMaterial)
Vue.use(SideBar)
Vue.use(VueRouter)
document.addEventListener("DOMContentLoaded", function (event) {
    new Vue({
        el: "#main",
        router,
        components: {
            TopNavbar,
            ContentFooter,
            MobileMenu
        },


        data() {

            return {
                currentLink: location.pathname.split('/')[1], 

               // activeItem: 'about',
                sidebarBackground: "green",
                sidebarBackgroundImage: require("./img/sidebar-2.jpg"),
            };


        }
        //,
        //mounted() {
        //    this.setCurrentLink()
        //},
        //methods: {
           
        //    activeClass(segment) {
        //        return segment == this.currentLink ? 'active' : ''
        //    },
        //    setCurrentLink() {
        //        this.currentLink = new URL(location.href).pathname.split('/').pop();
        //    }
        //}
        //methods: {
        //    isActive: function (menuItem) {
        //        console.log(this.activeItem);
        //        return this.activeItem === menuItem
        //    },
        //    setActive: function (menuItem,e) {
        //        this.activeItem = menuItem // no need for Vue.set()
               
        //        var origin = location.origin;
               
        //        var href = e.currentTarget.getAttribute('href');
        //        console.log(this.activeItem);
        //        console.log(origin);
        //        console.log(href);
        //        e.preventDefault();
        //        window.location = origin + href;
               
                
        //    }
        //}

    })
});
