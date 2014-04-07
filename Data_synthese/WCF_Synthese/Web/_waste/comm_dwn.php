<?php 





function pretty_json($json) {
     
    $result = '';
    $pos = 0;
    $strLen = strlen($json);
    $indentStr = ' ';
    $newLine = "\n";
    $prevChar = '';
    $outOfQuotes = true;
     
    for ($i=0; $i<=$strLen; $i++) {
     
    // Grab the next character in the string.
    $char = substr($json, $i, 1);
     
    // Are we inside a quoted string?
    if ($char == '"' && $prevChar != '\\') {
    $outOfQuotes = !$outOfQuotes;
     
    // If this character is the end of an element,
    // output a new line and indent the next line.
    } else if(($char == '}' || $char == ']') && $outOfQuotes) {
    $result .= $newLine;
    $pos --;
    for ($j=0; $j<$pos; $j++) {
    $result .= $indentStr;
    }
    }
     
    // Add the character to the result string.
    $result .= $char;
     
    // If the last character was the beginning of an element,
    // output a new line and indent the next line.
    if (($char == ',' || $char == '{' || $char == '[') && $outOfQuotes) {
    $result .= $newLine;
    if ($char == '{' || $char == '[') {
    $pos ++;
    }
     
    for ($j = 0; $j < $pos; $j++) {
    $result .= $indentStr;
    }
    }
     
    $prevChar = $char;
    }
     
    return $result;
}


class AgUnCommentaire {
	

	public $strComm_comm_Id = "";
	public $strComm_comm_Date = "";
	public $strComm_comm_ObservationId = "";
	public $strComm_comm_UserId = "";
	public $strComm_comm_Resume = "";

	//$e->birthdate = date('m/d/Y h:i:s a', "8/5/1974 12:20:03 p");
	//$e->birthdate = date('m/d/Y h:i:s a', strtotime("8/5/1974 12:20:03"));

	
}



$le_obs_id = $_GET["le_id_de_obs"];

  
 
//phpinfo();
$username = "user1_cegep";
$password = "cegep1234";
$hostname = "localhost"; 

//connection to the database
$dbhandle = mysql_connect($hostname, $username, $password)
  or die("Unable to connect to MySQL");
//echo "Connected to MySQL yea<br>";

$selected = mysql_select_db("cegep_oiseaux",$dbhandle)
  or die("Could not select examples");

$le_obs_id = intval($le_obs_id);   

$result1 = mysql_query("SELECT * FROM tb_commentaires where comm_ObservationId = '".$le_obs_id."' Order by comm_Date Desc");
//fetch tha data from the database



$arr_les_commentaires = array();

while ($row1 = mysql_fetch_array($result1)) {
   
   //echo "obs_Id:".$row1{'obs_Id'}.", obs_DateObservation:".$row1{'obs_DateObservation'}.", obs_Position_lat: ".$row1{'obs_Position_lat'}."<br>";
	  
	$e1 = new AgUnCommentaire();
	$e1->strComm_comm_Id = $row1{'comm_Id'};
	$e1->strComm_comm_Date  = $row1{'comm_Date'};
	$e1->strComm_comm_ObservationId  = $row1{'comm_ObservationId'};  
	$e1->strComm_comm_UserId  = $row1{'comm_UserId'};  
	$e1->strComm_comm_Resume  = $row1{'comm_Resume'};  
	//echo var_dump($row1)."<br>";
	//echo $e1->strComm_comm_Date."<br>";
	
	array_push($arr_les_commentaires, $e1);
}



if(0){
	echo "<pre>";	
	echo pretty_json(json_encode($arr_les_commentaires));
	echo "</pre>";
}else{
	echo json_encode($arr_les_commentaires);
}




//echo "<br>";


//$array1 = json_decode($arr_les_observations, true); 
//print_r($arr_les_observations, true);



//echo '<img src="data:image/png;base64,"'.base64_decode($le_data).' alt="" />';
//echo '222<img src="'.$le_data1.'" alt="" />';



?>
