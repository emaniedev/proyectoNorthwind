<?php
/*
	Esta página realiza las siguientes acciones según los parámetros recibidos:
	
	Parámetros:	accion=nueva&url=xxxxx&titulo=xxxxx
	Acción:		Insertará la url xxxxx en la tabla MySQL de RSS.
	Salida:		Imprimirá el ID del último recurso añadido.
	Formato:	Texto

	Parámetros:	accion=borrar&id=xx
	Acción:		Borrará la url con id x de la tabla de RSS.
	Salida:		Imprimirá mensaje de OK.
	Formato:	Texto
	
	Parámetros:	accion=cargar&id=xx
	Acción:		Se conecta a la URL indicada por el ID y descarga el RSS de Internet.
	Salida:		El fichero XML del RSS en formato JSON.
	Formato: 	JSON

	Parámetros:	accion=recursosRSS
	Acción:		Devuelve todos los datos de la tabla rss.
	Salida:		Un array con los campos id, titulo, url en formato JSON.
	Formato: 	JSON	
	
	Parámetros:	accion=numRSS
	Acción:		Devuelve el número total de RSS que tenemos en la tabla.
	Salida:		Un número indicando los RSS que hay en la tabla.
	Formato: 	texto
*/

// Cabecera para indicar que vamos a enviar datos JSON y que no haga caché de los datos.
header('Cache-Control: no-cache, must-revalidate');
header('Expires: Mon, 26 Jul 1997 05:00:00 GMT');

/* 	Utilizar el fichero dbcreacion.sql incluído en la carpeta para crear la base de datos, usuario y tabla en tu servidor MySQL.
Si fuera necesario modifica los datos de la configuración y adáptalos a tu entorno de trabajo. */

/*CORS*/
if (isset($_SERVER['HTTP_ORIGIN'])) {  
    header("Access-Control-Allow-Origin: {$_SERVER['HTTP_ORIGIN']}");  
    header('Access-Control-Allow-Credentials: true');  
    header('Access-Control-Max-Age: 86400');   
}  
  
if ($_SERVER['REQUEST_METHOD'] == 'OPTIONS') {  
  
    if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_METHOD']))  
        header("Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS");  
  
    if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']))  
        header("Access-Control-Allow-Headers: {$_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']}");  
}  

// Creamos la conexión al servidor.
$conexion= new mysqli("localhost","ajax","ajax","ajax");
	
	
switch ($_GET['accion'])
{
	case 'nueva':
        $titulo=$_GET['titulo'];
        $url=$_GET['url'];
		$sql="insert into rss(titulo,url) values('$titulo','$url')";
		$conexion->query($sql);
		echo $conexion->insert_id;
	break;

	case 'borrar':
        $id=$_GET['id'];
		$sql= "delete from rss where id=$id";
		$conexion->query($sql);
		echo "el borrado es OK";
	break;

	
	case 'cargar':
		$id=$_GET['id'];
		$sql="select * from rss where id=$id";
		$resultados=$conexion->query($sql);
		$registros=$resultados->fetch_array(MYSQLI_ASSOC);
		

		$doc = new DOMDocument();
		$doc->load($registros['url']);
		$arrFeeds = array();
		foreach ($doc->getElementsByTagName('item') as $node) 
		{
			$itemRSS = array ( 
				'titulo' => $node->getElementsByTagName('title')->item(0)->nodeValue,
				'descripcion' => $node->getElementsByTagName('description')->item(0)->nodeValue,
				'url' => $node->getElementsByTagName('link')->item(0)->nodeValue,
				'fecha' => $node->getElementsByTagName('pubDate')->item(0)->nodeValue
				);
				
			array_push($arrFeeds, $itemRSS);
		}	

		header('Content-Type: application/json');
		echo json_encode($arrFeeds);
	break;

	case 'recursosRSS':
		$sql= "select * from rss order by id";
		$resultados=$conexion->query($sql);
		while ($fila = $resultados->fetch_array(MYSQLI_ASSOC))
		{
			// Almacenamos en un array cada una de las filas que vamos leyendo del recordset.
			// Cada fila del array coincidirá con el id del RSS.
			$datos[$fila['id']]=  array_map("utf8_encode", $fila);
		}
		header('Content-Type: application/json');
		echo json_encode($datos);
	break;
	
	case 'numRSS':	// Devuelve el número total de RSS que tenemos en la base de datos.
		$sql= "select * from rss order by id";
		$resultados=$conexion->query($sql);
		echo ($resultados->num_rows);
	break;
}
	
$conexion->close();
?>