<template>
    <div class="content">
        
        <div class="md-layout">


           
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">

                <nav-tabs-card>
                    <template slot="content">

                        <md-tabs class="md-danger" md-alignment="left">
                            <md-tab v-for="(nganh,index) in Nganhs" :md-label="nganh.Tennganh">
                                <a :href="'/AdminDanhsach/Edit?idk='+Khoahoc+'&manganh='+nganh.Manganh">

                                    Chỉnh sửa danh sách môn học
                                </a>
                                <div>


                                    <md-table table-header-color="red">
                                        <md-table-row slot="md-table-row">
                                            <md-table-head>Mã môn học</md-table-head>
                                            <md-table-head>Tên môn học</md-table-head>
                                            <md-table-head>Số tín chỉ</md-table-head>
                                            <md-table-head>Chuyên ngành</md-table-head>
                                           
                                        </md-table-row>


                                        <md-table-row v-for="item in Monhocs[index]" slot="md-table-row">
                                            <md-table-cell>{{item.maMh}}</md-table-cell>
                                            <md-table-cell>{{item.ten}}</md-table-cell>
                                            <md-table-cell>{{item.sotinchi}}</md-table-cell>
                                            <md-table-cell>{{item.tenCn}}</md-table-cell>
                                           
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
      
    export default {
        name: "adminmonhoc-component",
        components: {
            NavTabsCard,
           
        },
        props: {

            Monhocs: Array,
            Nganhs: Array,

            Khoahoc: Number,
           
        },
       

        
        
    }

        
    
</script>
