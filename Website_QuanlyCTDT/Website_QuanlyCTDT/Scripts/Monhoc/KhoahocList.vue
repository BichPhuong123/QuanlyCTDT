<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="green">
                    <h4 class="title">Khóa học</h4>
                
                </md-card-header>
                <md-card-content>
                    <div>
                      
                        <md-table  table-header-color="green">
                           
                                <md-table-row slot="md-table-row">
                                    <md-table-head>Tên khóa học</md-table-head>

                                </md-table-row>
                          
                          
                                <md-table-row v-for="item in Khoas" slot="md-table-row">
                                    <md-table-cell>{{item.TenKh}}</md-table-cell>
                                    <md-table-cell><a :href="MonhocUrl+'/'+item.Id" khoahoc="item.Id" title="Danh sách môn học"><md-icon style="color:black">list</md-icon></a></md-table-cell>
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
        name: "khoahoc-component",
  
        props: {
           
            Khoas: Array,
            MonhocUrl: String
        }
    
};
</script>
