

function AgListeDesDocCoord(myName) {
	this.myName = "777";
	this.myArrayObject = [];
}




AgListeDesDocCoord.prototype.saveToLocalStorage = function() {
	
	//alert("saveToLocalStorage");
	
	//alert(this.myName);
	localStorage.setItem("lsArrayDesPositions2", JSON.stringify(this.myArrayObject));
	localStorage.setItem("lsMyName2", this.myName);
		
	//var myName = document.getElementById("name");
    //var age = document.getElementById("age");
    
    try {
       	localStorage.setItem("lsArrayDesPositions2", JSON.stringify(this.myArrayObject));
		localStorage.setItem("lsMyName2", this.myName);
     
    }
    catch (e) {
        if (e == QUOTA_EXCEEDED_ERR) {
            alert("Error: Local Storage limit exceeds.");
        }
        else {
            alert("Error: Saving to local storage.");
        }
    }
		
		
	//alert("saveToLocalStorage2");
}


AgListeDesDocCoord.prototype.getFromLocalStorage = function() {
	
	//alert("getFromLocalStorage");
	//alert(this.myArrayObject.length);
		
	var objMyName = localStorage.getItem("lsMyName2");
	var objMyArr = localStorage.getItem("lsArrayDesPositions2");
	// Vérifier si fichier existe et n'est pas trop vieux  
	if ((typeof objMyName === "undefined" ) || (typeof objMyArr === "undefined" )){
		//alert("Non");
		//Si fichier n'existe pas sur ordi ou il est trop vieux alors on le download et on le mets dans le canvas pour pouvoir le sauvegarder sur le disque
		//this.myArrayObject = [];
		//objListeDesDocCoord = new AgListeDesDocCoord("blabla");
	
	
	

	}else{
		//alert("Oui");
		//alert(this.myName);
		//alert("lsArrayDesPositions2: "+localStorage.lsArrayDesPositions2);
		
		
		if (localStorage.lsMyName2 && localStorage.lsMyName2 != "undefined" && localStorage.lsMyName2 != "null") {
			this.myName = localStorage.lsMyName2;
		}

		if (localStorage.lsArrayDesPositions2 && localStorage.lsArrayDesPositions2 != "undefined" && localStorage.lsArrayDesPositions2 != "null") {
			this.myArrayObject = JSON.parse(localStorage.lsArrayDesPositions2); 
		}else{
			this.myArrayObject = [];
		}
	
		//alert('there are ' + localStorage.length + ' items in the storage array.');
		
		
	}

	
	/*
	
	//alert("getFromLocalStorage");
	this.myName = localStorage.getItem("lsMyName2");
	//alert(this.myName);
	this.myArrayObject = JSON.parse(localStorage.getItem("lsArrayDesPositions2"));
	*/
	/*
	for (var i=0; i<myArrayObject.length; i++){
		var personObject = myArrayObject[i];
		alert("strDocName: " + personObject.strDocName, "strDocCoord: " + personObject.strDocCoord, "strDocDate: " + personObject.strDocDate);
	}
	*/
}



AgListeDesDocCoord.prototype.addDocCoordCell = function(le_non_fich, la_coord, la_date_eng) {
	
	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "listViewDocCoord");
	newDiv1.setAttribute("align", "left");
	
	newDiv1.id="liste_fichiers1";	
	
	//newDiv1.addEventListener('click', test55, false)
	//newDiv1.addEventListener('click',function(){affichePageFichier(le_id, le_non_fich, le_url, la_descrip, la_date_eng)},false);
	
	var newH2 = document.createElement("h2");
	var newH2Content = document.createTextNode("Nom: "+le_non_fich);
	newH2.appendChild(newH2Content);
	
	var newP = document.createElement("p");
	var newPContent = document.createTextNode("Date du téléchargement: "+la_date_eng);
	newP.appendChild(newPContent);	

	var newP2 = document.createElement("p");
	var newPContent2 = document.createTextNode("Coordonée GPS: "+la_coord);
	newP2.appendChild(newPContent2);		
	
	var newRadio = document.createElement("input");
	newRadio.setAttribute("type", "checkbox");
	//newRadio.setAttribute('checked', '');
	newRadio.setAttribute("class", "checkbox1");




	var newDivTouch = document.createElement("div");
	newDivTouch.setAttribute("class", "divTouch");
	newDivTouch.addEventListener('click',function(){afficheEcranCarte(le_CarteDescrip, le_CarteDiskName, le_datURLPicture, le_index)},false);
	
	
	
	
	
	
	newDiv1.appendChild(newH2);	
	newDiv1.appendChild(newP);	
	newDiv1.appendChild(newP2);	
	newDiv1.appendChild(newRadio);	
	newDiv1.appendChild(newDivTouch);		
				
	my_mainDiv = document.getElementById("main");  
	my_mainDiv.appendChild(newDiv1);
	
	
		
}


