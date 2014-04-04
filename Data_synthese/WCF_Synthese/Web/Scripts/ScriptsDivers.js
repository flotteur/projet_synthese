
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
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;
           
                   },
        ajaxSuccess: function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;
           
                   },
        ajaxError: function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;
           
                   },
        ajaxComplete:function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;
           
                   }, 
        complete :function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;
           
                   },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}

function Login( pUserName, pPassword) {
    
    data = pusername+"/" +pPassword;
    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        dataType: "json",
        jsonp: true,
        url: "/WCF_Synthese/servicewcf_synthese.svc/Login/" + data,
        contentType: "application/json; charset=utf-8",
        processData: false,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}
function Logout() {

    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        dataType: "json",
        jsonp: true,
        url: "/WCF_Synthese/servicewcf_synthese.svc/Logout",
        contentType: "application/json; charset=utf-8",
        processData: false,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}

function InsertAlert(){
           
    datas = { "IDOiseau": "1", 
                "IDUsager": "2" };

    dataToSend = JSON.stringify(datas)
    //jsonp: true, processData: true,
    $.ajax({
        type: "POST",
        dataType: "json",        
        url: "/WCF_Synthese/servicewcf_synthese.svc/Alerte",
        contentType: "application/json; charset=utf-8",
        data: dataToSend,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data);
            var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });
}

function GetAlerts(){
           
    $.ajax({
        type: "GET",
        dataType: "json",        
        url: "/WCF_Synthese/servicewcf_synthese.svc/Alerte/1",
        contentType: "application/json; charset=utf-8",
        
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data);
            var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });
}
function DeleteAlert(){

           
    datas = { "ID": "1", 
                "IDOiseau": "1", 
                "IDUsager": "1" };

    dataToSend = JSON.stringify(datas)
    //jsonp: true, processData: true,
    $.ajax({
        type: "DELETE",
        dataType: "json",        
        url: "/WCF_Synthese/servicewcf_synthese.svc/Alerte",
        contentType: "application/json; charset=utf-8",
        data: dataToSend,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data);
            var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });
}
function InsertUsager() {
       
       var Courriel = $("#txtCourriel").val(); 
       var EstAdmin = $("#checkboxAdmin").prop("checked");
       var MotDePasse = $("#txtMotDePasse").val();
       var Nom  = $("#txtNom").val();
       var NomUsager = $("#TextNomUsager").val();
    datas = { "Courriel": Courriel, 
                "EstAdministrateur": EstAdmin, 
                "MotDePasse": MotDePasse, 
                "Nom": Nom, 
                "NomUsager": NomUsager };
    dataToSend = JSON.stringify(datas)
    //jsonp: true, processData: true,
    $.ajax({
        type: "POST",
        dataType: "json",        
        url: "/WCF_Synthese/servicewcf_synthese.svc/InsertUsager",
        contentType: "application/json; charset=utf-8",
        data: dataToSend,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data);
            var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}

