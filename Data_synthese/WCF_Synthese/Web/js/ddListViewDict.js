//Section pour l'affichage et le téléchargement du dictionnaire


function ClasseListViewDictionnaire(myName) {
//	alert(myName);
//	this.myListViewDictName = myName;
//	this.myListViewDictArray = [];
}



ClasseListViewDictionnaire.prototype.XMLHttpReqDict = function(chmp_de_rech, type_de_recherche) {
    /* 
	 type_de_recherche="List_view"
	 type_de_recherche="get_espece_str"
	 
	 
	 */
	 
	if(dataAdapterSwitch_dataFromIIS){

		 var le_url="http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/getOiseau/0/100";
	}else{
		
		 var le_url="json/dictionnaire.json";
	}
	 
	
	 
	 
//	alert('ddXMLHttpDictionnaire le_url: '+le_url);
 	try {
     
 		 var resourcePath = le_url;
         var request = new XMLHttpRequest();
		
         request.open("GET", resourcePath, true);
		 
         request.onreadystatechange = function() {
             if (request.readyState == 4) {
                 if (request.status == 200 || request.status == 0) {
 					str_output = request.responseText;
					
					
					if(dataAdapterSwitch_dataFromIIS){

						

						
						var str_outpu2 = JSON.parse(str_output);
						
						var une_variable_json = {};
						une_variable_json.result = [];
						//alert(str_outpu2.GetAllOiseauxResult.OiseauxWCF.length);
						for (var i=0; i < str_outpu2.GetAllOiseauxResult.OiseauxWCF.length; i++){
			
							var theObject_oiseau = str_outpu2.GetAllOiseauxResult.OiseauxWCF[i];	

							//conversion de type
							
							
							/*
							theObject_obs.strObserv_DateObservation = convertDateToTimestamp(theObject_obs.strObserv_DateObservation);
							//alert("111111111111111111111:"+theObject_obs.strObserv_DateObservation)
							theObject_obs.strObserv_IDOiseau = theObject_obs.strObserv_IDOiseau.toString();
							theObject_obs.strObserv_IDUsager = theObject_obs.strObserv_IDUsager.toString();
							//strObs_Ois_Nom
							//strObs_Usr_NomUsager
							//strObs_Usr_NomComplet
							
							theObject_obs.strObserv_Position_lat = theObject_obs.strObserv_Position_lat.toString();
							theObject_obs.strObserv_Position_long = theObject_obs.strObserv_Position_long.toString();
							theObject_obs.arrObservLesPhotos = [];
							//delete theObject_obs["MessageErreur"];
							*/
							
							//Effacer des elements du json
							delete theObject_oiseau["MessageErreur"];
							delete theObject_oiseau["CrisOiseau"];
														
							//Cancellé l'image de Raymond parce qu'un peut downloader l'image mais pas la visionner dans un fureteur
							//Bin en tous cas peut etre, mais j'ai plus de temps donc je hardcode les images ici
							//var debut_url = "http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc/image/oiseau/10";
							//var debut_url = "http://periodiqco1.web703.discountasp.net/WCF_Synthese/ServiceWCF_Synthese.svc";
							//var debut_url = "http://periodiqco1.web703.discountasp.net/WCF_Synthese/WCF_Synthese/web/birds/aigrette_garzette.jpg";
							//var url_au_complet = debut_url+""+theObject_oiseau.Photos[0].Path;
							
							var le_idd = theObject_oiseau["ID"];
							//alert("le_idd:"+le_idd);
							var url_au_complet = "aigrette_garzette";
							if(le_idd == 1){ url_au_complet = "aigle_royal";}
							if(le_idd == 2){ url_au_complet = "aigrette_bleue";}
							if(le_idd == 3){ url_au_complet = "aigrette_garzette";}
							if(le_idd == 4){ url_au_complet = "grand_heron";}
							if(le_idd == 5){ url_au_complet = "arlequin_plongeur";}
							if(le_idd == 6){ url_au_complet = "harfang_des_neiges";}
							if(le_idd == 7){ url_au_complet = "hirondelle_rustique";}
							if(le_idd == 8){ url_au_complet = "merle_amerique";}
							if(le_idd == 9){ url_au_complet = "moineau";}
							if(le_idd == 10){ url_au_complet = "sizerin_flamme";}



							theObject_oiseau["IDPhoto"] = url_au_complet;
							theObject_oiseau["IDSon"] = url_au_complet;




							delete theObject_oiseau["Photos"];	

							
							
							//Renommer des elements au json
							theObject_oiseau["id"] = theObject_oiseau["ID"];
							delete theObject_oiseau["ID"];
							
							theObject_oiseau["espece"] = theObject_oiseau["Espece"];
							delete theObject_oiseau["Espece"];
							
							theObject_oiseau["description"] = theObject_oiseau["Description"];
							delete theObject_oiseau["Description"];	
							
							//Ajouter des elements au json
							//theObject_oiseau["IDPhoto"] = "";
							
							theObject_oiseau["flObsPermises"] = true;
						
							une_variable_json.result.push(theObject_oiseau);
			
							/*
							"id": 1,
							"espece": "Aigle royal",
							"description": "L'Aigle royal (Aquila chrysaetos) est une espèce de grands rapaces de la famille des Accipitridae. C'est un oiseau brun foncé, avec un plumage plus brun-doré sur la tête et le cou. L'aigle royal utilise son agilité, sa vitesse et ses serres extrêmement puissantes pour attraper ses proies : des lapins, des marmottes, des écureuils, et de grands mammifères comme les renards, les chats sauvages et domestiques, de jeunes chèvres de montagne, de jeunes bouquetins, et de jeunes cervidés. Il consomme aussi des charognes, si les proies sont rares, ainsi que des reptiles. Des oiseaux, dont des espèces de grande taille comme des cygnes ou des grues, des corbeaux et des Goélands marins ont tous été reportés comme proies potentielles.",
							"IDPhoto": "aigle_royal",
							"IDSon": "aigle_royal",
							"flObsPermises": true
							*/
							str_output2 = JSON.stringify(une_variable_json, null, "\t");
							str_output = str_output2;		
						
						}
					
					}else{
						
						
					}					

					
					
					//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + str_output+"\n--------------------------------------------------------------------\n\n";

					
					
					
					
					/*
					var sadsaasddads = JSON.stringify(str_outpu2, null, "\t");
					alert(sadsaasddads);
					
					
					//document.getElementById("id_textarea_01").value = document.getElementById("id_textarea_01").value + sadsaasddads+"\n--------------------------------------------------------------------\n\n";
					*/
	
					
					file2obj(str_output, chmp_de_rech, type_de_recherche);              
                 }
             }
         }
		 
         request.send();
      } catch (e) {
         //errorEvent(e);
     }
 }





 function file2obj(le_str_output, ch_de_rech, typ_de_rech) 
 { 

	/* 
	 type_de_recherche="List_view"
	 type_de_recherche="get_espece_str"
	*/
	

//	 alert(le_str_output);
//	 alert('le_str_output.length ' + le_str_output.length);
	 
	 localString = JSON.parse(le_str_output);
	
//	 alert('localString.result.length ' + localString.result.length);
//	 alert('id ' + localString['id']);
//	 alert('jsonrpc ' + localString['jsonrpc']);
//	 alert('total ' + localString['total']);
//	 alert('result ' + localString['result']);	
	
	
	 for(var i=0;i<localString.result.length;i++){
		var obj = localString.result[i];
		
		//alert(ch_de_rech+'/'+localString.result[i].espece+'/'+localString.result[i].espece.indexOf(ch_de_rech));
		
		if(typ_de_rech=="List_view"){
			
			var le_espece = localString.result[i].espece;
			le_espece = le_espece.toLowerCase();
			ch_de_rech = ch_de_rech.toLowerCase();
	
			if (le_espece.indexOf(ch_de_rech) !== -1)
			{
					obj2cell(localString.result[i].id,localString.result[i].espece,localString.result[i].description,
				localString.result[i].IDPhoto,localString.result[i].IDSon,localString.result[i].flObsPermises)
			}
		}
	
		if(typ_de_rech=="get_espece_str"){	
			
			var le_bon_id = localString.result[i].id;
			
			//alert("ch_de_rech: "+ch_de_rech+", le_bon_id:"+le_bon_id);
			
			if (le_bon_id == ch_de_rech)
			{
				//alert("yeaaa:"+localString.result[i].espece);
				document.getElementById('id_Observ_oiseau_espece_data').value = localString.result[i].espece;
			}
		}		
	 }
		
 	    /*
		alert(localString.result[i].id +' '+localString.result[i].espece);
 		alert(localString.result[i].id);
 		alert(localString.result[i].espece);
 		alert(localString.result[i].description);
 		alert(localString.result[i].IDPhoto);
  		*/
	
 }
 
 
 

 function obj2cell(le_id, l_espece,  la_descrip, le_IDPhoto , le_IDSon ,le_flObsPermises) {
			
 	var newDiv1 = document.createElement("div");
 	newDiv1.setAttribute("class", "la_liste1");
 	newDiv1.setAttribute("align", "left");
 	newDiv1.id="id_div_liste_commentaires";	

	var audio = document.createElement('audio');
	audio.src = "sons/"+le_IDSon+".mp3";
	audio.controls = true;
	audio.autoplay = false;
	audio.setAttribute("class", "bird_audio");
	newDiv1.appendChild(audio);

	
 	var newImg2 = document.createElement("img");
 	newImg2.src="img/musical_note.png";
	newImg2.setAttribute("class", "speaker_img");
	newDiv1.appendChild(newImg2);



 	var newImg1 = document.createElement("img");
	newImg1.src="birds/"+le_IDPhoto+".jpg";
	newImg1.setAttribute("class", "bird_img");
	newImg1.setAttribute("id", randomcssid());
	newImg1.addEventListener('click',autresphotos,false);
    newDiv1.appendChild(newImg1);
	
	var newP2 = document.createElement("p");
 	var newP2Content = document.createTextNode(l_espece);
 	newP2.setAttribute("class", "bird_espece");
    newP2.appendChild(newP2Content);
	newDiv1.appendChild(newP2);	
	
	
	// mettre ou ne pas mettre le bouton selon le flag  flObservationRequise
	if (le_flObsPermises === true)
	{
	var newRadio4 = document.createElement("input");
	newRadio4.setAttribute("type", "button");
	//newRadio4.setAttribute('checked', '');
	newRadio4.setAttribute("class", "ajout_observ_button");
	newRadio4.setAttribute("value", "Ajouter une observation");
	//newRadio4.setAttribute("id", "bouton_effacer_ligne");
	newRadio4.addEventListener('click',function(){onClickBoutonAjouterObservation(le_id);},false);
	newDiv1.appendChild(newRadio4);		
    }
  
  
  	var newBoutonAlerte = document.createElement("input");
	newBoutonAlerte.setAttribute("type", "button");
	//newBoutonAlerte.setAttribute('checked', '');
	newBoutonAlerte.setAttribute("class", "ajout_alerte_button");
	newBoutonAlerte.setAttribute("value", "Recevoir alertes");

	newBoutonAlerte.addEventListener('click',function(){onClickBoutonActiverAlertePourUnOiseau(le_id);},false);
	newDiv1.appendChild(newBoutonAlerte);		
  
  
  
  
  
  
 	var newP1 = document.createElement("p");
	//var newP1Content = document.createTextNode(tronquetxt(la_descrip));
 	var newP1Content = document.createTextNode(la_descrip);
	newP1.setAttribute("class", "bird_descript");
 	newP1.appendChild(newP1Content);	
	newDiv1.appendChild(newP1);	
	

	
	
							
 	my_mainDiv = document.getElementById("div_main");  
 	my_mainDiv.appendChild(newDiv1);
		
	
 }


 function tronquetxt(texte){
	var sous_chaine = texte.substr(0,250)+" ...";
	return sous_chaine
 }


 function getRandomArbitrary(min, max) {
    return Math.round(Math.random() * (max - min) + min);
 }


 function randomcssid(){
	return "bird_img"+getRandomArbitrary(1,4);
 }

 
 
 function autresphotos(){
 	alert("D'autres photos suivront...");
 }
 

