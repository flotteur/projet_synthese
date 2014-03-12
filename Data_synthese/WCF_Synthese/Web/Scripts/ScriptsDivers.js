

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
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}

function LogAdmin() {
    
    data = "admin/MotDePasse";
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

function LogoutAdmin() {

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

function InsertUsager() {
       
    datas = { "Courriel": "admin2@diq.ca", "EstAdministrateur": true, "ID": 2, "MotDePasse": "", "Nom": "Administrateur", "NomUsager": "admin2" };
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
            
            return obj;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}