AgListeDesDocCoord.prototype.appendGpsPosition = function(strDocName, strDocCoord, strDocDate) {

	

//alert("appendGpsPosition Start");

	var personObject1 = new Object();



	personObject1.strDocName = strDocName;
	personObject1.strDocCoord = strDocCoord;
	personObject1.strDocDate = strDocDate;


	this.myArrayObject.push(personObject1);
	//this["myArrayObject"].push(personObject1);
	
//alert("appendGpsPosition End");	
	
	
}

/*
var keyNames[]; 
var values[]; 
// iterate through array
var numKeys = localStorage.length; 
for(i=0;i<numKeys;i++) { 
    // get key name into an array 
    keyNames[i]=localStorage.key(i); 
    // use key name to retreive value and store in array 
    values[i]=localStorage.getItem(keyNames[i]); 
} 
*/













AgListeDesDocCoord.prototype.viewData = function() {
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	
	//var myVar = this.myArrayObject.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.
	alert("viewData");
	var myArrayObject = JSON.parse(localStorage.getItem("lsArrayDesPositions2"));
	alert(myArrayObject.length);
	for (var i=0; i<myArrayObject.length; i++){
		var personObject = myArrayObject[i];
		//alert("strDocName: " + personObject.strDocName, "strDocCoord: " + personObject.strDocCoord, "strDocDate: " + personObject.strDocDate);
	}
	
	//alert("viewData end");
	
	//alert(myVar);
}


AgListeDesDocCoord.prototype.viewArrData = function() {
	
	//alert("viewArrData");
	//alert(this.myArrayObject.length);
	
	for (var i=0; i < this.myArrayObject.length; i++){
		var personObject = this.myArrayObject[i];
		//alert("strDocName: " + personObject.strDocName, "strDocCoord: " + personObject.strDocCoord, "strDocDate: " + personObject.strDocDate);
		
		this.addDocCoordCell(personObject.strDocName, personObject.strDocCoord, personObject.strDocDate);
		
		//le_id, le_non_fich, le_url, la_descrip, la_date_eng
	}
	//alert("viewArrData end");
	//alert(myVar);
}



AgListeDesDocCoord.prototype.removeAllDocCoordFromListView = function() {	
	var element = document.getElementById("main");
	//alert("removeAllFichiersFromListView");
	//alert("removeAllCartesFromListView: "+element.childNodes.length);
	for (var i=0; i < element.childNodes.length; i++){
		var theObject = element.childNodes[i];		
		
		//alert(theObject.className);
		if(theObject.className == "listViewDocCoord"){
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i=-1;		
			//element.removeChild(theObject);
		}
	}
}


AgListeDesDocCoord.prototype.removeSelectedDocCoordFromListView = function() {
	var les_lignes = document.getElementsByClassName('listViewDocCoord');
	//alert(les_lignes.length+"/"+this.myArrayObject.length);
	for (var i=0; i < les_lignes.length; i++){
		var theObject = les_lignes[i];		
		var le_checkBox = theObject.getElementsByClassName('checkbox1');
		//alert(le_checkBox.length);
		if(le_checkBox[0].checked == true){	
			this.myArrayObject.splice(i,1);
			//alert("99999");	
			theObject.parentNode.removeChild(theObject);
			i=1-1;		
		}			
	}
}



function onClickBoutonTelechargerLeFichier()
{			
	//strDocName, strDocCoord, strDocDate

	//alert("11111");
	document.getElementById('id_id_d2').innerHTML = "Recherche de position un instant ...";
	//alert("22222");
	
	
	var ddd = new Date();
	var newFormatDate = agConvertDate1(ddd);
	
	/*	
	getYear()
	setDate()
	setFullYear()
	setHours()
	setMilliseconds()
	setMinutes()
	setMonth()
	setSeconds()
	*/

	
	
	id_id_d =  document.getElementById("id_id_d").innerHTML;
	id_filename_d =  document.getElementById("id_filename_d").innerHTML;
	id_registered_d =  newFormatDate;
	id_gps_position =  "";	
			
			
	leGps1.getPosOnly(id_filename_d, id_gps_position, id_registered_d);
			
			//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
			//new Date(position.timestamp)
	//(new Date()).toUTCString()
	//(new Date()).toString()
	
		//alert("appendGpsPosition");
}


