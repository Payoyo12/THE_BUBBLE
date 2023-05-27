<?php

include 'header.php';

try{

	$conn = mysqli_connect($db_server, $db_user, $db_pass, $db_database);

	if (!$conn) {
		echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
	}else {
		

		if (isset($_POST['user']) && isset($_POST['pass'])
		) {
			
			$user = $_POST['user'];
			$pass = $_POST['pass'];
		
			$sql = "SELECT score FROM `usuarios` WHERE user='".$user."' and pass='".$pass."';";

			$resultado = $conn->query($sql);

			if ($resultado->num_rows >0) {
				//SI existe un usuario con estos datos

					$sql = "SELECT score FROM `usuarios` WHERE user='".$user."';";
					$resultado = $conn->query($sql);
					$texto='';
					while($row = $resultado->fetch_assoc()){
						$texto = 
						"{#score:".$row['score']."}";
					}

				echo '{"codigo":207,"mensaje":"sentencia realizada con exito","respuesta":"'.$texto.'"}';

			}else {
				//NO existe un usuario con estos datos
				echo '{"codigo":204,"mensaje":"El usuario o la contrase�a son incorrectos","respuesta":""}';
			}
		}else {
			echo '{"codigo":402,"mensaje":"Faltan datos para ejecutar la accion solicitada","respuesta":""}';
		}
 
	}
} catch (Exception $e){
	echo '{"codigo":400,"mensaje":Error al conectar con el servidor","respuesta":""}';
}




include 'footer.php';