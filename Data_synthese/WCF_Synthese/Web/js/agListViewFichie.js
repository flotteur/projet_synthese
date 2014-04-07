//Section pour l'affichage et le téléchargement des fichiers 



function ClasseListViewFichier(myName) {
	//alert(myName);
	this.myListViewFichierName = "777";
	this.myListViewFichierArray = [];
}



ClasseListViewFichier.prototype.agXMLHttpReqFichiers = function(le_url) {
	

     
	var storageFiles = JSON.parse(localStorage.getItem("storageFilesFichiers3")) || {},
	storageFilesDate = storageFiles.date1,
	date = new Date(),
	//todaysDate = (date.getMonth() + 1).toString() + date.getDate().toString();
	todaysDate=agConvertDate2(date);
	
	//alert(storageFilesDate+"/"+todaysDate); 
    // Vérifier si fichier existe et n'est pas trop vieux 
	//Télécharger seulement une fois par jour. Si pas date d'aujourd'hui on télécharge
    if (typeof storageFilesDate === "undefined" || storageFilesDate != todaysDate) 
	{

		 //alert(le_url);
		try {
			var resourcePath = le_url;
			
			var request = new XMLHttpRequest();
			
			request.open("GET", resourcePath, true);
			request.onreadystatechange = function(){
				if (request.readyState == 4) {
					if (request.status == 200 || request.status == 0) {
					
						str_output = request.responseText;
						
						storageFiles.date1 = todaysDate;
						storageFiles.output = str_output;
						try {
							localStorage.setItem("storageFilesFichiers3", JSON.stringify(storageFiles));
						}
						catch (e) {
								alert("Storage failed: " + e);                
						}
						objListViewFichiers.fillFichiersListView(str_output); 
						
					}
				}
			}
			request.send();
			
		 } catch (e) {
			//errorEvent(e);
		}
    }
    else {
	   str_output = storageFiles.output;
	   objListViewFichiers.fillFichiersListView(str_output); 
	   //storageFiles.output = str_output;
    }
}





ClasseListViewFichier.prototype.addFichiersListViewCell = function(le_id, le_non_fich, le_url, la_descrip, la_date_eng) {
	
		
	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "la_liste1");
	newDiv1.setAttribute("align", "left");
	
	newDiv1.id="id_div_liste_fichiers1";	
	
	//newDiv1.addEventListener('click', test55, false)
	newDiv1.addEventListener('click',function(){affichePageXXXXX(le_id, le_non_fich, le_url, la_descrip, la_date_eng)},false);
	
	var newH2 = document.createElement("h2");
	var newH2Content = document.createTextNode(le_non_fich);
	newH2.appendChild(newH2Content);
	
	var newP = document.createElement("p");
	var newPContent = document.createTextNode(le_url);
	newP.appendChild(newPContent);	

	newDiv1.appendChild(newH2);	
	newDiv1.appendChild(newP);	
	
	
				
	my_mainDiv = document.getElementById("div_main");  
	my_mainDiv.appendChild(newDiv1);
	
	
		
}


ClasseListViewFichier.prototype.fillFichiersListView = function(le_str_output) {
	

	localString = JSON.parse(le_str_output);
	
	/*
    alert(le_str_output);
	alert('le_str_output.length ' + le_str_output.length);
    alert('localString.result.length ' + localString.result.length);
	alert('id ' + localString['id']);
	alert('jsonrpc ' + localString['jsonrpc']);
	alert('total ' + localString['total']);
	alert('result ' + localString['result']);
	*/
	
	
    //var JSONstring=[{"key1":"value1","key2":"value2"},{"key3":"value3"}];

	for(var i=0;i<localString.result.length;i++){
	var obj = localString.result[i];
		
		
	    /*
		alert(localString.result[i].id);
		alert(localString.result[i].filename);
		alert(localString.result[i].url);
		alert(localString.result[i].description);
		alert(localString.result[i].registered);	
			
		*/
		
		objListViewFichiers.addFichiersListViewCell(localString.result[i].id, localString.result[i].filename, localString.result[i].url, localString.result[i].description, localString.result[i].registered)
		/*
		 for(var key in obj){
				 var attrName = key;
				 var attrValue = obj[key];
				if(attrName=="id"){alert(attrName+"/"+attrValue);}
				if(attrName=="filename"){alert(attrName+"/"+attrValue);}
				//alert(attrName+"/"+attrValue);
				
				
			}
		*/	
	}
		
}






ClasseListViewFichier.prototype.removeAllFichiersFromListView = function(le_url) {


	var element = document.getElementById("div_main");
	//alert("removeAllFichiersFromListView");
	//alert("removeAllFichiersFromListView: "+element.childNodes.length);
	for (var i=0; i < element.childNodes.length; i++){
		var theObject = element.childNodes[i];		
		
		//alert(theObject.className);
		if(theObject.className == "la_liste1"){
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i=-1;		
			//element.removeChild(theObject);
		}
	}
}

