<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">

            <nav-tabs-card>
                <template slot="content">

                    <md-tabs class="md-success" md-alignment="left">
                        <md-tab v-for="(nganh,index) in Nganhs" :md-label="nganh.Tennganh">
                            <div id="autocomplete" class="autocomplete">
                                <md-icon>search</md-icon>
                                <input v-on:keyup.enter="submit(nganh.Manganh,index)" v-model="search" class="form-control" name="search"
                                       placeholder="Search"/>
                              
                                <!--<span v-html="message[index]"></span>-->
                            </div>
                           
                            <hr />
                            <div>


                                <md-table table-header-color="green">
                                    <md-table-row slot="md-table-row">
                                        <md-table-head>Mã môn học</md-table-head>
                                        <md-table-head>Tên môn học</md-table-head>
                                        <md-table-head>Số tín chỉ</md-table-head>
                                        <md-table-head>Chuyên ngành</md-table-head>
                                        <md-table-head></md-table-head>
                                    </md-table-row>


                                    <md-table-row v-for="item in Monhocs[index]" slot="md-table-row">
                                        <md-table-cell>{{item.maMh}}</md-table-cell>
                                        <md-table-cell>{{item.ten}}</md-table-cell>
                                        <md-table-cell>{{item.sotinchi}}</md-table-cell>
                                        <md-table-cell>{{item.tenCn}}</md-table-cell>
                                        <md-table-cell>
                                            <a :href="DetailsUrl+'/'+item.maMh" title="Xem chi tiết"><md-icon style="color:black">content_paste</md-icon></a>
                                            <a :href="MuctieuUrl+'/'+item.maMh" title="Mục tiêu" style="padding-left:10px;"><img src="https://img.icons8.com/color/24/000000/goal--v1.png" /></a>
                                           
                                        </md-table-cell>
                                    </md-table-row>

                                </md-table>
                            </div>

                            <!--<simple-table table-header-color="green"></simple-table>-->

                        </md-tab>


                        <!--<md-tab id="tab-pages" md-label="Website" md-icon="code">
                    <simple-table table-header-color="green"></simple-table>
                </md-tab>

                <md-tab id="tab-posts" md-label="server" md-icon="cloud">
                    <simple-table table-header-color="green"></simple-table>
                </md-tab>-->
                    </md-tabs>
                </template>
            </nav-tabs-card>
        </div>

     
    </div>
  </div>
</template>

<script>

    
        import { SimpleTable, NavTabsCard } from "../components";
        import axios from 'axios';
    export default {
        name: "monhoc-component",
        components: {
            NavTabsCard,
            SimpleTable,
        },
        props: {

            Monhocs: Array,
            Nganhs: Array,
            DetailsUrl: String,
            Khoahoc: Number,
            SearchUrl: String,
            MuctieuUrl: String
        },
        data() {
            return {
               Monhocs:[],
                search: ''
                
            }
        },

        methods: {
            submit(id,index) {


                var base = this;
               // base.message[index] = '';
               
             
                const params = new URLSearchParams();
                params.append('idkh', base.Khoahoc);
                params.append('idn', id);
                params.append('keyword', base.search);
              
                //new Promise(function (resolve, reject) {
                //    axios.get(base.SearchUrl, data)
                //        .then(function (res) {
                //            this.Monhocs = res.data;
                //        })
                //        .catch(function (err) {
                //            console.log(err);
                //        });
                //});
                axios.post(base.SearchUrl, params)
                    .then(function (response) {
                       
                       
                     
                        base.Monhocs[index] = response.data;
                        base.search = '';
                     
                          base.$forceUpdate();   
                     
                    })
                    .catch(function (err) {
                            console.log(err);
                    });
                
            }
        }
        
    }

        
    
</script>
