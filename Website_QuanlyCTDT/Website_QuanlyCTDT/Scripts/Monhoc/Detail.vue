<template>
    <div class="content">
        <div class="md-layout">
            <div class="md-layout-item">
                <md-card>
                    <md-card-header data-background-color="green">
                        <h4 class="title">Chi tiết môn học</h4>
                       
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
                    </md-card-content>
                </md-card>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            Monhoc: Object
        },
        name: "detail-component",
    };
</script>
