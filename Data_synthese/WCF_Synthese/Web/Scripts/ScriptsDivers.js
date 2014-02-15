
function CallService() {
    XMLHttpRequest("http://diq.ca/synthese/servicewcf_synthese.svc/getusager/1", { "pID": "2" }, Callback, onError);
}
function Callback(result) {
    alert(result); // string
    alert(result.d.Company);
    alert(result.d.ProjectEntities[1].CustomerEntity.LastName);
}
function onError(error) {
    alert("Error: " + error.message);
}
function init() {
    canvas = document.getElementById("canvas");
    if (canvas.getContext) {
        contexte = canvas.getContext("2d");
        setInterval(draw, 1000);
    }
}

var ID;
function GetUsager() {
    ID = 1;
    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        dataType: "json",
        jsonp:true,
        url: "http://diq.ca/synthese/servicewcf_synthese.svc/GetUsager/1" ,
        contentType: "application/json; charset=utf-8",
        processData: false,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {

            alert("Success");
           
                   },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}