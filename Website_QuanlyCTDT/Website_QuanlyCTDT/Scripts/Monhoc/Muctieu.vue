<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Mục tiêu</h4>

                    </md-card-header>
                    <md-card-content>
                        <div>

                            <md-table table-header-color="green">

                                <md-table-row slot="md-table-row">
                                    <md-table-head>Mục tiêu</md-table-head>
                                    <md-table-head>Mô tả</md-table-head>
                                </md-table-row>


                                <md-table-row v-for="(item,index) in Muctieu" slot="md-table-row">
                                    <md-table-cell>{{index+1}}</md-table-cell>
                                    <md-table-cell>{{item.Mota}}</md-table-cell>
                                </md-table-row>

                            </md-table>
                        </div>

                    </md-card-content>
                </md-card>

            </div>

            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Chuẩn đầu ra</h4>

                    </md-card-header>
                    <md-card-content>
                        <div>

                            <md-table table-header-color="green">

                                <md-table-row slot="md-table-row">
                                    <md-table-head>Mục tiêu</md-table-head>
                                    <md-table-head>Chuẩn đầu ra</md-table-head>
                                    <md-table-head>Mô tả</md-table-head>
                                </md-table-row>

                               
                                    <md-table-row v-for="(item1,i) in Dauras" slot="md-table-row">
                                        <md-table-cell>{{item1.IdMuctieu+1}}</md-table-cell>
                                        <md-table-cell>{{i+1}}</md-table-cell>
                                        <md-table-cell>{{item1.Mota}}</md-table-cell>
                                    </md-table-row>
                             
                               

                            </md-table>
                        </div>

                    </md-card-content>
                </md-card>

            </div>
        </div>
    </div>
</template>

<script>
    import SimpleTable from "../components";

    export default {
        name: "muctieu-component",
        components: {

            SimpleTable,
        },
        props: {

            Muctieu: Array,
            Dauras:Array
         
        }

    };
</script>
