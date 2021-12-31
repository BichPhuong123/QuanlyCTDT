<template>
    <div id="home">
      
        <h1>Home </h1>
       
    </div>
    
</template>
<script>
    import axios from 'axios';
    import saveAs from 'file-saver';

    export default {
        name: "home-component",
        props: {

            PdfUrl: String,
            ImportPdftUrl: String
        },
        data() {
            return {
                search:''
            }
        },
        methods: {
            
            getData: function () {
                
                var base = this;
              
                //axios.post(base.PdfUrl)
                //    .then(function (res) {
                //        console.log(res);
                //        console.log(res["data"]);
                //        console.log(res["headers"]["content-type"]);
                //        var file_data = res["data"];
                //        var file_type = res["headers"]["content-type"];
                //        var file = new Blob([file_data], { type: file_type });
                //        console.log(file);
                //        saveAs(file, "Test.pdf")
                //        alert("Success");
                        
                //    })
                //    .catch(function (err) {
                //        console.log(err);
                //    });
                axios({
                    url: base.PdfUrl,
                    method: 'POST',
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