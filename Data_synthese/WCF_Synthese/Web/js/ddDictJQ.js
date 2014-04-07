/*                         */
/* Charger le dictionnaire */
/*                         */


var vecteurLgnDictionnaire = [];

function ClasseLgnDict(id, espece, description, IDPhoto, IDSon, flObsPermises, photoBinaire) {

	this.id = id;
	this.espece = espece;
	this.description = description;
	this.IDPhoto = IDPhoto;
	this.IDSon = IDSon;
	this.flObsPermises = flObsPermises;  //(1 === 0);
	this.photoBinaire = photoBinaire; //undefined;

}


function trf(xdata, obj, pteur) {
	obj.photoBinaire = xdata;
	
	/*
	console.log( obj.IDPhoto + ' ' + obj.photoBinaire);
	if (pteur==true){
		try {
			localStorage.setItem("vecteurLgnDictionnaire", JSON.stringify(vecteurLgnDictionnaire));
			alert('Il y a ' + vecteurLgnDictionnaire.length + ' oiseaux dans le localStorage.');
		} catch (e) {
			alert("Problème de localStorage: " + e);
		}
	}
	*/
}


$(document).ready(function() {


	$("#load").click(function() {
		hide_all();

		var jqxhr = $.getJSON('birds/_DescriptionDesEspeces.json', function(data) {
			$.each(data, function(key, val) {
				obj2cellule(val.id, val.espece, val.description,
					val.IDPhoto, val.IDSon, val.flObsPermises);
				vecteurLgnDictionnaire.push(new ClasseLgnDict(val.id,
					val.espece, val.description,
					val.IDPhoto, val.IDSon, val.flObsPermises, ''));
			});
		})


		.done(function() {

			var ix = 0
			for (var i = 0; i < vecteurLgnDictionnaire.length; i++) {
				var new_img = document.createElement("img");
				
				
				
				//new_img.src = "birds/" + vecteurLgnDictionnaire[i].IDPhoto + ".jpg";
				new_img.src = "birds/" + vecteurLgnDictionnaire[i].IDPhoto;
				
				
				
				new_img.onload = function() {
					var canvas = document.createElement('canvas');
					canvas.width = this.naturalWidth;
					canvas.height = this.naturalHeight;
					var c = canvas.getContext('2d');
					c.drawImage(this, 0, 0);
					return trf(canvas.toDataURL(), vecteurLgnDictionnaire[ix++], ix === i)
				};
			};
		})

		.fail(function() {
			alert("Problème à downloader le dictionnaire");
		})

		.always(function() {
			
		});
	});
});






function obj2cellule(le_id, l_espece, la_descrip, le_IDPhoto, le_IDSon, le_flObsPermises) {

	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "la_liste1");
	newDiv1.setAttribute("align", "left");
	newDiv1.id = "id_div_liste_commentaires";

	var audio = document.createElement('audio');
	audio.src = "sons/" + le_IDSon + ".mp3";
	audio.controls = true;
	audio.autoplay = false;
	audio.setAttribute("class", "bird_audio");
	newDiv1.appendChild(audio);


	var newImg2 = document.createElement("img");
	newImg2.src = "img/musical_note.png";
	newImg2.setAttribute("class", "speaker_img");
	newDiv1.appendChild(newImg2);



	var newImg1 = document.createElement("img");
	newImg1.src = "birds/" + le_IDPhoto + ".jpg";
	newImg1.setAttribute("class", "bird_img");
	newImg1.setAttribute("id", randomcssid());
	//newImg1.addEventListener('click', autresphotos, false);
	newDiv1.appendChild(newImg1);

	var newP2 = document.createElement("p");
	var newP2Content = document.createTextNode(l_espece);
	newP2.setAttribute("class", "bird_espece");
	newP2.appendChild(newP2Content);
	newDiv1.appendChild(newP2);


	// mettre ou ne pas mettre le bouton selon le flag  flObservationRequise
	if (le_flObsPermises === true) {
		var newRadio4 = document.createElement("input");
		newRadio4.setAttribute("type", "button");
		//newRadio4.setAttribute('checked', '');
		newRadio4.setAttribute("class", "ajout_observ_button");
		newRadio4.setAttribute("value", "Ajouter une observation");
		//newRadio4.setAttribute("id", "bouton_effacer_ligne");
		newRadio4.addEventListener('click', function() {
			onClickBoutonAjouterObservation(le_id);
		}, false);
		newDiv1.appendChild(newRadio4);
	}

	var newP1 = document.createElement("p");
	//var newP1Content = document.createTextNode(tronquetxt(la_descrip));
	var newP1Content = document.createTextNode(la_descrip);
	newP1.setAttribute("class", "bird_descript");
	newP1.appendChild(newP1Content);
	newDiv1.appendChild(newP1);

	my_mainDiv = document.getElementById("div_main");
	my_mainDiv.appendChild(newDiv1);
}



/*
function tronquetxt(texte) {
	var sous_chaine = texte.substr(0, 250) + " ...";
	return sous_chaine
}



function getRandomArbitrary(min, max) {
	return Math.round(Math.random() * (max - min) + min);
}



function randomcssid() {
	return "bird_img" + getRandomArbitrary(1, 4);
}


}


*/



