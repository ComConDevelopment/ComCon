<?php
$config = parse_ini_file("ComConConfig.ini");

$host = $config['host'];
$user = $config['user'];
$pass = $config['pass'];

$conn = mysql_connect($host, $user, $pass);
if (!$conn)
{
    die('Verbindung schlug fehl: ' . mysql_erro());
}




?>