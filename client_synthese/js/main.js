
function show_ecran_fichier() {
	
	ecran_fichier = document.getElementById('ecran_fichier');
	show_element(ecran_fichier);
}

function hide_ecran_fichier() {
	ecran_fichier = document.getElementById('ecran_fichier');
	hide_element(ecran_fichier);
}


function show_ecran_de_l_observation() {
	
	ecran_observation = document.getElementById('ecran_observation');
	show_element(ecran_observation);
}

function hide_ecran_de_l_observation() {
	ecran_observation = document.getElementById('ecran_observation');
	hide_element(ecran_observation);
}




function showObservationListView() {

  [].forEach.call(document.querySelectorAll("div.list_View_Observ"), function(el) {
    show_element(el);
  });

}

function hideObservationListView() {
  // Remove the hash sign from the start of the id.
    
  // Find all div.screen elements and hide them.
  [].forEach.call(document.querySelectorAll("div.list_View_Observ"), function(el) {
    hide_element(el);
  });
 
}





function show_settings() {
	
	a_setting = document.getElementById('a_setting');
	show_element(a_setting);
}
function hide_settings() {
	a_setting = document.getElementById('a_setting');
	hide_element(a_setting);
}





function show_back_button() {
	
	back_button = document.getElementById('back_button');
	show_element(back_button);
}

function hide_back_button() {
	back_button = document.getElementById('back_button');
	hide_element(back_button);
}

function show_liste_des_fichiers() {

  [].forEach.call(document.querySelectorAll("div.la_liste1"), function(el) {
    show_element(el);
  });

}

function hide_liste_des_fichiers() {
  // Remove the hash sign from the start of the id.
    
  // Find all div.screen elements and hide them.
  [].forEach.call(document.querySelectorAll("div.la_liste1"), function(el) {
    hide_element(el);
  });
 
}
//listViewDocCoord

function show_liste_des_coord_gps() {

  [].forEach.call(document.querySelectorAll("div.listViewDocCoord"), function(el) {
    show_element(el);
  });

}

function hide_liste_des_coord_gps() {
  // Remove the hash sign from the start of the id.
    
  // Find all div.screen elements and hide them.
  [].forEach.call(document.querySelectorAll("div.listViewDocCoord"), function(el) {
    hide_element(el);
  });
 
}





function hide_menu1() {

 my_menu1 = document.getElementById("le_menu1");
 hide_element(my_menu1);
}

function show_menu1() {

 my_menu1 = document.getElementById("le_menu1");
 show_element(my_menu1);
}


function hide_all() {
	hide_settings();
	//hide_liste_observs();
		//alert("11122222");
	objListViewObservations.removeAllObservFromListView();
		
	removeAllFichiersFromListView();
	
	hide_menu1();
	//hide_liste_des_fichiers();
	
	
	
	hideLogin();
	hide_ecran_fichier();
	
	//hide_liste_des_coord_gps();
	objListeDesDocCoord.removeAllDocCoordFromListView();
	
	
	hide_ecran_de_l_observation();
	document.getElementById("tool_button").style.visibility="hidden";
	document.getElementById("tool_button2").style.visibility="hidden";

}


		
function showLogin(){

	le_my_login = document.getElementById('my_login');
	show_element(le_my_login);


}

		
function hideLogin(){

	le_my_login = document.getElementById('my_login');
	hide_element(le_my_login);


}

function onClickButtonListDocCoord()
{
	hide_all();
	objListeDesDocCoord.viewArrData();
	document.getElementById("tool_button").style.visibility="visible";
}


function get_lang_callback(le_str_output) 
{ 
	localString = JSON.parse(le_str_output);
	
	document.getElementById("id_bouton_liste_fichiers1").innerHTML = localString['str_bouton_liste_des_fichiers'];
	document.getElementById("id_bouton_liste_des_observations").innerHTML = localString['str_bouton_liste_des_observs'];
	document.getElementById("id_bouton_setting").innerHTML = localString['str_bouton_parametres'];
	document.getElementById("id_utilisateur_label").innerHTML = localString['str_label_utilisateur'];
	document.getElementById("id_motDePasse_label").innerHTML = localString['str_label_motDePasse'];
	document.getElementById("id_actualiser").innerHTML = localString['str_bouton_actualiser'];
	document.getElementById("id_bouton_ajout_observation").innerHTML = localString['str_bouton_ajout_observation'];
	
	
	
	
}



