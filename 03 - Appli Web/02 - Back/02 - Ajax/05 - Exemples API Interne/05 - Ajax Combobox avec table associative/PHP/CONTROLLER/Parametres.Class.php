<?php

class Parametres
{
	private static $host;
	private static $port;
	private static $dbname;
	private static $login;
	private static $pwd;

	public static function getHost()
	{
		return self::$host;
	}

	public static function getPort()
	{
		return self::$port;
	}

	public static function getDbname()
	{
		return self::$dbname;
	}

	public static function getLogin()
	{
		return self::$login;
	}

	public static function getPwd()
	{
		return self::$pwd;
	}

	public static function init()
	{
		if(file_exists("parametre.ini")) {
			$fp = fopen("parametre.ini", "r");
			while (!feof($fp)) {
				$ligne = fgets($fp, 4096);
				if ($ligne)
				{
					$info = explode(":", $ligne);
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