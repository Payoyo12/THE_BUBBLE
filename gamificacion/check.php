<?php
include 'header.php';


try{

	$conn = mysqli_connect($db_server, $db_user, $db_pass, $db_database);

	if (!$conn) {
		echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
	}else {
		echo '{"codigo":200,"mensaje":"Conectado correctamente","respuesta":""}';
	}

} catch (Exception $e){
	echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
}


include 'footer.php';

