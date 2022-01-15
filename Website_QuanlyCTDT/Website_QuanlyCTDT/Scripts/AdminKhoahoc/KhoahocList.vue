<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="red">
                    <h4>Khóa học</h4>
                
                </md-card-header>
                <md-card-content>
                    <div>
                        <button id="show-modal" class="md-button md-danger md-round" v-on:click="showModal = true">Thêm khoá học</button>


                        <transition name="modal" v-if="showModal">

                            <div class="modal-mask">
                                <div class="modal-wrapper">
                                    <div class="modal-container">

                                        <div class="modal-header" style="color:red">
                                            <slot name="header">
                                                <h3>Thêm khóa học</h3>
                                            </slot>
                                        </div>

                                        <div class="modal-body">
                                            <slot name="body">
                                                <form method="post" action="/AdminKhoahoc/Create" @submit="checkForm">

                                                    <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                                        <md-field>
                                                            <label>Mã khóa học</label>
                                                            <md-input name="idk" type="number" required min="0" v-model="idk"></md-input>


                                                        </md-field>

                                                    </div>
                                                    <span style="color:red">{{error}} </span>
                                                    <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                                        <md-field>
                                                            <label>Tên khóa học</label>
                                                            <md-input name="Ten" type="text" required v-model="Ten"></md-input>
                                                        </md-field>
                                                    </div>

                                                    <div class="md-layout-item md-size-100 text-right">
                                                        <button class="md-button md-danger md-round" type="submit">Submit</button>

                                                    </div>


                                                </form>
                                            </slot>
                                            <div class="md-layout-item md-size-100 text-right">
                                                <button class="md-button md-success md-round" v-on:click="showModal = false">
                                                    Cancel
                                                </button>

                                            </div>

                                          
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </transition>
                        <transition name="modal" v-if="showModalEdit">

                            <div class="modal-mask">
                                <div class="modal-wrapper">
                                    <div class="modal-container">

                                        <div class="modal-header" style="color:red">
                                            <slot name="header">
                                                <h3>Sửa khóa học</h3>
                                            </slot>
                                        </div>

                                        <div class="modal-body">
                                            <slot name="body">
                                                <form method="post" action="/AdminKhoahoc/Edit" @submit="checkFormEdit">

                                                    <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                                        <md-field>
                                                            <label>Mã khóa học</label>
                                                            <md-input name="khoa" type="number" required min="0" v-model="khoa" disabled></md-input>


                                                        </md-field>

                                                    </div>

                                                    <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                                        <md-field>
                                                            <label>Tên khóa học</label>
                                                            <md-input name="Tenkhoa" type="text" required v-model="Tenkhoa"></md-input>
                                                        </md-field>
                                                    </div>

                                                    <div class="md-layout-item md-size-100 text-right">
                                                        <button class="md-button md-danger md-round" type="submit">Save</button>

                                                    </div>


                                                </form>


                                            </slot>
                                            <div class="md-layout-item md-size-100 text-right">
                                                <button class="md-button md-success md-round" v-on:click="showModalEdit = false">
                                                    Cancel
                                                </button>

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </transition>
                        <md-table table-header-color="red">

                            <md-table-row slot="md-table-row">
                                <md-table-head>Tên khóa học</md-table-head>
                                <md-table-head></md-table-head>
                                <md-table-head></md-table-head>
                            </md-table-row>


                            <md-table-row v-for="item in Khoas" slot="md-table-row">
                                <md-table-cell>{{item.TenKh}}</md-table-cell>
                                <md-table-cell>
                                    <button title="Sửa" style="padding-left:10px;background-color:white;border:none" v-on:click="edit(item.Id,item.TenKh)"><img src="https://img.icons8.com/material/24/000000/edit--v1.png" /></button>
                                   
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
    
    import axios from 'axios';
    export default {
        name: "adminkhoahoc-component",
  
        props: {
           
            Khoas: Array,
           
        },
        data() {
            return {
                idk: '',
                Ten: '',
                khoa: '',
                Tenkhoa: '',

                error: '',
                showModal: false,
                showModalEdit: false

            };
        },
        methods:
        {
            
            checkForm: function (e) {

                e.preventDefault();
                this.errors = [];

                var base = this;


                const params = new URLSearchParams();
                //params.append('idkh', base.Khoahoc);
                //params.append('idn', id);
                params.append('Id', base.idk);
                params.append('TenKh', base.Ten);
               
                axios.post('/AdminKhoahoc/Create', params)
                    .then(function (response) {
                        if (response.data == 1) {
                            alert("Success");
                            location.href = '/AdminKhoahoc/Index';
                           
                        }
                        else {
                            base.error = "Mã khóa học đã tồn tại"
                        }


                    })
                    .catch(function (err) {
                        console.log(err);
                    });

                

            },
            edit(id,ten) {
                var base = this;
                base.showModalEdit = true;
                base.Tenkhoa = ten;
                base.khoa = id;
                
            },
            checkFormEdit: function (e) {

                e.preventDefault();
               
                var base = this;


                const params = new URLSearchParams();
                //params.append('idkh', base.Khoahoc);
                //params.append('idn', id);
                params.append('Id', base.khoa);
                params.append('TenKh', base.Tenkhoa);

                axios.post('/AdminKhoahoc/Edit', params)
                    .then(function (response) {
                       
                            alert("Success");
                            location.href = '/AdminKhoahoc/Index';

                      


                    })
                    .catch(function (err) {
                        console.log(err);
                    });



            },
            Deletekh(id) {

               
                if (confirm("Do you want to delete?") == true) {
                    
                    const params = new URLSearchParams();
                   
                    params.append('Id', id);
                  

                    axios.post('/AdminKhoahoc/Delete', params)
                        .then(function (response) {

                            alert("Success");
                            location.href = '/AdminKhoahoc/Index';




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
    
};
</script>
