//Section pour l'affichage et le téléchargement des fichiers 



function ClasseListViewComm(myName) {
	//alert(myName);
	this.myListViewCommName = "777";
	this.myListViewCommArray = [];
}



ClasseListViewComm.prototype.agXMLHttpReqComm = function(le_id_obs) {

//alert(le_url);

	

//var le_url = "comm_dwn.php?le_id_de_obs="+le_id_obs+"";
	if(dataAdapterSwitch_dataFromIIS){
		var le_url = "http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/commentaire/"+le_id_obs;
	}else{
		var le_url = "comm_dwn.php?le_id_de_obs="+le_id_obs+"";
	}	

	var storageFiles = JSON.parse(localStorage.getItem("storageFilesFichiers3")) || {},
		storageFilesDate = storageFiles.date1,
		date = new Date(),
		//todaysDate = (date.getMonth() + 1).toString() + date.getDate().toString();
		todaysDate = agConvertDate2(date);

	//alert(storageFilesDate+"/"+todaysDate); 
	// Vérifier si fichier existe et n'est pas trop vieux 
	//Télécharger seulement une fois par jour. Si pas date d'aujourd'hui on télécharge
	//if (typeof storageFilesDate === "undefined" || storageFilesDate != todaysDate)
	//if (typeof storageFilesDate === "undefined")
	//{

	//alert(le_url);
	try {
		var resourcePath = le_url;

		var request = new XMLHttpRequest();

		request.open("GET", resourcePath, true);
		request.onreadystatechange = function() {
			if (request.readyState == 4) {
				if (request.status == 200 || request.status == 0) {

					str_output = request.responseText;
					
							var str_outpu2 = JSON.parse(str_output);
							var data2Received = JSON.stringify(str_outpu2, null, "\t"); 
							document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + data2Received+"\n--------------agXMLHttpReqComm------------\n\n";
							//document.getElementById("id_textarea_01").value = data2Received+"\n--------------------------------------------------------------------\n\n";
							
							//renomer var
			
							data2Received = data2Received.replace(/\WDate\W/g, '"strComm_comm_Date"');
							data2Received = data2Received.replace(/\WIDUsager\W/g, '"strComm_comm_UserId"');
							data2Received = data2Received.replace(/\WId\W/g, '"strComm_comm_Id"');
							data2Received = data2Received.replace(/\WTexte\W/g, '"strComm_comm_Resume"');
							data2Received = data2Received.replace(/\WobservationId\W/g, '"strComm_comm_ObservationId"');			
					
					//alert(data2Received);
/*
		"strComm_comm_Id": 1,
		"strComm_comm_Date": 1394144405287,
		"strComm_comm_ObservationId": "1",
		"strComm_comm_UserId": "2",
		"strComm_comm_Resume": "Dignissim autem magna ipsum qui luptatum, praesent autem duis vel veniam, ut ipsum ut consequat. Vero, et ut facilisis dolor sed, illum ipsum esse dolore feugait, nonummy adipiscing euismod. Facilisi qui, esse odio praesent te te, ex duis."
*/	




					
	/*				
[
  {
    "IDUsager": 1,
    "Id": 0,
    "Texte": "blabla",
    "observationId": 1
  },
  {
    "IDUsager": 1,
    "Id": 0,
    "Texte": "Commentaire 2",
    "observationId": 1
  }
]					
	*/				
					
					
					
					
/*
					storageFiles.date1 = todaysDate;
					storageFiles.output = str_output;
					try {
						localStorage.setItem("storageFilesFichiers3", JSON.stringify(storageFiles));
					} catch (e) {
						alert("Storage failed: " + e);
					}
*/
					objListViewComm.fillCommListView(data2Received);

				}
			}
		}
		request.send();

	} catch (e) {
		//errorEvent(e);
	}
	//}
	// else {
	//   str_output = storageFiles.output;
	//   objListViewComm.fillCommListView(str_output); 
	//storageFiles.output = str_output;
	//}
}





