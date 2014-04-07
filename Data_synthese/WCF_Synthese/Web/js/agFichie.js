//Section pour l'affichage et le téléchargement des fichiers 



function addFichiersListViewCell(le_id, le_non_fich, le_url, la_descrip, la_date_eng)
{			
	var newDiv1 = document.createElement("div");
	newDiv1.setAttribute("class", "la_liste1");
	newDiv1.setAttribute("align", "left");
	
	newDiv1.id="id_div_liste_fichiers1";	
	
	//newDiv1.addEventListener('click', test55, false)
	newDiv1.addEventListener('click',function(){affichePageXXXXXXX(le_id, le_non_fich, le_url, la_descrip, la_date_eng)},false);
	
	var newH2 = document.createElement("h2");
	var newH2Content = document.createTextNode(le_non_fich);
	newH2.appendChild(newH2Content);
	
	var newP = document.createElement("p");
	var newPContent = document.createTextNode(le_url);
	newP.appendChild(newPContent);	

	newDiv1.appendChild(newH2);	
	newDiv1.appendChild(newP);	
	
	
				
	my_mainDiv = document.getElementById("div_main");  
	my_mainDiv.appendChild(newDiv1);
	
	
		
}



function affiche_json_du_prof(le_str_output) 
{ 
	localString = JSON.parse(le_str_output);

	//alert(localString.result.length);

	//alert(localString['id']);
	//alert(localString['jsonrpc']);
	//var JSONstring=[{"key1":"value1","key2":"value2"},{"key3":"value3"}];

	for(var i=0;i<localString.result.length;i++){
	var obj = localString.result[i];
		
		
		/*
		alert(localString.result[i].id);
		alert(localString.result[i].filename);
		alert(localString.result[i].url);
		alert(localString.result[i].description);
		alert(localString.result[i].registered);	
		*/		
		
		
		addFichiersListViewCell(localString.result[i].id, localString.result[i].filename, localString.result[i].url, localString.result[i].description, localString.result[i].registered)
		/*
		 for(var key in obj){
				 var attrName = key;
				 var attrValue = obj[key];
				if(attrName=="id"){alert(attrName+"/"+attrValue);}
				if(attrName=="filename"){alert(attrName+"/"+attrValue);}
				//alert(attrName+"/"+attrValue);
				
				
			}
		*/	
	}
		
}


function download_document(le_url) 
{ 
//img/new_logo.gif
//http://ks365406.kimsufi.com/fpilote/tp1/new_logo.gif



le_url="img/new_logo.gif";

alert("download_document");
alert(le_url);

   // Getting a file through XMLHttpRequest as an arraybuffer and creating a Blob
    var tp1DataStorage = localStorage.getItem("tp1DataStorage");
        //rhino = document.getElementById("rhino");
    if (tp1DataStorage) {
        // Reuse existing Data URL from localStorage
        alert("Existe yea");
		//rhino.setAttribute("src", tp1DataStorage);
    }
    else {
		alert("Existe pas");
	
        // Create XHR, BlobBuilder and FileReader objects
        var xhr = new XMLHttpRequest(),
            blob,
            fileReader = new FileReader();
		//Le FileReader sert a convertire le blob recu en data URL 
alert("0000000");
        xhr.open("GET", le_url, true);
        // Set the responseType to arraybuffer. "blob" is an option too, rendering BlobBuilder unnecessary, but the support for "blob" is not widespread enough yet
        xhr.responseType = "arraybuffer";
alert("22222");
        xhr.addEventListener("load", function () {
            if (xhr.status === 200) {
                // Create a blob from the response
               alert("77777");
				blob = new Blob([xhr.response], {type: "application/gif"});
 alert("88888");
                // onload for all browsers since Google Chrome doesn't support addEventListener for FileReader
                fileReader.onload = function (evt) {
                    // Read out file contents as a Data URL
                    alert("333333");

				   var result = evt.target.result;
                    // Set image src to Data URL
                    //rhino.setAttribute("src", result);
                    // Store Data URL in localStorage
                    try {
                        localStorage.setItem("tp1DataStorage", result);
                    }
                    catch (e) {
                        console.log("Storage failed: " + e);
                    }
                };
                // Load blob as Data URL
                fileReader.readAsDataURL(blob);
            }
        }, false);
        // Send XHR
		
		  alert("44444");
        xhr.send();
		  alert("555555");
    }

	
}

function removeAllFichiersFromListView(le_url) 
{ 	
	var element = document.getElementById("div_main");
	//alert("removeAllFichiersFromListView");
	//alert("removeAllFichiersFromListView: "+element.childNodes.length);
	for (var i=0; i < element.childNodes.length; i++){
		var theObject = element.childNodes[i];		
		
		//alert(theObject.className);
		if(theObject.className == "la_liste1"){
			//alert(theObject.className);
			theObject.parentNode.removeChild(theObject);
			i=-1;		
			//element.removeChild(theObject);
		}
	}
}

