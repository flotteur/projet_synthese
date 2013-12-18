
function show_ecran_fichier() {
	
	ecran_fichier = document.getElementById('ecran_fichier');
	show_element(ecran_fichier);
}

function hide_ecran_fichier() {
	ecran_fichier = document.getElementById('ecran_fichier');
	hide_element(ecran_fichier);
}


function show_ecran_carte() {
	
	ecran_carte = document.getElementById('ecran_carte');
	show_element(ecran_carte);
}

function hide_ecran_carte() {
	ecran_carte = document.getElementById('ecran_carte');
	hide_element(ecran_carte);
}




function show_liste_cartes() {

  [].forEach.call(document.querySelectorAll("div.listViewCartes"), function(el) {
    show_element(el);
  });

}

function hide_liste_cartes() {
  // Remove the hash sign from the start of the id.
    
  // Find all div.screen elements and hide them.
  [].forEach.call(document.querySelectorAll("div.listViewCartes"), function(el) {
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
	//hide_liste_cartes();
		//alert("11122222");
	objCartesAffaires.removeAllCartesFromListView();
		
	removeAllFichiersFromListView();
	
	hide_menu1();
	//hide_liste_des_fichiers();
	
	
	
	hideLogin();
	hide_ecran_fichier();
	
	//hide_liste_des_coord_gps();
	objListeDesDocCoord.removeAllDocCoordFromListView();
	
	
	hide_ecran_carte();
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
	
	document.getElementById("id_liste_fichiers1").innerHTML = localString['liste_des_fichiers'];
	document.getElementById("id_liste_cartes1").innerHTML = localString['liste_des_cartes'];
	document.getElementById("id_a_setting").innerHTML = localString['parametres'];
	document.getElementById("id_utilisateur").innerHTML = localString['str_id_utilisateur'];
	document.getElementById("id_motDePasse").innerHTML = localString['str_id_motDePasse'];
	document.getElementById("id_actualiser").innerHTML = localString['str_actualiser'];
	
	
	
	
}



function onClickBoutonSaveImage() 
{ 
	
	var la_description = document.getElementById('id_CarteDescrip_d').value;
	var le_nom_de_limage = document.getElementById('take-picture').value;

	var id_cell_index = document.getElementById('id_cell_index').innerHTML;
	

	//alert("id_cell_index:"+id_cell_index);
	
	


	
	
	//if(parseInt(id_cell_index)==9999){
		//alert("onClickBoutonSaveImage");
	if (objCartesAffaires.checkSiIndexExiste(id_cell_index)!="1") {	
	
		
		var la_description = document.getElementById('id_CarteDescrip_d').value;
		var le_nom_de_limage = document.getElementById('take-picture').value;
		
		//varTest2 = 
		//laCamera1.agImgToCanvasToDataURL();

		objCartesAffaires.ajouterUneNouvelleCarte(la_description, le_nom_de_limage, JSON.stringify(laCamera1.agImgToCanvasToDataURL()));
		//alert("onClickBoutonSaveImage");
		
		objCartesAffaires.saveCartesToLocalStorage();
		
		//document.getElementById('id_cell_index').innerHTML=""
	}else{
	
	
		//carteObject1.strCarteDescrip = strCarteDescrip;
		//carteObject1.strCarteDiskName = strCarteDiskName;
		//carteObject1.dataURLPicture = the_pic_dataURL;
	
		//alert(objCartesAffaires.myCartesArray[id_cell_index].strCarteDiskName);
		//alert(objCartesAffaires.myCartesArray[id_cell_index].strCarteDescrip);
	
		objCartesAffaires.myCartesArray[id_cell_index].strCarteDescrip=la_description;
		//alert(objCartesAffaires.myCartesArray[id_cell_index].strCarteDescrip);
		
		
		objCartesAffaires.myCartesArray[id_cell_index].dataURLPicture=JSON.stringify(laCamera1.agImgToCanvasToDataURL());
		
		objCartesAffaires.saveCartesToLocalStorage();
	
	
	}
	
}



 


function onClickBoutonSupprimer() 
{ 
	//hide_all();
	//showLogin();
	
	objCartesAffaires.removeSelectedCartesFromListView();
	objCartesAffaires.saveCartesToLocalStorage();
	
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

function onClickBoutonAjouter() 
{ 


	document.getElementById("show-picture").setAttribute("src", "http://www.groupeallumage.com/templates/mytech-et/images/logo.png");

	hide_all();
	
	var valNum1 = objCartesAffaires.getArrayLength();
	
	afficheEcranCarte("", "", "", valNum1);

	
}

	
function onClickButtonLogin()
{


	vUtil = document.getElementById("id_utilisateur_d").value;
	vPass = document.getElementById("id_motDePasse_d").value;
	
	//alert(vUtil+"/"+vPass);
	
	if(vUtil=="aaaa" && vPass=="bbbb"){
		//alert("onClickButtonLogin");
		hideLogin();
		show_menu1();
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
	//strCarteDescrip, strCarteDiskName

	id_id_d =  document.getElementById("id_id_d").innerHTML;
	id_filename_d =  document.getElementById("id_filename_d").innerHTML;
	id_registered_d =  document.getElementById("id_registered_d").innerHTML;
	id_gps_position =  "47.786e, -141.567w";	
			
			
	leGps1.getPosOnly(id_filename_d, id_gps_position, id_registered_d);
			
	
	
	
		//alert("appendGpsPosition");
}
//strCarteDescrip, strCarteDiskName

		  
function onClickButtonMenuCarteDaffaire()
{
	

	hide_all();
	
	objCartesAffaires.fillCartesListView();

	document.getElementById("tool_button").style.visibility="visible";
	document.getElementById("tool_button2").style.visibility="visible";

	
	
	show_back_button();

}			

function afficheEcranCarte(id_CarteDescrip, id_CarteDiskName, id_data_URLPic, la_index) 
{ 
	varGlobal1=id_data_URLPic;
	hide_all();
	show_ecran_carte();
	//alert("la_index:"+la_index);
	//alert(id_CarteDescrip+"/"+id_CarteDiskName);
	document.getElementById("id_CarteDescrip_d").value = id_CarteDescrip;
	document.getElementById("id_CarteDiskName_d").innerHTML = id_CarteDiskName;
	document.getElementById("id_cell_index").innerHTML = la_index;	
	document.getElementById("show-picture").value = id_CarteDiskName;
	 objNode1 = document.getElementById("show-picture");
	//alert("afficheEcranCarte Start");		
	timer8  = window.setInterval( "window.clearInterval(timer8),document.getElementById('show-picture').setAttribute('src', JSON.parse(varGlobal1))", 500 )
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