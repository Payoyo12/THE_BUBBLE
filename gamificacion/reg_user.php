<?php

include 'header.php';

try{

	$conn = mysqli_connect($db_server, $db_user, $db_pass, $db_database);

	if (!$conn) {
		echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
	}else {
		

		if (isset($_POST['user']) &&
			isset($_POST['pass']) &&
			isset($_POST['score']) 
		) {
			
			$user = $_POST['user'];
			$pass = $_POST['pass'];
			$score = $_POST['score'];


			$sql = "SELECT * FROM `usuarios` WHERE user='".$user."';";

			$resultado = $conn->query($sql);

			if ($resultado->num_rows >0) {
				echo '{"codigo":403,"mensaje":"Ya existe un usuario registrado con ese nombre","respuesta":"'.$resultado->
				num_rows.'"}';
			}else {
				$sql = "INSERT INTO `usuarios`(`id`, `user`, `pass`, `score`)
					VALUES (NULL,'".$user."','".$pass."','".$score."')";

				if ($conn->query($sql) === TRUE) {

					$sql = "SELECT * FROM `usuarios` WHERE user='".$user."';";
					$resultado = $conn->query($sql);
					$texto='';
					while($row = $resultado->fetch_assoc()){
						$texto = 
						"{#id#:".$row['id'].
						",#user#:#".$row['user'].
						"#,#pass#:#".$row['pass'].
						"#,#score:".$row['score'].
						"}";
					}

					echo '{"codigo":201,"mensaje":"Usuario creado correctamente","respuesta":"'.$texto.'"}';
				}else {
					echo '{"codigo":401,"mensaje":"Error intentando crear el usuario","respuesta":""}';
				}
			}

		}else {
			echo '{"codigo":402,"mensaje":"Faltan datos para ejecutar la accion solicitada","respuesta":""}';
		}
 
	}
} catch (Exception $e){
	echo '{"codigo":400,"mensaje":"Error al conectar con el servidor","respuesta":""}';
}




include 'footer.php';