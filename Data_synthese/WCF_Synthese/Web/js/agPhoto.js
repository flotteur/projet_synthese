/*
	agPhoto.js
*/

function ClassePhoto(str_Photo_Id, dataURL_Photo, str_Photo_Descrip, str_Photo_IDObservation, str_Photo_ImageMiniature, str_Photo_Commentaire, str_Photo_url_big) {


	//alert(strNom);

	this.strPhoto_Id = parseInt(str_Photo_Id, 10);
	this.strPhoto_Image = dataURL_Photo;
	this.strPhoto_Description = str_Photo_Descrip;
	this.strPhoto_IDObservation = parseInt(str_Photo_IDObservation, 10);
	this.strPhoto_ImageMiniature = str_Photo_ImageMiniature;
	this.strPhoto_Commentaire = str_Photo_Commentaire;
	this.strPhoto_url_big = str_Photo_url_big;

	

}
