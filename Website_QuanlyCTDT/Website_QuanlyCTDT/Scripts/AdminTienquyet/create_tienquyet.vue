<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="red">
                    <h4 class="title">Chọn môn học tiên quyết</h4>
                    <h4 class="title">{{Mamh}}</h4>
                </md-card-header>
                <md-card-content>
                   
                   
                    <div>
                        <form method="post" action="/AdminTienquyet/CreateTienquyet">
                            <input type="text" name="monhoc" :value="Mamh" style="display:none" />
                            <md-table table-header-color="red">

                                <md-table-row slot="md-table-row">
                                    <md-table-head></md-table-head>
                                    <md-table-head>Mã môn học</md-table-head>
                                    <md-table-head>Tên môn học</md-table-head>

                                </md-table-row>


                                <md-table-row v-for="(mon,index) in Monhocs" slot="md-table-row">
                                    <md-table-cell>

                                        <input type="checkbox" name="mamh[]" :value="mon.MaMh" />


                                    </md-table-cell>
                                    <md-table-cell>{{mon.MaMh}}</md-table-cell>
                                    <md-table-cell>{{mon.Ten}}</md-table-cell>

                                </md-table-row>


                            </md-table>
                            <div class="md-layout-item md-size-100 text-right">
                                <button class="md-button md-danger md-round" type="submit">Submit</button>
                            </div>
                        </form>
                    </div>

                </md-card-content>
            </md-card>
           
        </div>

     
    </div>
  </div>
</template>

<script>
 
    export default {
        name: "createtienquyet-component",
  
        props: {
           
            Mamh: String,
           Monhocs: Array,
        },
     
};
</script>
