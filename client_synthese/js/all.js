function encode_utf8( s )
{
  return unescape( encodeURIComponent( s ) );
}

function decode_utf8( s )
{
  return decodeURIComponent( escape( s ) );
}
function agRound3(xyz) 
{ 
	xyz=Number(xyz);
	var result=Math.round(xyz*1000)/1000; 
	return(result);
}

function agRound(xyz) 
{ 
	xyz=Number(xyz);
	var result=Math.round(xyz*100)/100; 
	return(result);
}

var str_output="";

function agXMLHttpReqLan(le_url) {
     
	//alert(le_url);
	try {
     
		var resourcePath = le_url;
        var request = new XMLHttpRequest();
		
		
        request.open("GET", resourcePath, true);
        request.onreadystatechange = function(){
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
        errorEvent(e);
    }
}


function agXMLHttpReqFichiers(le_url) {
     
	var storageFiles = JSON.parse(localStorage.getItem("storageFilesFichiers3")) || {},
	storageFilesDate = storageFiles.date1,
	date = new Date(),
	//todaysDate = (date.getMonth() + 1).toString() + date.getDate().toString();
	todaysDate=agConvertDate2(date);
	
	//alert(storageFilesDate+"/"+todaysDate); 
    // Vérifier si fichier existe et n'est pas trop vieux  
    if (typeof storageFilesDate === "undefined" || storageFilesDate != todaysDate) 
	{

		 //alert(le_url);
		try {
			var resourcePath = le_url;
			var request = new XMLHttpRequest();
			request.open("GET", resourcePath, true);
			request.onreadystatechange = function(){
				if (request.readyState == 4) {
					if (request.status == 200 || request.status == 0) {
						str_output = request.responseText;
						storageFiles.date1 = todaysDate;
						storageFiles.output = str_output;
						try {
							localStorage.setItem("storageFilesFichiers3", JSON.stringify(storageFiles));
						}
						catch (e) {
								alert("Storage failed: " + e);                
						}
						affiche_json_du_prof(str_output); 
						
					}
				}
			}
			request.send();
			
		 } catch (e) {
			errorEvent(e);
		}
    }
    else {
	   str_output = storageFiles.output;
	   affiche_json_du_prof(str_output); 
	   //storageFiles.output = str_output;
    }
}






function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
        vars[key] = value;
    });
    return vars;
}


function agConvertDate1(la_dadate)
{			
	dd = la_dadate.getDate().toString();;
	dm = la_dadate.getMonth().toString();;
	
	//alert(dd.length);
	if(dd.length==1){dd="0"+dd;}
	if(dm.length==1){dm="0"+dm;}
	
	return la_dadate.getFullYear()+"/"+dm+"/"+dd+" "+la_dadate.getHours()+":"+la_dadate.getMinutes()+":"+la_dadate.getSeconds();
}


function agConvertDate2(la_dadate)
{			
	dd = la_dadate.getDate().toString();;
	dm = la_dadate.getMonth().toString();;
	
	//alert(dd.length);
	if(dd.length==1){dd="0"+dd;}
	if(dm.length==1){dm="0"+dm;}
	
	return la_dadate.getFullYear()+"/"+dm+"/"+dd;
}
