
/*
http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/Login/
http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/GetUsager/1


http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/GetObservation/1

http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/observation/1

http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/observation

http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/getOiseau/0/1
http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/getOiseau/0/1


http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/commentaire/1


http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/Alerte/
http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/deleteObservation/67

http://periodiqco1.web703.discountasp.net/WCF_Synthese/web/index2.html#


"NetworkError: 400 Bad Request - http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/deleteObservation/67"




Format de date
Date dans commentaire
Insert Observation
Delete Observation
Insert Commentaire
Delete commentaire




*/
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
    
	alert("1111122222");
	
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
			alert(obj);
            return obj;
           
                   },
        ajaxSuccess: function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
			alert(obj);
            return obj;
           
                   },
        ajaxError: function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
           alert(obj);
		   return obj;
           
                   },
        ajaxComplete:function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            alert(obj);
			return obj;
           
                   }, 
        complete :function (data) {
            obj = JSON.stringify(data);
            //obj = JSON.parse(data);
            alert(obj);
			return obj;
           
                   },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
        }
    });

}

function dba_Login( pUserName, pPassword) {
   
    data = pUserName+"/"+pPassword;
  



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
           
			//obj = JSON.stringify(data, null, "\t");	
            //obj = JSON.parse(data);
			callBack_du_login(data);
		
			return data;

        },
        error: function (xhr, textStatus) {
            alert(xhr.responseText);
					
			//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "" +xhr.responseText;
	
			
			
        }
    });

}
function dba_Logout() {

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

function dba_InsertUsager() {
 	

	/*
	
{"DateObservation":"2014-01-01","IDOiseau":1,"IDUsager":1,"Id":0,"Latitude":123,"Longitude":345,"Titre":"sdada"}




	 */		
	datas = {};
			
	datas.Courriel = v_dba_Courriel;			
	datas.EstAdministrateur = false;
	datas.MotDePasse = v_dba_txtMotDePasse;	
	//datas.MotDePasse = v_txtMotDePasse_verif;		
	datas.Nom = v_dba_txtNom;		
	datas.NomUsager = v_dba_TextNomUsager;	
	
	
		
	
    dataToSend = JSON.stringify(datas, null, "\t");
    //jsonp: true, processData: true,
	
	
	
	alert(dataToSend);
	
	
	
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
            obj = JSON.stringify(data, null, "\t");
           /*
		   var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }*/
           
			alert("dba_InsertUsager response success :"+obj);
			//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "" +obj;
		   return obj;
			
			
			

        },
        error: function (xhr, textStatus) {
            
			  alert("dba_InsertUsager response error 13212"+xhr.responseText);
			//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "" +xhr.responseText;
			
			
        }
    });

}
/*
function sleep(miliseconds) {
   var currentTime = new Date().getTime();

   while (currentTime + miliseconds >= new Date().getTime()) {
   }
}
*/
function wcf_InsertLesPhotos(le_id_de_lobservation, un_observ2) {


	var str_un_observ2 = JSON.stringify(un_observ2, null, "\t");
	
	
	//document.getElementById("id_textarea_01").value=document.getElementById("id_textarea_01").value+"\n-----------------------str_un_observ2-----------------------\n"+str_un_observ2+"\n";

	
	
	var obj_json_les_photos_a_envoyer = {};
	
	obj_json_les_photos_a_envoyer.IDObservation = parseInt(le_id_de_lobservation, 10);
	obj_json_les_photos_a_envoyer.photoList = [];
	
	
	
	alert("un_observ2.arrObservLesPhotos.length:"+un_observ2.arrObservLesPhotos.length);

	for (var i=0; i < un_observ2.arrObservLesPhotos.length; i++){
		var observ_une_photo = un_observ2.arrObservLesPhotos[i];
		var str_le_base64 = observ_une_photo.strPhoto_Image;
		
		//data:image/png;base64,
		str_le_base64 = str_le_base64.replace("data:image/png;base64,", "");
		str_le_base64 = str_le_base64.replace('\"', '');
		str_le_base64 = str_le_base64.replace('\"', '');
		
		//str_le_base64 = str_le_base64+'===';
		
		
		//\""
		
		
		
		//str_le_base64 = str_le_base64.replace('\""', '');
		
		
		
		//str_le_base64 = Regex.Replace(str_le_base64, "\"", ""); 
		//str_le_base64 = Regex.Replace(str_le_base64, "\"", ""); 
		
		//       "\"iV        CC\""
		//str_le_base64 = str_le_base64+"==";
		var temp9876 = str_le_base64.substr(0,23);
		
		alert(temp9876);
		
		//Construire le nouveau json pour envoyer les photos
		//alert("wcf_InsertUnePhoto"+temp9876);
		obj_json_les_photos_a_envoyer.photoList.push(str_le_base64);
		
		//this.myListViewObservArray.push(test3546);	
		
		//{"IDObservation":1,"photoList":["R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw=="]}
		//observ_Object.strObservFlagInsertUpdate = "";
		//alert("strObservFlagInsertUpdate:"+observ_Object.strObservFlagInsertUpdate);
		
		/*
		if(observ_Object.strObservFlagInsertUpdate=="I" || observ_Object.strObservFlagInsertUpdate=="U"){
		}*/
	} 
	//var str_json_des_photos = JSON.stringify(obj_json_les_photos_a_envoyer, null, "\t");
	var str_json_des_photos = JSON.stringify(obj_json_les_photos_a_envoyer);	
	//document.getElementById("id_textarea_01").value=document.getElementById("id_textarea_01").value+"\n-----------------------str_json_des_photos-----------------------\n"+str_json_des_photos+"\n";

			/*	
			Pour l'insertion d'une image :

			l'url du service :

			http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/image
			Json :

			{"IDObservation":1,"photoList":["R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw=="]}

			Affichage d'une image :
 
			http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/image/observation/4
			*/	


   $.ajax({
        type: "POST",
        dataType: "json",        
        url: "http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/image",
        contentType: "application/json; charset=utf-8",
        data: str_json_des_photos,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            var str_obj_succes_response = JSON.stringify(data, null, "\t");
			
	
			alert("wcf_InsertLesPhotos str_obj_succes_response:\n"+str_obj_succes_response);
			
			//alert("wcf_InsertObservation response success:\n"+str_obj);
			//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n----str_obj_succes_response----------\n" +str_obj_succes_response;		
			

        },
        error: function (xhr, textStatus) {
		
			alert("wcf_InsertLesPhotos response error:\n"+xhr.responseText);	
			//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n-----error booooo----------\n" +xhr.responseText;		

        }
    });	
	
	
	


}





