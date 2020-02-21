<?php
	if(isset($_GET["x"]) and isset($_GET["y"])) {
		$cords_file = fopen("cords.txt", "w") or die("Unable to open file!");
		$txt = $_GET["x"] . " " . $_GET["y"];
		fwrite($cords_file, $txt);
		fclose($cords_file);
	}
?>
