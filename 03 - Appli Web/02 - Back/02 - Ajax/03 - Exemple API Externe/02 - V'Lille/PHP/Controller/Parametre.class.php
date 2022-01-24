<?php
class Parametre
{
    private static $host;
    private static $port;
    private static $dbname;
    private static $login;
    private static $pwd;

    /**
     * Get the value of host
     */
    public static function getHost()
    {
        return self::$host;
    }

    /**
     * Get the value of port
     */
    public static function getPort()
    {
        return self::$port;
    }
    /**
     * Get the value of dbname
     */
    public static function getDbname()
    {
        return self::$dbname;
    }

    /**
     * Get the value of login
     */
    public static function getLogin()
    {
        return self::$login;
    }

    /**
     * Get the value of pwd
     */
    public static function getPwd()
    {
        return self::$pwd;
    }

    public static function init()
    {
//on récupere les paramètres de connection base de données

        if (file_exists("parametre.ini"))
        {
            //ouverture du fichier en lecture seule
            $fp = fopen("parametre.ini", "r");
            //boucle jusqu'à la fin du fichier
            while (!feof($fp))
            {
                //lecture d'une ligne, le contenu est stocké dans un tableau
                $ligne = fgets($fp, 4096);
                if ($ligne) //$ligne = false, si la ligne est vide. cela evite de planter s'il y a des passages à la lignes en fin de fichier
                {
                    //on garde la partie utile (c'est a dire le parametre)
                    $info = explode(":", $ligne);
                    // on enleve le caractere espace à la fin
                    $param[] = substr($info[1], 0, strlen($info[1]) - 2);
                }
            }

            self::$host = $param[0];
            self::$port = $param[1];
            self::$dbname = $param[2];
            self::$login = $param[3];
            self::$pwd = $param[4];
        }
    }

}
