import Vue from 'vue';
//import VueRouter from 'vue-router';


import SideBar from "./SidebarPlugin";
import TopNavBar from "./TopNavbar.vue";
import ContentFooter from "./ContentFooter.vue";
import VueMaterial from 'vue-material';
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial)



//const router = new VueRouter({
//    mode: 'history',
//    base: '/',
   
//    linkExactActiveClass: "nav-item active"
//});

Vue.use(SideBar)



    new Vue({
        el: "#main",
        
        components: {

            TopNavBar,
            ContentFooter
        },

        data() {

            return {
                currentLink: location.pathname.split('/')[1], 

               // activeItem: 'about',
                sidebarBackground: "green",
                sidebarBackgroundImage: require("./img/sidebar-2.jpg")
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

