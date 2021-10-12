<template>
  <div class="content">
    <div class="md-layout">
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100"
      >
        <nav-tabs-card>
          <template slot="content">
           
            <md-tabs class="md-success" md-alignment="left">
              <md-tab id="tab-home" md-label="Bugs" md-icon="bug_report">
       
            
        <simple-table table-header-color="green"></simple-table>
            
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
import { SimpleTable, NavTabsCard } from "@/components";

export default {
  components: {
    NavTabsCard,
    SimpleTable,
  },
};
</script>