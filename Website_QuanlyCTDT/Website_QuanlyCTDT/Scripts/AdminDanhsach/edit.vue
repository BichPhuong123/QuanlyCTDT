<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="red">
                    <h4 class="title">Sửa danh sách môn học</h4>
                    
                </md-card-header>
                <md-card-content>
                   
                   
                    <div>
                        <form method="post" action="/AdminDanhsach/Edit">
                            <input type="number" name="idk" :value="Khoa" style="display:none" />
                            <input type="text" name="manganh" :value="Nganh" style="display:none" />
                            <md-table table-header-color="red">

                                <md-table-row slot="md-table-row">
                                    <md-table-head></md-table-head>
                                    <md-table-head>Mã môn học</md-table-head>
                                    <md-table-head>Tên môn học</md-table-head>

                                </md-table-row>
                                <md-table-row v-for="item in Monhocs" slot="md-table-row">
                                    <md-table-cell>

                                        <input type="checkbox" name="mamh[]" :value="item.maMh" checked />


                                    </md-table-cell>
                                    <md-table-cell>{{item.maMh}}</md-table-cell>
                                    <md-table-cell>{{item.ten}}</md-table-cell>

                                </md-table-row>

                                <md-table-row v-for="mon in Listmons" slot="md-table-row">
                                    <md-table-cell>

                                        <input type="checkbox" name="mamh[]" :value="mon.maMh" />


                                    </md-table-cell>
                                    <md-table-cell>{{mon.maMh}}</md-table-cell>
                                    <md-table-cell>{{mon.ten}}</md-table-cell>

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
        name: "edit-component",
  
        props: {
            Khoa: Number,
            Nganh: String,
            Monhocs: Array,
            Listmons: Array
        },
     
};
</script>
