<template>
    <div class="content">
       
        <div class="md-layout">
            <div class="md-layout-item">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Chi tiết môn học</h4>
                        <button type="button" style="color:white;background-color:black" v-on:click="getData(Monhoc.MaMh)">Export PDF</button>
                    </md-card-header>
                    <md-card-content>
                        <div id="typography">

                            <div class="row">

                                <h5>
                                    <b>Mã môn học:</b> {{Monhoc.MaMh}}
                                </h5>


                                <h5>
                                    <b>Tên môn học:</b> {{Monhoc.Ten}}
                                </h5>


                                <h5>
                                    <b>Số tín chỉ:</b> {{Monhoc.Sotinchi}}
                                </h5>


                                <h5>
                                    <b>Mô tả môn học:</b>
                                </h5>

                                <p>
                                    {{Monhoc.Mota}}
                                </p>

                                <!--<div class="tim-typo">
                                <span class="tim-note">Quote</span>
                                <blockquote>
                                    <p>
                                        I will be the leader of a company that ends up being worth
                                        billions of dollars, because I got the answers. I
                                        understand culture. I am the nucleus. I think that’s a
                                        responsibility that I have, to push possibilities, to show
                                        people, this is the level that things could be at.
                                    </p>
                                    <small> Kanye West, Musician </small>
                                </blockquote>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Muted Text</span>
                                <p class="text-muted">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Primary Text</span>
                                <p class="text-primary">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Info Text</span>
                                <p class="text-info">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Success Text</span>
                                <p class="text-success">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Warning Text</span>
                                <p class="text-warning">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <span class="tim-note">Danger Text</span>
                                <p class="text-danger">
                                    I will be the leader of a company that ends up being worth
                                    billions of dollars, because I got the answers...
                                </p>
                            </div>
                            <div class="tim-typo">
                                <h2>
                                    <span class="tim-note">Small Tag</span>
                                    Header with small subtitle
                                    <br />
                                    <small>Use "small" tag for the headers</small>
                                </h2>
                            </div>-->
                            </div>
                        </div>
                        <md-table table-header-color="green">

                            <md-table-row slot="md-table-row">
                                <md-table-head>Tuần</md-table-head>
                                <md-table-head>Chương</md-table-head>
                                <md-table-head>Nội dung</md-table-head>
                                <md-table-head></md-table-head>
                            </md-table-row>


                            <md-table-row v-for="(chuong,index) in Chuongs" slot="md-table-row">
                                <md-table-cell>{{chuong.IdTuan}}</md-table-cell>
                                <md-table-cell><b>{{chuong.Ten}}</b></md-table-cell>
                                <md-table-cell>

                                    <b>Nội dung ở nhà</b>  <br />
                                    <!--<md-table-row v-for="lop in Phanconglops[index]">-->
                                    <div v-for="nha in Phancongnhas[index]">
                                        {{nha.Mota}}<br />
                                    </div>
                                </md-table-cell>
                                <md-table-cell>
                                    <b>Nội dung trên lớp</b><br />
                                    <div v-for="lop in Phanconglops[index]">
                                        {{lop.Mota}} <br />
                                    </div>

                                </md-table-cell>
                                <!--</md-table-row>-->
                                <!--<md-table-row>-->
                                <!--</md-table-row>-->



                            </md-table-row>

                        </md-table>
                    </md-card-content>
                </md-card>
            </div>
        </div>
    </div>
</template>

<script>
    import saveAs from 'file-saver';
    import axios from 'axios';
    export default {
        props: {
            Monhoc: Object,
            Chuongs: Array,
            Phancongnhas: Array,
            Phanconglops: Array,
            PdfUrl: String
        },
        name: "detail-component",
        methods: {

            getData(id) {

                var base = this;
                const params = new URLSearchParams();
                params.append('id', id);
                
                
                axios({
                    url: base.PdfUrl,
                    method: 'POST',
                    data:params,
                    responseType: 'blob', // Important
                }).then((res) => {
                    console.log(res);
                    console.log(res["data"]);
                    console.log(res["headers"]["content-type"]);
                    var file_data = res["data"];
                    var file_type = res["headers"]["content-type"];
                    var file = new Blob([file_data], { type: file_type });
                    console.log(file);
                    saveAs(file, "Test.pdf")
                    alert("Success");
                });
            }

        }
    };
</script>
