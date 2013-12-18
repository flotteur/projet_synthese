

function AgCartesAffaires(myName) {
	this.myCartesName = "777";
	this.myCartesArray = [];
}




AgCartesAffaires.prototype.saveCartesToLocalStorage = function() {
	
	//alert(this.myCartesArray.length);
	
	//alert(this.myCartesName);
	localStorage.setItem("lsCartesArray", JSON.stringify(this.myCartesArray));
	localStorage.setItem("lsCartesName", this.myCartesName);
		
	//var myName = document.getElementById("name");
    //var age = document.getElementById("age");
    
    try {
       	localStorage.setItem("lsCartesArray", JSON.stringify(this.myCartesArray));
		localStorage.setItem("lsCartesName", this.myCartesName);
     
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


AgCartesAffaires.prototype.getFromLocalStorage = function() {
	
	//alert("getFromLocalStorage");
	//alert(this.myCartesArray.length);
		
	var objMyName = localStorage.getItem("lsCartesName");
	var objMyArr = localStorage.getItem("lsCartesArray");
	// Vérifier si fichier existe et n'est pas trop vieux  
	if ((typeof objMyName === "undefined" ) || (typeof objMyArr === "undefined" )){
		//alert("Non");
		//Si fichier n'existe pas sur ordi ou il est trop vieux alors on le download et on le mets dans le canvas pour pouvoir le sauvegarder sur le disque
		//this.myCartesArray = [];
		//objListeDesDocCoord = new AgListeDesDocCoord("blabla");
	
	
	

	}else{
		//alert("Oui");
		//alert(this.myCartesName);
		//alert("lsCartesArray: "+localStorage.lsCartesArray);
		
		
		if (localStorage.lsCartesName && localStorage.lsCartesName != "undefined" && localStorage.lsCartesName != "null") {
			this.myCartesName = localStorage.lsCartesName;
		}

		if (localStorage.lsCartesArray && localStorage.lsCartesArray != "undefined" && localStorage.lsCartesArray != "null") {
			this.myCartesArray = JSON.parse(localStorage.lsCartesArray); 
		}else{
			this.myCartesArray = [];
		}
	
		//alert('there are ' + localStorage.length + ' items in the storage array.');
		
		
	}

}



AgCartesAffaires.prototype.addListViewCarteCell = function(le_CarteDescrip, le_CarteDiskName, le_datURLPicture, le_index) {
	
	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "listViewCartes");
	newDiv1.setAttribute("align", "left");
	
	newDiv1.id="liste_cartes1";	
	//strCarteDescrip, strCarteDiskName
	//newDiv1.addEventListener('click', test55, false)
	
	
	var newH2 = document.createElement("h4");
	var newH2Content = document.createTextNode("Description: "+le_CarteDescrip);
	
	//newH2.addEventListener('click',function(){afficheEcranCarte(le_CarteDescrip, le_CarteDiskName, le_datURLPicture)},false);
	
	newH2.appendChild(newH2Content);
	
	
	
	
	var newP = document.createElement("p");
	
	var newPContent = document.createTextNode("Nom du fichier: "+le_CarteDiskName);
	newP.appendChild(newPContent);	
	
	
	 //var radioHtml = "<input type='checkbox' checked='checked' name='ASXSW' value='I am Checkbox 1' ></input>";

	
	var newRadio = document.createElement("input");
	newRadio.setAttribute("type", "checkbox");
	//newRadio.setAttribute('checked', '');
	newRadio.setAttribute("class", "checkbox1");




	var newDivTouch = document.createElement("div");
	newDivTouch.setAttribute("class", "divTouch");
	newDivTouch.addEventListener('click',function(){afficheEcranCarte(le_CarteDescrip, le_CarteDiskName, le_datURLPicture, le_index)},false);

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


AgCartesAffaires.prototype.ajouterUneNouvelleCarte = function(strCarteDescrip, strCarteDiskName, the_pic_dataURL) {

	

//alert("ajouterUneNouvelleCarte Start");

	
//alert(la_description+"/"+le_nom_de_limage);

	var carteObject1 = new Object();
	carteObject1.strCarteDescrip = strCarteDescrip;
	carteObject1.strCarteDiskName = strCarteDiskName;
	carteObject1.dataURLPicture = the_pic_dataURL;
	this.myCartesArray.push(carteObject1);
	//this["myArrayObject"].push(carteObject1);
	
//alert("ajouterUneNouvelleCarte End");	
	
	
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










AgCartesAffaires.prototype.checkSiIndexExiste = function(le_numero) {
	
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	//var myVar = this.myCartesArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.
	//alert("checkSiIndexExiste");
	
	var myArrayObject = JSON.parse(localStorage.getItem("lsCartesArray"));
	
	varOutPut="0";
	
	if (myArrayObject==null || myArrayObject=="undefined"){
		//alert("5555");
	}else{
		//alert(le_numero+"/"+myArrayObject.length);
		if(parseInt(le_numero) < myArrayObject.length){
			varOutPut="1";
		}
	}	
	return varOutPut;
}



AgCartesAffaires.prototype.getArrayLength = function(le_numero) {
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	//var myVar = this.myCartesArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.

	var myArrayObject = JSON.parse(localStorage.getItem("lsCartesArray"));
	//alert("888"+myArrayObject);
	
	varOutVal1=0;
	if (myArrayObject==null || myArrayObject=="undefined"){
		//alert("5555");
	}else{
		//alert("4444");
		varOutVal1=myArrayObject.length;
	}
	//alert("getArrayLength:"+myArrayObject.length);
	return varOutVal1;

}

AgCartesAffaires.prototype.viewData = function() {
	//var tp1DataStorage = localStorage.getItem("tp1DataStorage");
	
	//var myVar = this.myCartesArray.toString(); // assigns "Jan,Feb,Mar,Apr" to myVar.
	alert("viewData");
	var myArrayObject = JSON.parse(localStorage.getItem("lsCartesArray"));
	alert(myArrayObject.length);
	for (var i=0; i<myArrayObject.length; i++){
		var personObject = myArrayObject[i];
		//alert("strCarteDescrip: " + personObject.strCarteDescrip, "strCarteDiskName: " + personObject.strCarteDiskName);
	}
	
	//alert("viewData end");
	
	//alert(myVar);
}


AgCartesAffaires.prototype.fillCartesListView = function() {
	
	//alert("fillCartesListView");
	//alert(this.myCartesArray.length);
	
	for (var i=0; i < this.myCartesArray.length; i++){
		var theObject = this.myCartesArray[i];
		//alert("strCarteDescrip: " + theObject.strCarteDescrip, "strCarteDiskName: " + theObject.strCarteDiskName);
		
		
		//ici ici ici
		
		
		
		this.addListViewCarteCell(theObject.strCarteDescrip, theObject.strCarteDiskName, theObject.dataURLPicture, i);
		
		//le_id, le_non_fich, le_url, la_descrip, la_date_eng
	}
	//alert("fillCartesListView end");
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




AgCartesAffaires.prototype.removeAllCartesFromListView = function() {	
	
	var element = document.getElementById("main");

	//alert("removeAllCartesFromListView: "+element.childNodes.length);
	for (var i=0; i < element.childNodes.length; i++){
		var theObject = element.childNodes[i];		
		
		//alert(theObject.className);
		if(theObject.className == "listViewCartes"){
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i=-1;		
			//element.removeChild(theObject);
		}
	}
}





AgCartesAffaires.prototype.removeSelectedCartesFromListView = function() {
	var les_lignes = document.getElementsByClassName('listViewCartes');
	//alert(les_lignes.length+"/"+this.myCartesArray.length);
	for (var i=0; i < les_lignes.length; i++){
		var theObject = les_lignes[i];		
		var le_checkBox = theObject.getElementsByClassName('checkbox1');
		//alert(le_checkBox.length);
		if(le_checkBox[0].checked == true){	
			this.myCartesArray.splice(i,1);
			//alert("99999");	
			theObject.parentNode.removeChild(theObject);
			i=-1;		
		}			
	}
}





