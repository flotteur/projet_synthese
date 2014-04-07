<?php 
 

$le_observ_id = $_GET["le_id_de_obs"];
 
//phpinfo();
$username = "user1_cegep";
$password = "cegep1234";
$hostname = "localhost"; 

//connection to the database
$dbhandle = mysql_connect($hostname, $username, $password)
  or die("Unable to connect to MySQL");
echo "1111Connected to MySQL -".$le_observ_id."<br>";

$selected = mysql_select_db("cegep_oiseaux",$dbhandle)
  or die("Could not select examples");




$result1 = mysql_query("DELETE FROM tb_observations WHERE obs_Id = '".$le_observ_id."'");
$result2 = mysql_query("DELETE FROM tb_PhotoObservation WHERE ph_obs_IDObservation = '".$le_observ_id."'");


echo "Observation effacee<br>";

?>
