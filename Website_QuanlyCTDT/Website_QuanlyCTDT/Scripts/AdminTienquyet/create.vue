<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="red">
                    <h4 class="title">Chọn môn học</h4>
                
                </md-card-header>
                <md-card-content>
                    <div id="autocomplete" class="autocomplete">
                        <md-icon>search</md-icon>
                        <input v-on:keyup.enter="submit()" v-model="search" class="form-control" name="search"
                               placeholder="Search" />

                    </div>
                    <hr />
                    <div>
                        <form action="/AdminTienquyet/CreateTienquyet">
                            <md-table table-header-color="red">

                                <md-table-row slot="md-table-row">
                                    <md-table-head></md-table-head>
                                    <md-table-head>Mã môn học</md-table-head>
                                    <md-table-head>Tên môn học</md-table-head>

                                </md-table-row>


                                <md-table-row v-for="(mon,index) in Monhocs" slot="md-table-row">
                                    <md-table-cell>

                                        <input type="radio" name="mamh" :value="mon.maMh" />


                                    </md-table-cell>
                                    <md-table-cell>{{mon.maMh}}</md-table-cell>
                                    <md-table-cell>{{mon.ten}}</md-table-cell>

                                </md-table-row>


                            </md-table>
                            <div class="md-layout-item md-size-100 text-right">
                                <button class="md-button md-danger md-round" type="submit">Tiếp theo</button>
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
    import axios from 'axios';
    export default {
        name: "create-component",
  
        props: {
           
            Monhocs: Array,
            SearchUrl: String,
        },
     data() {
            return {
                Monhocs: [],
                search: ''

            }
        },
        methods: {
            submit() {


                var base = this;
                // base.message[index] = '';


                const params = new URLSearchParams();
               
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


                        console.log(response.data)
                        base.Monhocs = response.data;
                        base.search = '';

                        base.$forceUpdate();

                    })
                    .catch(function (err) {
                        console.log(err);
                    });

            }
        }
};
</script>