function onClickBoutonSaveObservation() 
{ 
	var le_titre = document.getElementById('id_ObservTitre_data').value;
	var le_resume = document.getElementById('id_ObservResume_data').value;
	
	
	
	
	
	
	/*
	var le_nom_de_limage = "";
	if(document.getElementById('take-picture')){
		le_nom_de_limage = document.getElementById('take-picture').value;	
	}
	*/
	
	var id_cell_index = document.getElementById('id_cell_index').innerHTML;
	

	//alert("id_cell_index:"+id_cell_index);
	
	
	if (objListViewObservations.checkSiIndexExiste(id_cell_index)!="1") {	
		//Index n'existe pas ca veut dire qu'on insert
		
	
		var test6432 = "";

		try {
			 //if (true) {
			 //      throw "An error";
			 // }
		  
			  var test5434 = laCamera1.agImgToCanvasToDataURL();
			  test6432 = JSON.stringify(test5434);
			  return true;
		 } catch (e) {
			  alert (e);
			  return true;
		 } finally {
			//do cleanup, etc here
			//On sauvegarde le reste des données quand même si pas de photo  
			
			//alert("444444:"+varGlobalNomImage);
			objListViewObservations.ajouterUnObservationALobjetListViewObservations(le_titre, le_resume, varGlobalNomImage, test6432);
			objListViewObservations.saveObservToLocalStorage();  
		 }	
			
	
	
	}else{	
	
		
		//Si index existe ca veut dire qu'on modifie

		objListViewObservations.myListViewObservArray[id_cell_index].strObservTitre=le_titre;
		objListViewObservations.myListViewObservArray[id_cell_index].strObservResume=le_resume;
		
		objListViewObservations.myListViewObservArray[id_cell_index].strObservDiskName=varGlobalNomImage;
		objListViewObservations.myListViewObservArray[id_cell_index].dataURLPicture=JSON.stringify(laCamera1.agImgToCanvasToDataURL());		
		objListViewObservations.saveObservToLocalStorage();
	}
	

	
	
}



function onClickAjouterUneAutrePhoto() 
{ 
	var id_cell_index = document.getElementById('id_cell_index').innerHTML;
	
	prendreLImageDuCanvasEtLAjouterDansLesAutresPhotosDunObjetObservation(id_cell_index);
	
	//vider le ul
	removeAllPhotosFromUL();
	//ré-insérer les photos dans le UL et afficher					
	remplirEtAfficheLeULDesPhotos(id_cell_index);
}

function prendreLImageDuCanvasEtLAjouterDansLesAutresPhotosDunObjetObservation(le_index_oui) 
{ 

	var test6432 = "";
	
	if (objListViewObservations.checkSiIndexExiste(le_index_oui)!="1") {	
		//si Index n'existe pas ca veut que ca bug
	}else{
		//Index existe alors on retrouve l'objet "Observation" et on insert une nouvelle photos (provenant du canvas) dans l'observation
	
		try {
			 //if (true) {
			 //      throw "An error";
			 // }
		
			  var test5434 = laCamera1.agImgToCanvasToDataURL();
			  test6432 = JSON.stringify(test5434);
			  return true;
		 } catch (e) {
			  alert (e);
			  return true;
		 } finally {
		 
			
			var observObject2 = new ClasseObservation();
	
	
			observObject2.strObservTitre = objListViewObservations.myListViewObservArray[le_index_oui].strObservTitre;
			
			observObject2.strObservResume = objListViewObservations.myListViewObservArray[le_index_oui].strObservResume;
			
			observObject2.strObservDiskName = objListViewObservations.myListViewObservArray[le_index_oui].strObservDiskName;
			
			observObject2.dataURLPicture = objListViewObservations.myListViewObservArray[le_index_oui].dataURLPicture;
			
			observObject2.arrLesObjetsPhotos = objListViewObservations.myListViewObservArray[le_index_oui].arrLesObjetsPhotos;
			
		
			
			//var dataPhoto2=objListViewObservations.myListViewObservArray[indexObserv].arrLesObjetsPhotos[indexPhoto].dataURLPhoto;
			//this.myListViewObservArray.push(observObject1);		
							
				
			//alert("strObservDiskName:"+observObject2.strObservDiskName);
			//objListViewObservations.ajouterUnObservationALobjetListViewObservations(le_titre, le_resume, varGlobalNomImage, test6432);
			
			observObject2.ajouterUneAutrePhotoDansUnObjetObservation("Photo 1",varGlobalNomImage,test6432);
			
			
	
		
			
			
			//objListViewObservations.saveObservToLocalStorage(); 

		}
		
	}	
		
	
	
}







 


