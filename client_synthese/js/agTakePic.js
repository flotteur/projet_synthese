
	
function MaCamera(strCamName) {
    this.strCamName = strCamName;
 
}



MaCamera.prototype.activateAudio = function() {

 var takeAudio = document.querySelector("#take-sound"),
    audioControl_01 = document.querySelector("#audiocontrol");

    if (takeAudio) {
        // Set events
        takeAudio.onchange = function (event) {
		
	
		
            // Get a reference to the taken picture or chosen file
            var files = event.target.files,
                file;
            if (files && files.length > 0) {
                file = files[0];
                try {
                    // Get window.URL object
                    var URL = window.URL || window.webkitURL;

                    // Create ObjectURL
                    var imgURL = URL.createObjectURL(file);

                    // Set img src to ObjectURL
                    
				//var snd = new Audio("data:audio/mpeg;base64," + imgURL);
				//snd.play();
					
					
					//audioControl_01.src = imgURL;
					
					//audioControl_01.src = "data:audio/mpeg;base64,"+encodeURIComponent(imgURL);
					audioControl_01.src = "data:audio/mpeg;base64,"+imgURL;
					
					//audioControl_01.load();
					//audioControl_01.play();
					
					
//alert(imgURL); 
                    // Revoke ObjectURL
                   // URL.revokeObjectURL(imgURL);
                }
                catch (e) {
                    try {
                        // Fallback if createObjectURL is not supported
                        var fileReader = new FileReader();
                        fileReader.onload = function (event) {
                            audioControl_01.src = event.target.result;
                        };
                        fileReader.readAsDataURL(file);
                    }
                    catch (e) {
                        // Display error message
                        var error = document.querySelector("#error");
                        if (error) {
                            error.innerHTML = "Neither createObjectURL or FileReader are supported";
                        }
                    }
                }
            }
        };
    }
	
}	


MaCamera.prototype.activateCamera = function() {
   var takePicture = document.querySelector("#take-picture"),
        showPicture = document.querySelector("#show-picture");

    if (takePicture && showPicture) {
        // Set events
        takePicture.onchange = function (event) {
           
//document.getElementById('idTRInputDeLaPhoto').style.display='block';







		   // Get a reference to the taken picture or chosen file
            var files = event.target.files,
                file;
            if (files && files.length > 0) {
                file = files[0];
                try {
                    // Get window.URL object
                    var URL = window.URL || window.webkitURL;

                    // Create ObjectURL
                    var imgURL = URL.createObjectURL(file);
					

                    // Set img src to ObjectURL
                    showPicture.src = imgURL;

                    // Revoke ObjectURL
                    URL.revokeObjectURL(imgURL);
					
					//alert("323232323");
					
					showPicture.onload=function(){onClickAjouterUneAutrePhoto();};
					
                }
                catch (e) {
                    try {
                        // Fallback if createObjectURL is not supported
                        var fileReader = new FileReader();
                        fileReader.onload = function (event) {
                            showPicture.src = event.target.result;
                        };
                        fileReader.readAsDataURL(file);
						
						
                    }
                    catch (e) {
                        // Display error message
                        var error = document.querySelector("#error");
                        if (error) {
                            error.innerHTML = "Neither createObjectURL or FileReader are supported";
                        }
                    }
                }
				
				varGlobalNomImage = document.getElementById('take-picture').files[0].name;
				document.getElementById('id_ObservDiskName_data').value = varGlobalNomImage;
				
				
				
            }
	//alert("2222222");
				
		
		destroyTagInputFilePourLaPhotoPrincipale();
			
		
        };
    }
	
}	



MaCamera.prototype.agImgToCanvasToDataURL = function() {
 
	
	//alert("agImgToCanvasToDataURL1");
	imgTag1 = document.getElementById("show-picture");
	var imgCanvas = document.createElement("canvas");
	imgCanvas.id = "canvas1";
	imgContext = imgCanvas.getContext("2d");

	// Make sure canvas is as big as the picture
	imgCanvas.width = imgTag1.width;
	imgCanvas.height = imgTag1.height;

	// Draw image into canvas element
	
	
	
	widthTarget=320;
	heightTarget=(imgTag1.height*260)/imgTag1.width;
	
	imgContext.drawImage(imgTag1, 0, 0, parseInt(widthTarget), parseInt(heightTarget));
	//imgTag1.width			260
	//imgTag1.height			x
	
	
	
	//mozImageSmoothingEnabled in Firefox and webkitImageSmoothingEnabled in Chrome 
	
	
	
	// Save canvas as a (png image) data URL and put in localStorage

	//"image/jpeg"
	//"image/png"
	
	var dataURL = imgCanvas.toDataURL("image/png");


	return dataURL;
	
	//return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
	
	//return "445555555";
	//alert("agImgToCanvasToDataURL2");

}	









		
		

