<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="green">
                    <h4 class="title">Môn học tiên quyết</h4>
                
                </md-card-header>
                <md-card-content>
                    <div>
                      
                        <md-table  table-header-color="green">
                           
                            <md-table-row slot="md-table-row">
                                <md-table-head>Mã môn học</md-table-head>
                                <md-table-head>Tên môn học</md-table-head>
                                <md-table-head>Môn học tiên quyết</md-table-head>
                            </md-table-row>
                          
                          
                            <md-table-row v-for="(mon,index) in Monhocs" slot="md-table-row">
                                <md-table-cell>{{mon.maMH}}</md-table-cell>
                                <md-table-cell>{{mon.ten}}</md-table-cell>
                                <md-table-cell>
                                <md-table-row v-for="item in Mhtqs[index]">
                                    <a :href="TienquyetUrl+'/'+item.maMHTQ" style="color:black">{{item.maMHTQ}} &ensp;</a>
</md-table-row>
                                </md-table-cell>
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

    export default {
        name: "tienquyet-component",
  
        props: {
           
            Monhocs: Array,
            Mhtqs: Array,
            TienquyetUrl: String
        }
    
};
</script>