function onClickBoutonSupprimer() 
{ 
	//hide_all();
	//showLogin();
	
	objListViewObservations.removeSelectedObservsFromListView();
	objListViewObservations.saveObservToLocalStorage();
	
	objListeDesDocCoord.removeSelectedDocCoordFromListView();
	objListeDesDocCoord.saveToLocalStorage();
	
}


function onClickBoutonDeconnecter() 
{ 
	

	


	hide_all();
	showLogin();
	document.getElementById('tool_button3').style.visibility='hidden';
	
	hide_element(back_button);
	
	
}



function onClickBoutonAjouterPhoto() 
{ 
	
	//document.getElementById('idTRInputDeLaPhoto').style.display='block'
	
	
	var objTD = document.getElementById("idTDInputDeLaPhoto");
	//document.getElementById("idTDInputDeLaPhoto").innerHTML = id_id_d_2;
		
	var input = document.createElement('input');
	/*input.class = 'classInputPhoto';*/
	input.type = 'file';
	input.accept = 'image/*';
	input.id = 'take-picture';


	var takePicture2 = document.querySelector("#take-picture");

    if (takePicture2 ) {
		//alert("Input existe")
	}else
	{	
		objTD.appendChild(input);
		//alert("Input existe pas");
	}
	
	
	
	

	laCamera1.activateCamera();

	//html5 createElement input appendChild accept image/*
	
}


function destroyTagInputFilePourLaPhotoPrincipale() 
{ 
	var objTD = document.getElementById("idTDInputDeLaPhoto");
	var olddiv = document.getElementById('take-picture');
	objTD.removeChild(olddiv);
	//html5 createElement input appendChild accept image/*
	
}


function onClickBoutonAjouterObservation() 
{ 


	document.getElementById("show-picture").setAttribute("src", "http://www.groupeallumage.com/templates/mytech-et/images/logo.png");

	hide_all();
	
	var valNum1 = objListViewObservations.getObservArrayLength();
	
	afficheEcranObservations("", "", "", valNum1);

	
}

	
function onClickButtonLogin()
{


	vUtil = document.getElementById("id_utilisateur_d").value;
	vPass = document.getElementById("id_motDePasse_d").value;
	
	//alert(vUtil+"/"+vPass);
	
	if(vUtil=="aaaa" && vPass=="bbbb"){
		//alert("onClickButtonLogin");
		hideLogin();
		//show_menu1();
		onClickButtonMenuListViewObserv();
		
		
		document.getElementById("tool_button3").style.visibility="visible";
	}else
	{
		//hideLogin();
		//show_menu1();
		//document.getElementById("tool_button3").style.visibility="visible";
		
	alert("Accès refusé!\nle nom d'utilisateur est: aaaa\nle mot de passe est: bbbb");
	}


}		


function onClickTelechargerLeFichier()
{			
	

	id_id_d =  document.getElementById("id_id_d").innerHTML;
	id_filename_d =  document.getElementById("id_filename_d").innerHTML;
	id_registered_d =  document.getElementById("id_registered_d").innerHTML;
	id_gps_position =  "47.786e, -141.567w";	
			
			
	leGps1.getPosOnly(id_filename_d, id_gps_position, id_registered_d);
			
	
	
	
		//alert("appendGpsPosition");
}


		  
function onClickButtonMenuListViewObserv()
{
	

	hide_all();
	
	objListViewObservations.fillObservsListView();

	document.getElementById("tool_button").style.visibility="visible";
	document.getElementById("tool_button2").style.visibility="visible";

	
	
	show_back_button();

}			

