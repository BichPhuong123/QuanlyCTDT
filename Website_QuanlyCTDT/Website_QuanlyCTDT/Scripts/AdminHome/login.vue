<template>
    <div class="wrapper">

        <div class="section page-header header-filter" >
            <div class="container">
                <div class="md-layout">
                    <div class="md-layout-item md-size-33 md-small-size-66 md-xsmall-size-100 md-medium-size-40 mx-auto">
                        <form method="post" action="/AdminHome/Login">
                            <login-card header-color="green">
                                <h4 slot="title" class="card-title">Login</h4>

                                <md-field class="md-form-group" slot="inputs">
                                    <md-icon>face</md-icon>
                                    <label>Username...</label>
                                    <md-input v-model="username" name="username" required></md-input>
                                </md-field>

                                <md-field class="md-form-group" slot="inputs">
                                    <md-icon>lock_outline</md-icon>
                                    <label>Password...</label>
                                    <md-input v-model="password" name="password" required type="password"></md-input>
                                </md-field>
                                <md-button type="submit" slot="footer" class="md-simple md-success md-lg">
                                    Login
                                </md-button>

                            </login-card>
                        </form>
                    </div>
                </div>
            </div>
        </div>


    </div>
   
</template>

<script>

    import { LoginCard } from "../components";
    export default {
        name: "login-component",
        components: {
            LoginCard

        },
      
};
</script>

<style lang="css"></style>
