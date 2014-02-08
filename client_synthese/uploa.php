<?php
$im = imagecreatefrompng($GLOBALS["HTTP_RAW_POST_DATA"]);
imagepng($im, 'filename.png');
?>