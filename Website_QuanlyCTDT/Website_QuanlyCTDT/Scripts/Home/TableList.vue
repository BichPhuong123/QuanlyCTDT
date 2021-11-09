<template>
  <div class="content">
    <div class="md-layout">
        <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
            <md-card>
                <md-card-header data-background-color="green">
                    <h4 class="title">Simple Table</h4>
                    <p class="category">Here is a subtitle for this table</p>
                </md-card-header>
                <md-card-content>
                    <div>
                      
                        <md-table  table-header-color="green">
                           
                                <md-table-row slot="md-table-row">
                                    <md-table-head>Name</md-table-head>

                                </md-table-row>
                          
                          
                                <md-table-row v-for="item in Khoas" slot="md-table-row">
                                    <md-table-cell>{{item.TenKh}}</md-table-cell>

                                </md-table-row>
                          
                        </md-table>
                    </div>

                </md-card-content>
            </md-card>
            <nav-tabs-card>
                <template slot="content">

                    <md-tabs class="md-success" md-alignment="left">
                        <md-tab id="tab-home" md-label="Bugs" md-icon="bug_report">
                            <div>
                             
                                <md-table table-header-color="green">
                                    <md-table-row slot="md-table-row">
                                        <md-table-head>Name</md-table-head>
                                        <md-table-head></md-table-head>
                                    </md-table-row>


                                    <md-table-row v-for="item in Khoas" slot="md-table-row">
                                        <md-table-cell>{{item.TenKh}}</md-table-cell>
                                        <md-table-cell><a :href="MonhocUrl"><md-icon>content_paste</md-icon></a></md-table-cell>
                                    </md-table-row>

                                </md-table>
                            </div>

                            <!--<simple-table table-header-color="green"></simple-table>-->

                        </md-tab>


                        <md-tab id="tab-pages" md-label="Website" md-icon="code">
                            <simple-table table-header-color="green"></simple-table>
                        </md-tab>

                        <md-tab id="tab-posts" md-label="server" md-icon="cloud">
                            <simple-table table-header-color="green"></simple-table>
                        </md-tab>
                    </md-tabs>
                </template>
            </nav-tabs-card>
        </div>

     
    </div>
  </div>
</template>

<script>
import { SimpleTable, NavTabsCard } from "../components";

    export default {
        name: "table-component",
  components: {
    NavTabsCard,
    SimpleTable,
        },
        props: {
           
            Khoas: Array,
            MonhocUrl: String
        }
    
};
</script>
