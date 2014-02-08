

//show-picture
//Image_DA000CTB_2002_0_XX_20120808141815.jpg
//http://www.autocal.ca/portfolio/MobUplo.asp?logCon=AAAAA&logServ1BBBBBB

 //var strUrl1="http://www.recompensepromise.com/cegep/TP1/uploa.php";
//var strUrl="http://www.autocal.ca/portfolio/MobUplo.asp";
//var strUrl="http://www.autocal.ca/portfolio/MobUplo.asp?logCon=DA000CTB&name=BBBBBB&filename=CCCCCCCC&logServ1=CCCCCCCC";
var strUrl="http://www.intranet-creation.com/portfolio/MobUplo.asp?logCon=DA000CTB&name=BBBBBB.jpg&filename=CCCCCCCC&logServ1=CCCCCCCC";
//var strUrl="http://www.intranet-creation.com/portfolio/MobUplo2.asp";


//C:\WebShow\WwwRoot\portfolio\MobUplo.ASP


function saveImage(){
var xmlhttp;
	le_dataURL = laCamera1.agImgToCanvasToDataURL()
	//le_dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
	
	alert("saveImage");
	alert(strUrl);
	  //alert(le_dataURL);
    xmlhttp=((window.XMLHttpRequest)?new XMLHttpRequest():new ActiveXObject("Microsoft.XMLHTTP"));
    xmlhttp.onreadystatechange=function()
    {
	alert("999999:"+xmlhttp.status);
	
      if (xmlhttp.readyState==4 && xmlhttp.status==200)
        {
           alert("11111"+xmlhttp.responseText);
        }
    }
    xmlhttp.open("POST",strUrl,true);
	alert("2222222");
	
   // var oldCanvas = document.getElementById('show-picture').toDataURL("image/png");
	//var oldCanvas = document.getElementById('show-picture').toDataURL("image/png");
	
   alert("3333333");
   var img = new Image();
  
   img.src = le_dataURL;
   alert("4444444");
   //xmlhttp.setRequestHeader("Content-type", "application/upload")
   xmlhttp.setRequestHeader("Content-type", "application/octet-stream")
     alert("5555555");
	xmlhttp.send(le_dataURL);
	 alert("77777777");
	
}