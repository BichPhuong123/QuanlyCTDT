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
                                <input v-on:keyup.enter="submit(nganh.Manganh)" v-model="search" class="form-control"
                                       placeholder="Search"
                                      >

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
                                        <md-table-cell>{{item.MaMh}}</md-table-cell>
                                        <md-table-cell>{{item.Ten}}</md-table-cell>
                                        <md-table-cell>{{item.Sotinchi}}</md-table-cell>
                                        <md-table-cell>{{item.TenCn}}</md-table-cell>
                                        <md-table-cell>
                                            <a :href="DetailsUrl+'/'+item.MaMh" title="Xem chi tiết"><md-icon style="color:black">content_paste</md-icon></a>
                                            <a :href="MuctieuUrl+'/'+item.MaMh" title="Mục tiêu" style="padding-left:10px;"><img src="https://img.icons8.com/color/24/000000/goal--v1.png" /></a>
                                            <a :href="DauraUrl+'/'+item.MaMh" title="Chuẩn đầu ra" style="padding-left:10px;"><img src="https://img.icons8.com/material-two-tone/24/000000/define-location.png" /></a>
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
            MuctieuUrl:String
        },
        data() {
            return {
                Monhocs: [],
                search:''
            }
        },
          
    methods: {
        submit(id) {
            console.log("123");

            var base = this;
            console.log(base.Khoahoc);
            console.log(base.search);
                console.log(id);
                debugger;
                var data = {
                    idkh: base.Khoahoc,
                   idn:id,
                    keyword: base.search
                };
                axios.post(base.SearchUrl,data)
                .then(function (response) {
                  
                    this.Monhocs = response.data;
                })
            }
        },
        mounted() {
            window.addEventListener('keyup', event => {
                if (event.keyCode === 13) {
                    this.submit()
                }
            })
        }

};
</script>
