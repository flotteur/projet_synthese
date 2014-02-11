/*
	agObservation.js
*/
	
function ClasseObservation() {
   

	 //alert(strNom);
	this.strObservTitre = ""; 
	this.strObservResume = "";
	this.strObservDiskName = "";
	this.dataURLPicture = "";	
	this.arrLesObjetsPhotos = [];	
	

	 
}

ClasseObservation.prototype.ajouterUneAutrePhotoDansUnObjetObservation = function(str_la_Photo_Descrip, str_la_Photo_DiskName, dataURL_la_Photo) {
	
	var photoObject1 = new ClassePhoto();
	photoObject1.strPhotoDescrip = str_la_Photo_Descrip;
	photoObject1.strPhotoDiskName = str_la_Photo_DiskName;
	photoObject1.dataURLPhoto = dataURL_la_Photo;	
	
	this.arrLesObjetsPhotos.push(photoObject1);	
	
}