function wcf_InsertObservation(un_observ1) {
 	//http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/observation/1
	
	//Faire une copie du json avant de le modifier
		
	var str_copie_observ_Object = JSON.stringify(un_observ1, null, "\t");

	
	//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n-----str_copie_observ_Object----------\n" +str_copie_observ_Object;		

	

	
	var copie_observ_Object = JSON.parse(str_copie_observ_Object);			
	
	
	
	
	
	
	un_observ2 ={"DateObservation":"2014-02-25","IDOiseau":1,"IDUsager":1,"Id":0,"Latitude":123,"Longitude":345,"Detail":"11aa1111111","Titre":"22ss222222"}
	
	
	un_observ3 ={"IDUsager":1,"Id":0, "DateObservation":"2014-04-01 12:13:14", "Latitude":123, "Longitude":456, "IDOiseau":1, "Titre":"Mon observation", "Detail":"Vraiment cool"}
	
	un_observ4 ={"IDUsager":1,"Id":0, "DateObservation":"2014-04-01 12:13:14", "Latitude":46.9218747, "Longitude":-71.37613929999999, "IDOiseau":1, "Titre":"Mon observation", "Detail":"Vraiment cool float"}
	
	
	
	
	
	/*
	"strObserv_Id": 111111,
	"strObserv_DateObservation": 1394148405287,
	"strObserv_Position_lat": 345.6775,
	"strObserv_Position_long": 47.6776,			
	"strObserv_IDUsager": 111111,		
	"strObserv_IDOiseau": 121212,	
	"strObserv_Titre": "Moineau", 
	"strObserv_Resume": "Dignissim autem magna ipsum qui luptatum, praesent autem duis vel veniam",
	*/	
	
	
	
	un_observ1.strObserv_DateObservation = convertTimeStampToDate(un_observ1.strObserv_DateObservation);
	un_observ1.strObserv_IDOiseau = parseInt(un_observ1.strObserv_IDOiseau, 10);
	un_observ1.strObserv_IDUsager = parseInt(un_observ1.strObserv_IDUsager, 10);
	//strObs_Ois_Nom
	//strObs_Ois_Espece
	//strObs_Usr_NomUsager
	//strObs_Usr_NomComplet
	
	
	un_observ1.strObserv_Position_lat = parseFloat(un_observ1.strObserv_Position_lat);
	un_observ1.strObserv_Position_long = parseFloat(un_observ1.strObserv_Position_long);
	//delete un_observ1["strObserv_Resume"];
	delete un_observ1["strObservFlagInsertUpdate"];
	delete un_observ1["arrObservLesPhotos"];
	

	delete un_observ1["strObserv_Oiseau"];
	delete un_observ1["strObserv_Usager"];
	
		
	dataToSend = JSON.stringify(un_observ1, null, "\t");

	
	dataToSend = dataToSend.replace(/strObserv_Id/g, "Id");
	dataToSend = dataToSend.replace(/strObserv_DateObservation/g, "DateObservation");
	
	dataToSend = dataToSend.replace(/strObserv_IDOiseau/g, "IDOiseau");
	
	
	
	
	dataToSend = dataToSend.replace(/strObserv_IDUsager/g, "IDUsager");
	
	//strObs_Ois_Nom
	//strObs_Ois_Espece
	//strObs_Usr_NomUsager
	//strObs_Usr_NomComplet
	
	dataToSend = dataToSend.replace(/strObserv_Position_lat/g, "Latitude");
	dataToSend = dataToSend.replace(/strObserv_Position_long/g, "Longitude");
	dataToSend = dataToSend.replace(/strObserv_Titre/g, "Titre");
	dataToSend = dataToSend.replace(/strObserv_Resume/g, "Detail");
	
    //jsonp: true, processData: true,
	//document.getElementById("id_textarea_01").value=document.getElementById("id_textarea_01").value+"\n"+dataToSend+"\n";
	//alert("dataToSend:"+dataToSend);
	
	
	
	//var ereeddree = JSON.stringify(dataToSend, null, "\t");	
		
	//alert("79999999:"+ereeddree);


	
	//dataToSend = JSON.stringify(un_observ4, null, "\t");	
	alert(dataToSend);

	
	
	
    $.ajax({
        type: "POST",
        dataType: "json",        
        url: "/WCF_Synthese/ServiceWCF_Synthese.svc/observation",
        contentType: "application/json; charset=utf-8",
        data: dataToSend,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            var str_obj = JSON.stringify(data, null, "\t");
			
		
			/*
			{
				"DateObservation": "2014-04-02 21:00:39",
				"Detail": "ewrweq",
				"IDOiseau": 1,
				"IDUsager": 1,
				"Id": 77,
				"Latitude": 46.9218318,
				"Longitude": -71.3761956,
				"Oiseau": null,
				"Titre": "rwrwqr",
				"Usager": null
			}
			*/		
	
			
		
		
			//var le_obj = JSON.parse(data);
						
			
			
			//alert("le_obj:\n"+data.Id);
			//alert("wcf_InsertObservation response success:\n"+str_obj);
			document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n----wcf_InsertObservation response success-str_obj----------\n" +str_obj;		
			
			
			
			//un_observ2
			
			wcf_InsertLesPhotos(data.Id, copie_observ_Object); 
			
			
			
		   //return obj;

        },
        error: function (xhr, textStatus) {
		
			alert("wcf_InsertObservation response error:\n"+xhr.responseText);	
			document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n-----error booooo----------\n" +xhr.responseText;		

        }
    });
	
	

}



