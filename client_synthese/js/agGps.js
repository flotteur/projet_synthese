
	
function MonGPS(strNom) {
    this.strNom = strNom;
    //this.last = last;

	 //alert(strNom);

	 //this.gps_id_filename_d = "";
	 ///this.gps_id_gps_position = "";
	 //this.gps_id_registered_d = "";
	 
	
	 
}



MonGPS.prototype.startWatchGps = function() {
	alert('GPS - Surveillance activée');
	//options = { frequency: 2000 };   
//options = {frequency: 1000, maximumAge: 2000, timeout: 5000, enableHighAccuracy: true };

options = {maximumAge: 5000, enableHighAccuracy: true };
	watchID = navigator.geolocation.watchPosition(this.onSuccess, this.onError, options);   
	//alert('startWatchGps2');
	
}	

MonGPS.prototype.getPosReport = function() {
	//alert('getCurrentPosition1');
	
	
	navigator.geolocation.getCurrentPosition(this.onSuccess, this.onError);
	
	
	
	
}


MonGPS.prototype.onSuccess = function(position) {
	var element = document.getElementById('id_geolocation');
		element.innerHTML = 'Latitude: '           + position.coords.latitude              + '<br />' +
							'Longitude: '          + position.coords.longitude             + '<br />' +
							'Altitude: '           + position.coords.altitude              + '<br />' +
							'Accuracy: '           + position.coords.accuracy              + '<br />' +
							'Altitude Accuracy: '  + position.coords.altitudeAccuracy      + '<br />' +
							'Heading: '            + position.coords.heading               + '<br />' +
							'Speed: '              + position.coords.speed                 + '<br />' +
							'Timestamp: '          + new Date(position.timestamp)          + '<br />';
}
	
MonGPS.prototype.getPosOnly = function(id_filename_d, id_gps_position, id_registered_d) {
	//alert('getCurrentPosition1');
	//geolocation = Components.classes["@mozilla.org/geolocation;1"].getService(Components.interfaces.nsIDOMGeoGeolocation);
	//alert(geolocation.position.coords.latitude);
	//this.gps_id_filename_d = id_filename_d;
	//this.gps_id_gps_position = id_gps_position;
	//this.gps_id_registered_d = id_registered_d;
	
	sessionStorage.setItem("gps_id_filename_d", id_filename_d);
	sessionStorage.setItem("gps_id_gps_position", id_gps_position);
	sessionStorage.setItem("gps_id_registered_d", id_registered_d);
	
//alert("zzzzzzzzzzzzzzzzzzzzzzzzz");
	
	
	
	navigator.geolocation.getCurrentPosition(this.onSuccessPosOnly, this.onError);
	//alert('getCurrentPosition2');
	//alert('getCurrentPosition3');
}

MonGPS.prototype.onSuccessPosOnly = function(position) {
	
	
///alert("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

	
	str_LaPos= agRound3(position.coords.latitude)+"N, "+agRound3(position.coords.longitude)+"W";
	
	document.getElementById('id_id_d2').innerHTML = str_LaPos;
	
	 
	
	//alert(sessionStorage.getItem("gps_id_filename_d")+"/"+str_LaPos+"/"+sessionStorage.getItem("gps_id_registered_d"));
	
	objListeDesDocCoord.appendGpsPosition(sessionStorage.getItem("gps_id_filename_d"), str_LaPos, sessionStorage.getItem("gps_id_registered_d"));
	
	objListeDesDocCoord.saveToLocalStorage();
	
	//alert("Position GPS trouvée!\nRedirection vers le fichier.");
	

	//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	//location.href=sessionStorage.getItem("url_du_fichier_a_ouvrir_apres_position_trouve");
	
	
	//window.location.target = "_top";
	//window.location.href="http://www.google.ca/";
	
	
	var str_ua = navigator.userAgent;
	
	if(str_ua.indexOf("iPad") != -1 || str_ua.indexOf("iPod") != -1 || str_ua.indexOf("iPhone") != -1 || str_ua.indexOf("Macintosh") != -1){
		//alert("apple");
		window.location.target = "_top";
		window.location.href=varGlobal2;
	}else{
		//alert("non apple");
		window.open(varGlobal2, "_blank","");	
	}		
	
	

/*	
try {
    window.open(url, "","")
} catch(e) {
    location.target = "_blank";
    location.href = url;
}
	*/
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	//top.location="http://www.google.ca/";
	
	//location.href=varGlobal2;
	
	/*
	le_element = document.getElementById("id_test_lien");
	le_element.setAttribute("href", varGlobal2);
	le_element.onclick();
	//alert("22223333");
	*/
	
}

MonGPS.prototype.onError = function(error) {
		alert('code: '    + error.code    + '\n' +
				  'message: ' + error.message + '\n');
}
	
MonGPS.prototype.stopWatchGps = function() {
	
	window.navigator.geolocation.clearWatch( watchID );
	alert('GPS - Surveillance arrêtée');
}
	
