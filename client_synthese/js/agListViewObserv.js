

function ClasseListViewObservations(myName) {
	this.myListViewObservName = "777";
	this.myListViewObservArray = [];
}




ClasseListViewObservations.prototype.saveObservToLocalStorage = function() {
	
	//alert(this.myListViewObservArray.length);
	
	//alert(this.myListViewObservName);
	localStorage.setItem("lsListViewObservArray", JSON.stringify(this.myListViewObservArray));
	localStorage.setItem("lsListViewObservName", this.myListViewObservName);
		
	//var myName = document.getElementById("name");
    //var age = document.getElementById("age");
    
    try {
       	localStorage.setItem("lsListViewObservArray", JSON.stringify(this.myListViewObservArray));
		localStorage.setItem("lsListViewObservName", this.myListViewObservName);
     
    }
    catch (e) {
        if (e == QUOTA_EXCEEDED_ERR) {
            alert("Error: Local Storage limit exceeds.");
        }
        else {
            alert("Error: Saving to local storage.");
        }
    }
		
		
	//alert("Image sauvegardée avec succès!");
}


ClasseListViewObservations.prototype.getObservFromLocalStorage = function() {
	
	//alert("getObservFromLocalStorage");
	//alert(this.myListViewObservArray.length);
		
	var objMyName = localStorage.getItem("lsListViewObservName");
	var objMyArr = localStorage.getItem("lsListViewObservArray");
	// Vérifier si fichier existe et n'est pas trop vieux  
	if ((typeof objMyName === "undefined" ) || (typeof objMyArr === "undefined" )){
		//alert("Non");
		//Si fichier n'existe pas sur ordi ou il est trop vieux alors on le download et on le mets dans le canvas pour pouvoir le sauvegarder sur le disque
		//this.myListViewObservArray = [];
		//objListeDesDocCoord = new AgListeDesDocCoord("blabla");
	
	
	

	}else{
		//alert("Oui");
		//alert(this.myListViewObservName);
		//alert("lsListViewObservArray: "+localStorage.lsListViewObservArray);
		
		
		if (localStorage.lsListViewObservName && localStorage.lsListViewObservName != "undefined" && localStorage.lsListViewObservName != "null") {
			this.myListViewObservName = localStorage.lsListViewObservName;
		}

		if (localStorage.lsListViewObservArray && localStorage.lsListViewObservArray != "undefined" && localStorage.lsListViewObservArray != "null") {
			this.myListViewObservArray = JSON.parse(localStorage.lsListViewObservArray); 
		}else{
			this.myListViewObservArray = [];
		}
	
		//alert('there are ' + localStorage.length + ' items in the storage array.');
		
		
	}

}



ClasseListViewObservations.prototype.addListViewObservCell = function(le_ObservTitre, le_ObservDescrip, le_ObservDiskName, le_datURLPicture, le_index) {
	
	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "list_View_Observ");
	newDiv1.setAttribute("align", "left");
	
	newDiv1.id="liste_observation1";
	
	var newH2 = document.createElement("h4");
	//var newH2Content = document.createTextNode("Description: "+le_ObservDescrip);
	var newH2Content = document.createTextNode("Titre: "+le_ObservTitre);
	//newH2.addEventListener('click',function(){afficheEcranObservations(le_ObservDescrip, le_ObservDiskName, le_datURLPicture)},false);
	
	newH2.appendChild(newH2Content);
	
	
	
	
	var newP = document.createElement("p");
	
	var newPContent = document.createTextNode("Description: "+le_ObservDescrip);
	newP.appendChild(newPContent);	
	
	
	 //var radioHtml = "<input type='checkbox' checked='checked' name='ASXSW' value='I am Checkbox 1' ></input>";

	
	var newRadio = document.createElement("input");
	newRadio.setAttribute("type", "checkbox");
	//newRadio.setAttribute('checked', '');
	newRadio.setAttribute("class", "checkbox1");




	var newDivTouch = document.createElement("div");
	newDivTouch.setAttribute("class", "divTouch");
	newDivTouch.addEventListener('click',function(){afficheEcranObservations(le_ObservTitre, le_ObservDescrip, le_ObservDiskName, le_datURLPicture, le_index)},false);

	//var newP2 = document.createElement("p");
	//var newPContent2 = document.createTextNode("Coordonée GPS: "+la_coord);
	//newP2.appendChild(newPContent2);		
	
	
	
	newDiv1.appendChild(newH2);	
	newDiv1.appendChild(newP);	
	newDiv1.appendChild(newDivTouch);	
	newDiv1.appendChild(newRadio);	
	
	
	//newDiv1.innerHTML = newDiv1.innerHTML +"88888888888888888888"+ radioHtml;
	
	//newDiv1.appendChild(newP2);	
	
				
	my_mainDiv = document.getElementById("main");  
	my_mainDiv.appendChild(newDiv1);
	

		
}


