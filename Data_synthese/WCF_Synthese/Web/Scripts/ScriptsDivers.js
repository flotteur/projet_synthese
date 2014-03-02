

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
        url: "/WCF_Synthese/servicewcf_synthese.svc/GetUsager/" +ID,
        contentType: "application/json; charset=utf-8",
        processData: false,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {

            alert("RÉUSSI!  " + data);
           
                   },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}