//1-Aller activer les alertes pour un usager (pouvoir modifier un usager pour activer les alertes) l'url que je dois utiliser?
//2-Aller activer les alertes pour une espèce,  c'est quoi l'url?


//onClickBoutonActiverAlertePourUnOiseau



function InsertUnAlert(le_id_du_user, le_id_de_loiseau){

    /*datas = { "IDOiseau": "9",
                "IDUsager": "1" };*/
			
			
	 datas = { "ID": "1", 
                "IDOiseau": "8", 
                "IDUsager": "1" };		
			
			
			
			
			
//{"IDOiseau":"1","IDUsager":"1"}


			
	datas.IDUsager = le_id_du_user.toString();		
	datas.IDOiseau = le_id_de_loiseau.toString();
	

    dataToSend = JSON.stringify(datas)
    //jsonp: true, processData: true,
	
	document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n----dataToSend--------\n"+dataToSend+"\n";		
	
	alert(dataToSend);
	
	
	
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
				
				document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + "\n----obj--------\n"+obj+"\n";	
				
				
            }
			
			alert("InsertUnAlert success:"+obj);
			
            return obj;
			
			

        },
        error: function (xhr, textStatus) {
           // alert(xhr.responseText);
				 alert("InsertUnAlert error:"+xhr.responseText);
        }
    });
	
}


