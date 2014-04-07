//Section pour l'affichage et le téléchargement des observations 

//agULListViewPhotos.js

function ClasseULListViewPhotos(myName) {
	//alert(myName);
	this.myULListViewPhotosName = "777";
	this.myULListViewPhotosArray = [];
}


function effacerUnePhotoDuULListViewPhotos(index_Observ, index_Photo) {
	//index de l'observation
	//var id_cell_index = document.getElementById('id_cell_index').innerHTML;

	VConfirm = ''
	VConfirm = VConfirm + 'Êtes-vous certain de vouloir effacer cette photo?\n\n'
	if (confirm(VConfirm)) {
		//alert(index_Observ+"/"+index_Photo);
		var les_lignes = document.getElementsByClassName('li_de_ul_des_photos');
		var theObject = les_lignes[index_Photo];
		//alert("index_Photo:"+index_Photo);			
		theObject.parentNode.removeChild(theObject);
		objListViewObservations.myListViewObservArray[index_Observ].arrObservLesPhotos.splice(index_Photo, 1);

		/*
		//vider le ul
		removeAllPhotosFromUL();
		//ré-insérer les photos dans le UL et afficher					
		remplirEtAfficheLeULDesPhotos(id_cell_index);
		*/

	} else {

	}






}

ClasseULListViewPhotos.prototype.deleteUnePhotoFromULListViewPhotos = function(l_indx) {

	var obj_LeULDesPhotos = document.getElementById("id_ul_les_photos");






	//alert("removeAllObservFromListView: "+obj_LeULDesPhotos.childNodes.length);
	for (var i = 0; i < obj_LeULDesPhotos.childNodes.length; i++) {
		var theObject = obj_LeULDesPhotos.childNodes[i];
		theObject.parentNode.removeChild(theObject);
		i = -1;
	}

	var les_lignes = document.getElementsByClassName('id_ul_les_photos');
	var theObject = les_lignes[l_indx];
	this.myListViewObservArray.splice(l_indx, 1);
	theObject.parentNode.removeChild(theObject);


}
