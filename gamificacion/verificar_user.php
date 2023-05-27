<?php

include 'header.php';

try{

	$conn = mysqli_connect($db_server, $db_user, $db_pass, $db_database);

	if (!$conn) {
		echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
	}else {
		

		if (isset($_GET['user']) 
		) {
			
			$user = $_GET['user'];
		
			$sql = "SELECT * FROM `usuarios` WHERE user='".$user."';";
			$resultado = $conn->query($sql);

			if ($resultado->num_rows >0) {
				echo '{"codigo":202,"mensaje":"El usuario existe en el sistema","respuesta":"'.$resultado->
				num_rows.'"}';
			}else {
				echo '{"codigo":203,"mensaje":"El usuario NO existe en el sistema","respuesta":"'.$resultado->
				num_rows.'"}';
			}
		}else {
			echo '{"codigo":402,"mensaje":"Faltan datos para ejecutar la accion solicitada","respuesta":""}';
		}
 
	}
} catch (Exception $e){
	echo '{"codigo":400,"mensaje":"Error al conectar con el servidor":""}';
}




include 'footer.php';