function insererUnePhotoDansLeUL(indexObserv, indexPhoto) 
{ 
	//jjjjjjjjjjjjjjjjjjj
	
		
	var objUL = document.getElementById("id_ul_les_photos");
		
	var objLI = document.createElement('li');
	var objIMG = document.createElement('img');
	objIMG.setAttribute('width', '180pt');
	
	
	
	//jjjjjjjjjjjjjjjjjj
	
	var dataPhoto2=objListViewObservations.myListViewObservArray[indexObserv].arrLesObjetsPhotos[indexPhoto].dataURLPhoto;
	
	
	if(dataPhoto2!=null && dataPhoto2!=""){
		
		objIMG.setAttribute('src', JSON.parse(dataPhoto2));
	}
	

	//insérer image dans une ligne
	objLI.appendChild(objIMG);
	//insérer ligne dans le UL 
	objUL.appendChild(objLI);

}



function afficheEcranObservations(id_ObservTitre, id_ObservDescrip, id_ObservDiskName, id_data_URLPic, la_index) 
{ 
	
	removeAllPhotosFromUL();
	
	
	//document.getElementById('idTRInputDeLaPhoto').style.display='block';

	varGlobal1=id_data_URLPic;
	hide_all();
	show_ecran_de_l_observation();
	//alert("la_index:"+la_index);
	//alert(id_ObservDescrip+"/"+id_ObservDiskName);
	
	
	document.getElementById("id_ObservTitre_data").value = id_ObservTitre;
	document.getElementById("id_ObservResume_data").value = id_ObservDescrip;
	document.getElementById("id_ObservDiskName_data").value = id_ObservDiskName;
	document.getElementById("id_cell_index").innerHTML = la_index;	
	//document.getElementById("show-picture").value = id_ObservDiskName;
	 objNode1 = document.getElementById("show-picture");
	//alert("afficheEcranObservations Start "+la_index);
	
	
	var dataPhoto1=objListViewObservations.myListViewObservArray[la_index].dataURLPicture;
	
	if(dataPhoto1!=null && dataPhoto1!=""){
		document.getElementById('show-picture').setAttribute('src', JSON.parse(dataPhoto1));
	}
	
	
	remplirEtAfficheLeULDesPhotos(la_index);
	
	
	
	
//jjjjjjjjjjjjjjjjjjjjj
	
	/*
	if(varGlobal1!=null && varGlobal1!=""){
		timer8  = window.setInterval( "window.clearInterval(timer8),document.getElementById('show-picture').setAttribute('src', JSON.parse(varGlobal1))", 500 );
	}
	*/
	
	
		
	
	
}


function remplirEtAfficheLeULDesPhotos(la_index) 
{ 
	
	var objLeULDesPhotos = document.getElementsByClassName('id_ul_les_photos');
	//alert(objLeULDesPhotos.length+"/"+this.myListViewObservArray.length);
	
	//
	array_les_photos = objListViewObservations.myListViewObservArray[la_index].arrLesObjetsPhotos;
	
	
	
	for (var i=0; i < array_les_photos.length; i++){
		//var dataPhoto2=objListViewObservations.myListViewObservArray[la_index].arrLesObjetsPhotos[i].dataURLPhoto;
		//alert("remplirEtAfficheLeULDesPhotos:"+la_index);
		insererUnePhotoDansLeUL(la_index,i); 	
	}	
}



function removeAllPhotosFromUL()  {	
	
	var obj_LeULDesPhotos = document.getElementById("id_ul_les_photos");

	//alert("removeAllObservFromListView: "+obj_LeULDesPhotos.childNodes.length);
	for (var i=0; i < obj_LeULDesPhotos.childNodes.length; i++){
		var theObject = obj_LeULDesPhotos.childNodes[i];		
		theObject.parentNode.removeChild(theObject);
			i=-1;
	}
}

















// Execute the provided anonymous function when the DOM is ready.

/*

document.addEventListener("DOMContentLoaded", function() {
  var back_button = document.getElementById('back_button');
  // Set the switch_screen callback for the toolbar back button.
  set_click(back_button, function(e) { switch_screen(e.getAttribute('href')); });
  // Bind each of the buttons on the home screen to a switch_screen callback.
  [].forEach.call(document.querySelectorAll("ul.buttons a.switch_screen"), function(el) {
    set_click(el, function(e) { switch_screen(e.getAttribute('href')); });
  });
});


*/