
function CallService() {
    XMLHttpRequest("http://localhost/WCF_Synthese/ServiceWCF_Synthese.svc", { "pID": "2" }, Callback, onError);
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

