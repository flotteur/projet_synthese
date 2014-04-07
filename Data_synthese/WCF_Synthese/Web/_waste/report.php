<?php 
 

 
//phpinfo();
$username = "user1_cegep";
$password = "cegep1234";
$hostname = "localhost"; 

//connection to the database
$dbhandle = mysql_connect($hostname, $username, $password)
  or die("Unable to connect to MySQL");
echo "Connected to MySQL<br>";

$selected = mysql_select_db("cegep_oiseaux",$dbhandle)
  or die("Could not select examples");



$result1 = mysql_query("SELECT * FROM tb_observations");
//fetch tha data from the database


while ($row1 = mysql_fetch_array($result1)) {
   echo "obs_Id:".$row1{'obs_Id'}.", obs_DateObservation:".$row1{'obs_DateObservation'}.", obs_Position_lat: ".$row1{'obs_Position_lat'}."<br>";

   
	   
	
	$result2 = mysql_query("SELECT * FROM tb_PhotoObservation where ph_obs_IDObservation = ".$row1{'obs_Id'}."");
	while ($row2 = mysql_fetch_array($result2)) {
	   
	    echo "ph_obs_IDObservation: ".$row2{'ph_obs_IDObservation'}.", ph_obs__Id:".$row2{'ph_obs__Id'}.", ph_obs_Description:".$row1{'ph_obs_Description'}."<br>";

	   
	   //echo '777'.$row2{'ph_obs__Image'}.'<br>';
	   
	   echo "<img src=".$row2{'ph_obs__Image'}." alt='' /><br>";
	   
	   
	}
	

 echo "<br>";
   
   
}




//echo '<img src="data:image/png;base64,"'.base64_decode($le_data).' alt="" />';
//echo '222<img src="'.$le_data1.'" alt="" />';


/*
obs_Id
obs_DateObservation
obs_Position_lat
obs_Image_ascii
*/

/*
$result1 = mysql_query("SELECT * FROM tb_observations");
while ($row = mysql_fetch_array($result1)) {
   echo '222<img src="'.$row{'obs_Image_ascii'}.'" alt="" /><br>';
}
*/



//$result1 = mysql_query("DELETE FROM tb_observations Where obs_Id <> '4235235235'");
//$result1 = mysql_query("DELETE FROM tb_PhotoObservation Where ph_obs__Id <> '4235235235'");


/*
$SQL2="";
$SQL2=$SQL2."UPDATE tb_PhotoObservation Set ";
//$SQL2=$SQL2."ph_obs_Description = '".$item2['strPhoto_Description']."', ";
//$SQL2=$SQL2."ph_obs__Image = '".$item2['strPhoto_Image']."', ";
$SQL2=$SQL2."ph_obs_IDObservation = '333360' ";
$SQL2=$SQL2."WHERE ph_obs__Id = 4";
$result = mysql_query($SQL2);
*/
















?>
