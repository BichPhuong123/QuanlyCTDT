<template>
    <div class="content">
        
        <div class="md-layout">


           
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">

                <nav-tabs-card>
                    <template slot="content">

                        <md-tabs class="md-danger" md-alignment="left">
                            <md-tab v-for="(nganh,index) in Nganhs" :md-label="nganh.Tennganh">
                                <form style="float:left" enctype="multipart/form-data" action="/AdminMonhoc/CreateMonhoc">
                                    <input type="number" name="idkh" :value="Khoahoc" style="display:none" />
                                    <input type="text" name="idn" :value="nganh.Manganh" style="display:none" />
                                    <button class="md-button md-danger md-round " type="submit">Thêm môn học</button>
                                </form>
                                    <form style="float:right" method="post" enctype="multipart/form-data" action="/AdminMonhoc/ImportPdf">
                                        <input type="number" name="idkh" :value="Khoahoc" style="display:none" />
                                        <input type="text" name="idn" :value="nganh.Manganh" style="display:none" />
                                        <input type="file" name="postedFile" />
                                        <input type="submit" style="color:white;background-color:black" value="Import Pdf" />
                                    </form>

                                    <div>
                                        <md-icon>search</md-icon>
                                        <input v-on:keyup.enter="submit(nganh.Manganh,index)" v-model="search" class="form-control" name="search"
                                               placeholder="Search" />


                                    </div>

                                    <!--<span v-html="message[index]"></span>-->


                                    <hr />
                                    <div>


                                        <md-table table-header-color="red">
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
                                                    <a :href="'/AdminMonhoc/Edit?mamh='+item.maMh" title="Chỉnh sửa môn học" style="padding-left:10px;"><img src="https://img.icons8.com/material/24/000000/edit--v1.png" /></a>
                                                    <a :href="EditnoidungUrl+'/'+item.maMh" title="Chỉnh sửa nội dung"><md-icon style="color:black">content_paste</md-icon></a>
                                                    <a :href="EditmuctieuUrl+'/'+item.maMh" title="Chỉnh sửa mục tiêu, chuẩn đầu ra" style="padding-left:10px;"><img src="https://img.icons8.com/color/24/000000/goal--v1.png" /></a>
                                                    <button title="Xóa" style="padding-left:10px;background-color:white;border:none" v-on:click="Deletemh(item.maMh)"><img src="https://img.icons8.com/material-rounded/24/000000/filled-trash.png" /></button>
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

    
        import { NavTabsCard } from "../components";
        import axios from 'axios';
    export default {
        name: "adminmonhoc-component",
        components: {
            NavTabsCard,
           
        },
        props: {

            Monhocs: Array,
            Nganhs: Array,
            EditUrl: String,
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
                
            },
            Deletemh(id) {


                if (confirm("Do you want to delete?") == true) {

                    const params = new URLSearchParams();

                    params.append('mamh', id);


                    axios.post('/AdminMonhoc/Delete', params)
                        .then(function (response) {

                            alert("Success");
                            location.href = '/AdminMonhoc/Index';




                        })
                        .catch(function (err) {
                            console.log(err);
                        });
                }
                else {
                    return;
                }

            },
        }
        
    }

        
    
</script>
