<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="red">
                        <h4>Thêm môn học</h4>

                    </md-card-header>
                    <md-card-content>
                        <form method="post" action="/AdminMonhoc/CreateMonhoc" @submit="checkForm">
                           
                            <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                <md-field>
                                    <label>Mã môn học</label>
                                    <md-input name="MaMh" type="text" required v-model="MaMh" maxlength="10"></md-input>
                                  
                                    <span style="color:red">{{error}} </span>
                                </md-field>
                            </div>
                            <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                <md-field>
                                    <label>Tên môn học</label>
                                    <md-input name="Ten" type="text" required v-model="Ten" maxlength="100"></md-input>
                                </md-field>
                            </div>
                            <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                <md-field>
                                    <label>Số tín chỉ</label>
                                    <md-input name="Sotinchi" type="number" required min="0" v-model="Sotinchi" max="7"></md-input>
                                </md-field>
                            </div>
                            <div class="md-layout-item md-size-100">
                                <label>Chuyên ngành</label>
                                <select name="IdChuyennganh" v-model="IdChuyennganh">
                                    <option value="null">Select one</option>
                                    <option v-for="cn in Chuyennganhs" :value="cn.Id">{{cn.TenCn}}</option>

                                </select>
                            </div>
                            <div class="md-layout-item md-size-100">
                                <md-field maxlength="5">
                                    <label>Mô tả</label>
                                    <md-textarea name="Mota" required v-model="Mota"></md-textarea>
                                </md-field>
                            </div>
                            <div class="md-layout-item md-size-100 text-right">
                                <button class="md-button md-danger md-round" type="submit">Submit</button>
                            </div>
                        </form>

                    </md-card-content>
                </md-card>

            </div>

           
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: "createmonhoc-component",
        props: {

           
            Nganh: String,
            Chuyennganhs: Array,
            Khoahoc: Number,
         
        },
        data() {
            return {
                MaMh: '',
                Ten: '',
                Sotinchi: null,
              
               error:'',
                Mota: '',
                IdChuyennganh:null
                    
            };
        },
        methods:
        {
            add() {
               
                this.item += ' <div class="md-layout-item md-size-100"><div class="md-field md-theme-default md-has-textarea" maxlength="3"><label>Mô tả</label> <textarea class="md-textarea"></textarea></div> </div>';
              
                
            },
            checkForm: function (e){
               
                e.preventDefault();
                this.errors = [];

                var base = this;
                

                const params = new URLSearchParams();
                //params.append('idkh', base.Khoahoc);
                //params.append('idn', id);
                params.append('MaMh', base.MaMh);
                params.append('Ten', base.Ten);
                params.append('Sotinchi', base.Sotinchi);
                params.append('Mota', base.Mota);
                params.append('IdChuyennganh', base.IdChuyennganh);
                params.append('idkh', base.Khoahoc);
                params.append('idn', base.Nganh);

                axios.post('/AdminMonhoc/CreateMonhoc', params)
                    .then(function (response) {
                        if (response.data == 1) {
                           
                            location.href = '/AdminMonhoc/CreateMuctieu?MaMh=' + base.MaMh;
                            console.log(location.href)
                        }
                        else {
                            base.error ="Mã môn học đã tồn tại"
                        }


                    })
                    .catch(function (err) {
                        console.log(err);
                    });
              
                    //fetch(apiUrl + encodeURIComponent(this.name))
                    //    .then(async res => {
                    //        if (res.status === 204) {
                    //            alert('OK');
                    //        } else if (res.status === 400) {
                    //            let errorResponse = await res.json();
                    //            this.errors.push(errorResponse.error);
                    //        }
                    //    });
                
            }

        }
};
</script>

<style lang="css"></style>