ClasseListViewComm.prototype.addCommListViewCell = function(la_comm_id, la_timestamp, la_observ_id, la_usager_id, la_resume, l_in_dex) {


	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "la_liste1");
	newDiv1.setAttribute("align", "left");

	newDiv1.id = "id_div_liste_commentaires";

	//newDiv1.addEventListener('click', test55, false)
	//newDiv1.addEventListener('click',function(){affichePageXXXXX(le_id, le_non_fich, le_url, la_descrip, la_date_eng)},false);


	var le_la_timestamp = parseInt(la_timestamp, 10);

	var une_date = convertTimeStampToDate(le_la_timestamp);

	var em_timestamp = document.createElement("em");
	var em_timestamp_content = document.createTextNode("Date: " + une_date);
	em_timestamp.setAttribute("class", "lvc_em_timestamp");
	em_timestamp.appendChild(em_timestamp_content);



	var em_usager_id = document.createElement("em");
	var em_usager_id_content = document.createTextNode("Commentaire: " + la_comm_id +", Usager: " + la_usager_id);
	em_usager_id.setAttribute("class", "lvc_em_usager");
	em_usager_id.appendChild(em_usager_id_content);


	
	
	
	var boutonDeleteComm = document.createElement("input");
	boutonDeleteComm.setAttribute("type", "button");
	//boutonDeleteComm.setAttribute('checked', '');
	boutonDeleteComm.setAttribute("class", "delete_comm_button");
	boutonDeleteComm.setAttribute("value", "Effacer");
	//boutonDeleteComm.setAttribute("id", "bouton_effacer_ligne_comm");
	boutonDeleteComm.addEventListener('click',function(){effacer_ligne_comm_div(this, la_comm_id)},false);
	
	newDiv1.appendChild(boutonDeleteComm);	
	
	
	
	
	
	var newP = document.createElement("p");
	var newPContent = document.createTextNode(la_resume);
	newP.appendChild(newPContent);

	var newDivTouch = document.createElement("div");
	newDivTouch.setAttribute("class", "divTouch");
	newDivTouch.addEventListener('click', function() {
		affiche_ecran_commentaire(la_comm_id, la_timestamp, la_observ_id, la_usager_id, la_resume, l_in_dex)
	}, false);








	newDiv1.appendChild(newDivTouch);

	newDiv1.appendChild(em_usager_id);
	newDiv1.appendChild(em_timestamp);


	newDiv1.appendChild(newP);



	my_mainDiv = document.getElementById("div_main");
	my_mainDiv.appendChild(newDiv1);



}


ClasseListViewComm.prototype.fillCommListView = function(le_str_output) {

	
	var localString = JSON.parse(le_str_output);



	//var JSONstring=[{"key1":"value1","key2":"value2"},{"key3":"value3"}];

	for (var i = 0; i < localString.length; i++) {
		//var obj = localString.result[i];

		objListViewComm.addCommListViewCell(localString[i].strComm_comm_Id, localString[i].strComm_comm_Date, localString[i].strComm_comm_ObservationId, localString[i].strComm_comm_UserId, localString[i].strComm_comm_Resume, i)

	}

}






ClasseListViewComm.prototype.removeAllCommFromListView = function(le_url) {


	var element = document.getElementById("div_main");
	//alert("removeAllCommFromListView");
	//alert("removeAllCommFromListView: "+element.childNodes.length);
	for (var i = 0; i < element.childNodes.length; i++) {
		var theObject = element.childNodes[i];

		//alert(theObject.className);
		if (theObject.className == "la_liste1") {
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i = -1;
			//element.removeChild(theObject);
		}
	}
}

ClasseListViewComm.prototype.deleteUnCommentaireFromListView = function(id_du_comm) {
	
	//var les_lignes = document.getElementsByClassName('list_View_Observ');	
	//var theObject = les_lignes[id_du_comm];	
	//this.myListViewObservArray.splice(id_du_comm,1);
	//theObject.parentNode.removeChild(theObject);
	
	if(dataAdapterSwitch_dataFromIIS){
		DeleteCommentaire(id_du_comm);
	}else
	{	

	}	
		
		
		
		
		
		
}



