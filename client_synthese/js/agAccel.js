
	
function MonAccel(strNom) {
    
	 //alert("MonAccel");
	
	this.strNom = strNom;
    //this.last = last;

	// alert(this.strNom);
	 
	 

	if (window.DeviceMotionEvent) {
		//alert('--------oui-----------------------');
		window.addEventListener('devicemotion', this.capture_acceleration, false);
		
	} else {
		alert('Cet appareil ne supporte pas l\'accéléromêtre (devicemotion)');
	}
 

}



MonAccel.prototype.capture_acceleration = function(event) {
	//alert('getCurrentPosition1');

  var acceleration_g_x = event.accelerationIncludingGravity.x;
  var acceleration_g_y = event.accelerationIncludingGravity.y;
  var acceleration_g_z = event.accelerationIncludingGravity.z;
 
  //monmessage.innerHTML="  acceleration_x: "+acceleration_x+", acceleration_y: "+acceleration_y+", acceleration_z:"+acceleration_z;
  

the_id_accel = document.getElementById("id_accel_data");
the_id_accel.innerHTML=agRound(acceleration_g_x)+"/"+agRound(acceleration_g_y)+"/"+agRound(acceleration_g_z);;


//li2.innerHTML="acceleration_g_y: "+acceleration_g_y;
//li3.innerHTML="acceleration_g_z:"+acceleration_g_z;
 
}


MonAccel.prototype.capture_acceleration2 = function(event) {

	if (typeof window.DeviceMotionEvent != 'undefined') {
		// Shake sensitivity (a lower number is more)
		var sensitivity = 20;

		// Position variables
		var x1 = 0, y1 = 0, z1 = 0, x2 = 0, y2 = 0, z2 = 0;

		// Listen to motion events and update the position
		window.addEventListener('devicemotion', function (e) {
			x1 = e.accelerationIncludingGravity.x;
			y1 = e.accelerationIncludingGravity.y;
			z1 = e.accelerationIncludingGravity.z;
		}, false);

		// Periodically check the position and fire
		// if the change is greater than the sensitivity
		setInterval(function () {
			var change = Math.abs(x1-x2+y1-y2+z1-z2);

			if (change > sensitivity) {
				//alert('Shake!');
				hide_all();
				show_menu1();
				
			}

			// Update new position
			x2 = x1;
			y2 = y1;
			z2 = z1;
		}, 150);
	}

}