ClasseListViewObservations.prototype.ajouterUnObservationALobjetListViewObservations = function(strObservTitre, strObservResume, strObservDiskName, the_pic_dataURL) {

	

//alert("ajouterUnObservationALobjetListViewObservations Start");

	
//alert(le_resume+"/"+le_nom_de_limage);

	
	
	
	
	
	var observObject1 = new ClasseObservation();
	
	
	observObject1.strObservTitre = strObservTitre;
	observObject1.strObservResume = strObservResume;
	observObject1.strObservDiskName = strObservDiskName;
	observObject1.dataURLPicture = the_pic_dataURL;
	

	//observObject1.ajouterUneAutrePhotoDansUnObjetObservation("Photo 1",strObservDiskName,the_pic_dataURL);
	//observObject1.ajouterUneAutrePhotoDansUnObjetObservation("Photo 2",strObservDiskName,the_pic_dataURL);
	
	
	
	
	
	this.myListViewObservArray.push(observObject1);	
	
	
	
	//this["myArrayObject"].push(observObject1);
	
//alert("ajouterUnObservationALobjetListViewObservations End");	
	
	
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










ClasseListViewObservations.prototype.checkSiIndexExiste = function(le_numero) {
	
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	//var myVar = this.myListViewObservArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.
	//alert("checkSiIndexExiste");
	
	varOutPut="0";
	
	if(localStorage.getItem("lsListViewObservArray")){
			
		var temp121 = localStorage.getItem("lsListViewObservArray");
		//console.log(temp121);
		
		
		var myArrayObject = JSON.parse(temp121);
		
		
		if (myArrayObject==null || myArrayObject=="undefined"){
			
		}else{
			//alert(le_numero+"/"+myArrayObject.length);
			//ouin ??? metton que
			if(parseInt(le_numero) < myArrayObject.length){
				varOutPut="1";
				
			}
		}

	}
	return varOutPut;
}



ClasseListViewObservations.prototype.getObservArrayLength = function(le_numero) {
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	//var myVar = this.myListViewObservArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.

	var myArrayObject = JSON.parse(localStorage.getItem("lsListViewObservArray"));
	//alert("888"+myArrayObject);
	
	varOutVal1=0;
	if (myArrayObject==null || myArrayObject=="undefined"){
		//alert("5555");
	}else{
		//alert("4444");
		varOutVal1=myArrayObject.length;
	}
	//alert("getObservArrayLength:"+myArrayObject.length);
	return varOutVal1;

}

ClasseListViewObservations.prototype.viewData = function() {
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	
	//var myVar = this.myListViewObservArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.
	alert("viewData");
	var myArrayObject = JSON.parse(localStorage.getItem("lsListViewObservArray"));
	alert(myArrayObject.length);
	for (var i=0; i<myArrayObject.length; i++){
		var personObject = myArrayObject[i];
		//alert("strObservResume: " + personObject.strObservResume, "strObservDiskName: " + personObject.strObservDiskName);
	}
	
	
	//alert(myVar);
}


ClasseListViewObservations.prototype.fillObservsListView = function() {
	
	//alert("fillObservsListView");
	//alert(this.myListViewObservArray.length);
	
	for (var i=0; i < this.myListViewObservArray.length; i++){
		var theObject = this.myListViewObservArray[i];
		
		
		//ici ici ici
		
		
		
		this.addListViewObservCell(theObject.strObservTitre, theObject.strObservResume, theObject.strObservDiskName, theObject.dataURLPicture, i);
		
		//le_id, le_non_fich, le_url, la_descrip, la_date_eng
	}
	//alert("fillObservsListView end");
	//alert(myVar);
}
/*

function deleterow(node) 
{ 

//alert(node);
	var tr = node.parentNode; 
	while (tr.tagName.toLowerCase() != "tr") 
	{//alert("Cherche node/"+node);
		tr = tr.parentNode; 
		//rowNum=rowNum-1;
	}
	
	tr.parentNode.removeChild(tr); 
	//alert("tr.parentNode.removeChild");
} 

*/




ClasseListViewObservations.prototype.removeAllObservFromListView = function() {	
	
	var element = document.getElementById("main");

	//alert("removeAllObservFromListView: "+element.childNodes.length);
	for (var i=0; i < element.childNodes.length; i++){
		var theObject = element.childNodes[i];		
		
		//alert(theObject.className);
		if(theObject.className == "list_View_Observ"){
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i=-1;		
			//element.removeChild(theObject);
		}
	}
}





ClasseListViewObservations.prototype.removeSelectedObservsFromListView = function() {
	var les_lignes = document.getElementsByClassName('list_View_Observ');
	//alert(les_lignes.length+"/"+this.myListViewObservArray.length);
	for (var i=0; i < les_lignes.length; i++){
		var theObject = les_lignes[i];		
		var le_checkBox = theObject.getElementsByClassName('checkbox1');
		//alert(le_checkBox.length);
		if(le_checkBox[0].checked == true){	
			this.myListViewObservArray.splice(i,1);
			//alert("99999");	
			theObject.parentNode.removeChild(theObject);
			i=-1;		
		}			
	}
}





