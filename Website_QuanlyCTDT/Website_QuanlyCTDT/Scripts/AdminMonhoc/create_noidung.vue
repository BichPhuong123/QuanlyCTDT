<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="red">
                        <h4>Thêm nội dung môn học</h4>

                    </md-card-header>
                    <md-card-content>
                        <md-button class="md-danger md-round" v-on:click="add">Add</md-button>
                        <form method="post" action="/AdminMonhoc/CreateNoidung">
                            <input name="MaMh" :value="Mamh" style="display:none" />
                            <label>Tuần</label>
                            <div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25">
                                <md-field>

                                    <md-input  type="number" name="Tuan[]" required min="1" max="15"></md-input>
</md-field>
                            </div>
                            <label>Chương</label>
                            <div class="md-layout-item md-size-100">
                                <md-field maxlength="3">
                                    <label>Chương</label>
                                    <md-textarea name="Ten[]"></md-textarea>
                                </md-field>
                            </div>

                            <label>Nội dung GD tại lớp</label>
                            <div class="md-layout-item md-size-100">
                                <md-field maxlength="3">

                                    <md-textarea name="lop[]"></md-textarea>
                                </md-field>
                            </div>


                            <label>Nội dung tại nhà</label>
                            <div class="md-layout-item md-size-100">
                                <md-field maxlength="3">

                                    <md-textarea name="nha[]"></md-textarea>
                                </md-field>
                            </div>
                            <hr>
                            <div v-html="item">

                                {{item}}
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

    export default {
        name: "createnoidung-component",
        props: {


            Mamh: String,
            Tuans: Array


        },
        data() {
            return {

                item: '',

                Mota: null

            };
        },
        methods:
        {
            add() {

                this.item += '<label>Tuần</label><div class="md-layout-item md-size-50 md-xsmall-size-100 md-small-size-50 md-medium-size-25"><div class="md-field md-theme-default md-required" maxlength="3"> <input type="number" name="Tuan[]" required min="1" max="15" required="required" class="md-input"/></div></div><label>Chương</label><div class="md-layout-item md-size-100"><div class="md-field md-theme-default md-has-textarea" maxlength="3"> <textarea class="md-textarea" name="Ten[]"></textarea></div> </div><label>Nội dung GD tại lớp</label><div class="md-field md-theme-default md-has-textarea" maxlength="3"> <textarea class="md-textarea" name="lop[]"></textarea></div><label>Nội dung tại nhà</label><div class="md-field md-theme-default md-has-textarea" maxlength="3"> <textarea class="md-textarea" name="nha[]"></textarea></div><hr>';
                
                
                
            }
        }
    };
</script>

<style lang="css"></style>
