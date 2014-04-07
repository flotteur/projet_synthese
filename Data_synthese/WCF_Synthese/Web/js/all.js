function encode_utf8(s) {
	return unescape(encodeURIComponent(s));
}



function decode_utf8(s) {
	return decodeURIComponent(escape(s));
}



function agRound3(xyz) {
	xyz = Number(xyz);
	var result = Math.round(xyz * 1000) / 1000;
	return (result);
}



function agRound(xyz) {
	xyz = Number(xyz);
	var result = Math.round(xyz * 100) / 100;
	return (result);
}



var str_output = "";




//choix de la langue
function agXMLHttpReqLan(le_url) {

	//alert(le_url);
	try {

		var resourcePath = le_url;
		var request = new XMLHttpRequest();


		request.open("GET", resourcePath, true);
		request.onreadystatechange = function() {
			if (request.readyState == 4) {

				if (request.status == 200 || request.status == 0) {
					//str_output = JSON.parse(request.responseText);
					str_output = request.responseText;
					//alert(str_output);
					get_lang_callback(str_output);
				}
			}
		}
		request.send();
	} catch (e) {
		//errorEvent(e);
	}
}






function getUrlVars() {
	var vars = {};
	var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m, key, value) {
		vars[key] = value;
	});
	return vars;
}


function agConvertDate1(la_dadate) {
	dd = la_dadate.getDate().toString();;
	dm = la_dadate.getMonth().toString();;

	//alert(dd.length);
	if (dd.length == 1) {
		dd = "0" + dd;
	}
	if (dm.length == 1) {
		dm = "0" + dm;
	}

	return la_dadate.getFullYear() + "/" + dm + "/" + dd + " " + la_dadate.getHours() + ":" + la_dadate.getMinutes() + ":" + la_dadate.getSeconds();
}


function agConvertDate2(la_dadate) {
	dd = la_dadate.getDate().toString();;
	dm = la_dadate.getMonth().toString();;

	//alert(dd.length);
	if (dd.length == 1) {
		dd = "0" + dd;
	}
	if (dm.length == 1) {
		dm = "0" + dm;
	}

	return la_dadate.getFullYear() + "/" + dm + "/" + dd;
}

function convertDateToTimestamp(une_bonn_date) {
	
	//"1909-09-09 09:09:09"
	var str_An = une_bonn_date.substr(0,4);
	var str_Mois = une_bonn_date.substr(5,2);
	var str_Jour = une_bonn_date.substr(8,2);
	var str_Heure = une_bonn_date.substr(11,2);
	var str_Min = une_bonn_date.substr(14,2);
	var str_Sec = une_bonn_date.substr(17,2);

	var str_date = str_Mois+"/"+str_Jour+"/"+str_An+" "+str_Heure+":"+str_Min+":"+str_Sec

	//alert("str_date:"+str_date);
	//alert("une_bonn_date:"+une_bonn_date);

	var un_timestamp = new Date(str_date).getTime();
	return un_timestamp;	
}
function convertTimeStampToDate(la_bonne_date) {


var is_valid = (new Date(la_bonne_date)).getTime() > 0;
//var valid = (new Date('2012-08-09')).getTime() > 0; // true
//var valid = (new Date('abc')).getTime() > 0; // false




	if(is_valid){

		var la_date = new Date(la_bonne_date);
		
		var le_getMonth = la_date.getMonth()+1;
		var le_getDate = la_date.getDate();
		var le_getHours = la_date.getHours();
		var le_getMinutes = la_date.getMinutes();
		var le_getSeconds = la_date.getSeconds();
		
			
		if (le_getMonth < 10) { le_getMonth = '0' + le_getMonth; }	
		if (le_getDate < 10) { le_getDate = '0' + le_getDate; }
		if (le_getHours < 10) { le_getHours = '0' + le_getHours; }
		if (le_getMinutes < 10) { le_getMinutes = '0' + le_getMinutes; }
		if (le_getSeconds < 10) { le_getSeconds = '0' + le_getSeconds; }
		
		
		

		var la_date2 =
			la_date.getFullYear() + "-" +
			(le_getMonth) + "-" +
			le_getDate + " " +
			le_getHours + ":" +
			le_getMinutes + ":" +
			le_getSeconds;
			
			
		var la_date3 =
			la_date.getFullYear() + "-" +
			(le_getMonth) + "-" +
			le_getDate;
			
			
			
			
		return la_date2;
	}
}
