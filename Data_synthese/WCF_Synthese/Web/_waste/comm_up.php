<?php 
//error_reporting(E_ALL);
//ini_set('display_errors', '1');

function left($str, $length) {
     return substr($str, 0, $length);
}


 
 
 
 
//phpinfo();
$username = "user1_cegep";
$password = "cegep1234";
$hostname = "localhost"; 

//connection to the database
$dbhandle = mysql_connect($hostname, $username, $password)
  or die("Unable to connect to MySQL");
echo "Connected to MySQL\n";

$selected = mysql_select_db("cegep_oiseaux",$dbhandle)
  or die("Could not select examples");


//$result = mysql_query("INSERT INTO tb_observations (obs_Id,obs_DateObservation,obs_Position_lat,obs_Image_ascii) VALUES('444444','1384143205423','48.5321','".$le_data2."')");


//http://198.100.145.177/cegep/index.html
//http://198.100.145.177/cegep/test.php
$data = json_decode(file_get_contents('php://input'),true);
//$data = utf8_encode($data); 
//$gdgdgfd = var_dump($data);
 
 $x1=0;
 

$strObserv_Id_cumu=$data;
//foreach($data as $item) {
	
	//$result = mysql_query("INSERT INTO tb_observations (obs_Id,obs_DateObservation,obs_Position_lat,obs_Image_ascii) VALUES('".$item['strObserv_Id']."','1384143205423','48.5321','".$le_data2."')");

	$La_comm_Id = $data['comm_Id'];
	$La_comm_Date = $data['comm_Date'];
	$La_comm_ObservationId = $data['comm_ObservationId'];
	$La_comm_UserId = $data['comm_UserId'];
	$La_comm_Resume = $data['comm_Resume'];
	
	
	$strObserv_Id_cumu=$strObserv_Id_cumu."data: ".$data."\n";
	$strObserv_Id_cumu=$strObserv_Id_cumu."La_comm_Id: ".$item['comm_Id']."\n";

	if ($La_comm_Id == "0")
	{
		
		/*		
		CREATE TABLE tb_commentaires (
		comm_Id INT auto_increment PRIMARY KEY, 
		comm_ObservationId INT, 
		comm_UserId INT, 
		comm_Date VARCHAR(20), 
		comm_Resume mediumtext character SET utf8);
		*/		
	
		//insert	
		$SQL1="";
		$SQL1=$SQL1."INSERT INTO tb_commentaires (comm_Resume) VALUES('')";
		$result = mysql_query($SQL1);
		
		//update
		$SQL2="";
		$SQL2=$SQL2."UPDATE tb_commentaires Set ";
		
		//if(){
		//$SQL2=$SQL2."comm_Id = '".$La_comm_Id."', ";
		//}
		
		
		$SQL2=$SQL2."comm_Date = '".$La_comm_Date."', ";
		$SQL2=$SQL2."comm_ObservationId = '".$La_comm_ObservationId."', ";
		$SQL2=$SQL2."comm_UserId = '".$La_comm_UserId."', ";
		$SQL2=$SQL2."comm_Resume = '".$La_comm_Resume."' ";
	
		$SQL2=$SQL2."WHERE comm_Id = LAST_INSERT_ID()";
		$result = mysql_query($SQL2);

		$strObserv_Id_cumu=$strObserv_Id_cumu."un_obs_Id: ".$La_comm_Resume." Insert Data\n";
	
	
	}else{
	
		//update
		$SQL2="";
		$SQL2=$SQL2."UPDATE tb_commentaires Set ";
		
		//if(){
		//$SQL2=$SQL2."comm_Id = '".$La_comm_Id."', ";
		//}
		
		
		$SQL2=$SQL2."comm_Date = '".$La_comm_Date."', ";
		$SQL2=$SQL2."comm_ObservationId = '".$La_comm_ObservationId."', ";
		$SQL2=$SQL2."comm_UserId = '".$La_comm_UserId."', ";
		$SQL2=$SQL2."comm_Resume = '".$La_comm_Resume."' ";
	
		$SQL2=$SQL2."WHERE comm_Id = '".$La_comm_Id."'";
		$result = mysql_query($SQL2);

		$strObserv_Id_cumu=$strObserv_Id_cumu."un_obs_Id: ".$La_comm_Resume." Update Data\n";	
	
	
	}	
	

	
	//effacer les enregistrements de photos dans la table s'il n'y a pas d'url de photo dans l'enregistrement
	//
	/*
	$result22 = mysql_query("DELETE FROM tb_PhotoObservation WHERE ph_obs_url_big = '' or ph_obs_url_big IS NULL");
	if($result22){
		
		$strObserv_Id_cumu=$strObserv_Id_cumu."Delete yes 1\n";
	}
	*/
	
//}

 
 
echo "Test data:\n(".$strObserv_Id_cumu.")\n";



?>
