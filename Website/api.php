<?php
error_reporting(E_ALL);

$api = filter_input(INPUT_GET, "api");
$mail = filter_input(INPUT_GET, "mail");
$token = filter_input(INPUT_GET, "token");


if(isset($api) && isset($mail) && isset($token))
{
    $con = mysql_connect('rdbms.strato.de', 'U1523169', '2Bjaz8iRvgxEcYAeGX0MdHmUtv8rJEWh2yPigPKiWGZSW7apkn') or die ('MySQL Error');
    mysql_select_db('DB1523169', $con) or die ('MySQL Error');


    switch($api)
    {
        case "profile":            
            if (IsTokenOK($token))
            {
                $result = mysql_query("SELECT * FROM Profile WHERE Mail = '$mail';", $con) or die('MySQL Error.');

                while ($row = mysql_fetch_array($result, MYSQL_ASSOC))
                {
                    if (isset($row["IsProfileOpen"]))
                    {
                        $theInt = $row["IsProfileOpen"];
                        if ($theInt == 1)
                        {
                            $row["IsProfileOpen"] = true;
                        }
                        else
                        {
                            $row["IsProfileOpen"] = false;
                        }
                    }
                    $json[] = $row;
                }

                $output = json_encode($json);
            }
            else
            {
                echo 'Ung&uumltiges Token.';            
            }

            break;
        default:
            break;

    }    
        echo "$output"; 
}
else
{
    if (!isset($mail))
    {
        echo "Mail nicht gesetzt!";
    }
    else if (!isset($api))
    {
        echo "Api nicht gesetzt!";
    }
    else if (!isset($token))
    {        
        echo "Token nicht gesetzt!";
    }    
}    

function IsTokenOK ($token) {
    $con = mysql_connect('rdbms.strato.de', 'U1523169', '2Bjaz8iRvgxEcYAeGX0MdHmUtv8rJEWh2yPigPKiWGZSW7apkn') or die ('MySQL Error');
    mysql_select_db('DB1523169', $con) or die ('MySQL Error');
    
    $tokenquery = mysql_query("SELECT * FROM APIKeys WHERE `key` = '".$token."';", $con) or die ('MySQL Error');
    $tokenrow = mysql_fetch_row($tokenquery);
    
    return isset($tokenrow[0]);
}

?>