//3- Obtenir les alertes d'un usager
//http://periodiqco1.web703.discountasp.net/WCF_Synthese/servicewcf_synthese.svc/Alerte/1
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
/*
4- Supprimer les alertes
Si tu passe l'ID > 0, je ne supprime que cette alerte
Si tu passes seulement IDOiseau > 0 je supprime toutes les alertes de cet oiseau
Si tu passes seulement l'IDUsager > 0 je supprime toutes les alertes de cet usager
*/
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

//Pour le reste, je laisse ça à Gabriel



//de Gabriel
//Pour la supression d'une observation :
//WCF_Synthese/servicewcf_synthese.svc/deleteObservation/{id}

//ou {id} est l'id de l'observation

//Pour la supression d'un commentaire
//WCF_Synthese/servicewcf_synthese.svc/deletecommentaire/{id}

//Ou {id} est l'id du commentaire

//Les deux calls sont en GET 

function DeleteObservation(le_id_de_lobs){
	//alert("le_id_de_lobs:"+le_id_de_lobs);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/WCF_Synthese/servicewcf_synthese.svc/deleteObservation/"+le_id_de_lobs,
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
                //alert(obj.valueOf('MessageErreur'));
            }
			 alert("DeleteObservation success:"+obj);
			 
			 	document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + obj+"\n--------------DeleteObservation success------------\n\n";
			 
            return obj;

        },
        error: function (xhr, textStatus) {
            alert("DeleteObservation error:"+xhr.responseText);
			
			
				document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + xhr.responseText+"\n--------------DeleteObservation error------------\n\n";
			
        }
    });
}

function DeleteCommentaire(le_id_du_comm){
	alert("le_id_du_comm:"+le_id_du_comm);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/WCF_Synthese/servicewcf_synthese.svc/deletecommentaire/"+le_id_du_comm,
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
			 alert("DeleteObservation success:"+obj);
            return obj;

        },
        error: function (xhr, textStatus) {
            alert("DeleteObservation error:"+xhr.responseText);
        }
    });
}



function dba_InsertUnCommentaire() {
 	
	
/*	









Pour ajouter une commentaire :



Le Json à me passer pour l'ajout :

{"IDUsager":1,"Id":0,"Texte":"blabla","observationId":1}



Je viens de livrer des modification :

La suppression de l'observation devrait fonctionner.
J'ai ajouté le code pour envoyer l'alerte à la création d'un observation
L'id du commentaire est corrigé
J'ai commencé l'update de l'observation mais ce n'est pas fonctionnel encore... (demain!)

Pour l'ID je pourrai juste regarder demain, je suis en visite dans la famille ce soir!


*/		

   datas = {"IDUsager":1,"Id":1,"Texte":"blabla","observationId":110}



	/*
	datas.Courriel = v_dba_Courriel;			
	datas.EstAdministrateur = false;
	datas.MotDePasse = v_dba_txtMotDePasse;	
	//datas.MotDePasse = v_txtMotDePasse_verif;		
	datas.Nom = v_dba_txtNom;		
	datas.NomUsager = v_dba_TextNomUsager;	
	*/
	
		
	
    dataToSend = JSON.stringify(datas, null, "\t");
    //jsonp: true, processData: true,
	
	
	
	alert(dataToSend);
	
	
	
    $.ajax({
        type: "POST",
        dataType: "json",        
        url: "/WCF_Synthese/ServiceWCF_Synthese.svc/Commentaire",
        contentType: "application/json; charset=utf-8",
        data: dataToSend,
        statusCode: {
            default: function () {
                alert(status);
            }
        },
        success: function (data) {
            obj = JSON.stringify(data, null, "\t");
           /*
		   var msg = obj.valueOf('MessageErreur');
            if (msg != null){
                alert(obj.valueOf('MessageErreur'));
            }*/
           
			alert("dba_InsertUnCommentaire response success :"+obj);
			document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value +"\n--------------dba_InsertUnCommentaire success--------\n"+obj+"\n\n";
			
		   return obj;
			
			
			

        },
        error: function (xhr, textStatus) {
            
			//alert("dba_InsertUnCommentaire response error 788776"+xhr.responseText);
		
			document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value +"\n--------------dba_InsertUnCommentaire error--------\n"+xhr.responseText+"\n\n";
	
			
        }
    });

}

