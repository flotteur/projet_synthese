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

 class AgUneObserv {
	public $strObserv_DateObservation = "";
	public $strObserv_Id = "";
	public $strObserv_IDOiseau = "";
	public $strObserv_IDUsager = "";
	public $strObserv_Titre = "";
	public $strObserv_Resume = "";
	public $arrObservLesPhotos = "";
	
	public $strObserv_Position_lat = "";
	public $strObserv_Position_long = "";	
	//$e->birthdate = date('m/d/Y h:i:s a', "8/5/1974 12:20:03 p");
	//$e->birthdate = date('m/d/Y h:i:s a', strtotime("8/5/1974 12:20:03"));
	public $strObservFlagInsertUpdate = "";
	
	
	
	
}


				
 class AgPhotoObservation {
 
	public $strPhoto_Id = "";
	public $strPhoto_Image = "";
	public $strPhoto_Description = "";
	public $strPhoto_IDObservation = "";
	public $strPhoto_ImageMiniature = "";
	public $strPhoto_Commentaire = "";
	public $strPhoto_url_big = "";
	
}
	
   
   
   
   
 
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



$result1 = mysql_query("SELECT * FROM tb_observations Order by obs_DateObservation desc");
//fetch tha data from the database



$arr_les_observations = array();

while ($row1 = mysql_fetch_array($result1)) {
   
   //echo "obs_Id:".$row1{'obs_Id'}.", obs_DateObservation:".$row1{'obs_DateObservation'}.", obs_Position_lat: ".$row1{'obs_Position_lat'}."<br>";

 
   
	  
	$e1 = new AgUneObserv();
	$e1->strObserv_DateObservation = $row1{'obs_DateObservation'};
	$e1->strObserv_Id  = $row1{'obs_Id'};
	$e1->strObserv_IDOiseau  = $row1{'obs_IDOiseau'};  
	$e1->strObserv_IDUsager  = $row1{'obs_IDUsager'};  
	$e1->strObserv_Titre  = $row1{'obs_Titre'};  
	$e1->strObserv_Resume  = $row1{'obs_Resume'}; 
	$e1->strObserv_Position_lat = $row1{'obs_Position_lat'};
	$e1->strObserv_Position_long = $row1{'obs_Position_long'};
	
	
	//$e1->strObservFlagInsertUpdate = $row1{'obs_Position_long'};

	$e1->arrObservLesPhotos  = array();
	
	
	   
	
	$result2 = mysql_query("SELECT * FROM tb_PhotoObservation where ph_obs_IDObservation = ".$row1{'obs_Id'}."");
	while ($row2 = mysql_fetch_array($result2)) {
	
		//echo "ph_obs_IDObservation: ".$row2{'ph_obs_IDObservation'}.", ph_obs__Id:".$row2{'ph_obs__Id'}.", ph_obs_Description:".$row1{'ph_obs_Description'}."<br>";
		//echo '777'.$row2{'ph_obs__Image'}.'<br>';
		//echo "777<img src=".$row2{'ph_obs__Image'}." alt='' /><br>";
		//$e1->arrObservLesPhotos[] = $e2;
		$e2 = new AgPhotoObservation();
		$e2->strPhoto_Id = $row2{'ph_obs__Id'};
		$e2->strPhoto_Image = $row2{'ph_obs__Image'};
		$e2->strPhoto_Description = $row2{'ph_obs_Description'};
		$e2->strPhoto_IDObservation = $row2{'ph_obs_IDObservation'};
		$e2->strPhoto_ImageMiniature = "";
		$e2->strPhoto_Commentaire = "";
		$e2->strPhoto_url_big = $row2{'ph_obs_url_big'};
		
		
		
		//echo "-array_push--arrObservLesPhotos---ph_obs__Id:".$row2{'ph_obs_Description'}."<br>";	
		
		//$e1->arrObservLesPhotos[] = $e2;
		
		array_push($e1->arrObservLesPhotos, $e2);
	   
	   
	   
	   
	}
	

	//$arr_les_observations[] = $e1;
	array_push($arr_les_observations, $e1);
   
   
}


//echo "<br><br><br>";



if(0){
	echo "<pre>";	
	echo pretty_json(json_encode($arr_les_observations));
	echo "</pre>";
}else{
	echo json_encode($arr_les_observations);
}




//echo "<br>";


//$array1 = json_decode($arr_les_observations, true); 
//print_r($arr_les_observations, true);



//echo '<img src="data:image/png;base64,"'.base64_decode($le_data).' alt="" />';
//echo '222<img src="'.$le_data1.'" alt="" />';



?>
