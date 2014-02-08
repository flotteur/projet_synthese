

function deviceOnline(e) 
{
	//console.log('device is online');
	document.getElementById("id_online_offline").innerHTML = "En ligne";
}

function deviceOffline(e) 
{
	//console.log('device is offline');
	document.getElementById("id_online_offline").innerHTML = "Hors ligne";
	
}

if (Modernizr.applicationcache) 
{
	window.addEventListener("online", deviceOnline, false);
	window.addEventListener("offline", deviceOffline, false);
}


if (navigator.onLine)
{
	document.getElementById("id_online_offline").innerHTML = "En ligne";
}else
{
	document.getElementById("id_online_offline").innerHTML = "Hors ligne";
}


