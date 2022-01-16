<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
                <md-card>
                    <md-card-header data-background-color="red">
                        <h4>Chỉnh sửa mục tiêu và chuẩn đầu ra</h4>

                    </md-card-header>
                    <md-card-content>
                        <md-button class="md-danger md-round" v-on:click="add">Add</md-button>
                        <form method="post" action="/AdminMonhoc/EditMuctieu">
                            <input name="MaMh" :value="Mamh" style="display:none" />
                            <div v-for="(muctieu,index) in Muctieus">
                                <input name="id[]" :value="muctieu.Id" style="display:none" />
                                <label>Mô tả</label>
                                <div class="md-layout-item md-size-100">
                                    <md-field maxlength="3">
                                        <label>Mô tả</label>
                                        <md-textarea name="Mota[]" :value="muctieu.Mota"></md-textarea>
                                    </md-field>
                                </div>
                                <label>Chuẩn đầu ra</label>
                                <div class="md-layout-item md-size-100">
                                    <md-field maxlength="3">

                                        <md-textarea name="Daura[]" :value="Chuandauras[index]"></md-textarea>
                                    </md-field>
                                </div>

                                <hr>
                            </div>
                            <div v-html="item">

                                {{item}}
                            </div>

                            <div class="md-layout-item md-size-100 text-right">
                                <button class="md-button md-danger md-round" type="submit">Save</button>
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
        name: "editmuctieu-component",
        props: {

           
            Mamh: String,
            Muctieus: Array,
            Chuandauras: Array
           
         
        },
        data() {
            return {
               
               item:'',
                
                    
            };
        },
        methods:
        {
            add() {

                this.item += ' <label>Mô tả</label><div class="md-layout-item md-size-100"><div class="md-field md-theme-default md-has-textarea" maxlength="3"> <textarea class="md-textarea" name="Mota[]"></textarea></div> </div><label>Chuẩn đầu ra</label><div class="md-field md-theme-default md-has-textarea" maxlength="5"> <textarea class="md-textarea" name="Daura[]"></textarea></div><hr>';
                
                
            }
        }
};
</script>

<style lang="css"></style>
