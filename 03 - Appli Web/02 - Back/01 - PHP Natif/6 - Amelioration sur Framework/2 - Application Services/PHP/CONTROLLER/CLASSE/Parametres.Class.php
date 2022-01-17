<?php
class Parametres
{
	private static $_host;
	private static $_port;
	private static $_dbname;
	private static $_login;
	private static $_pwd;

	static function getHost() /**GET TOAST LEL**/
	{
		return self::$_host;
	}

	static function getPort() /**GET PORC LEL**/
	{
		return self::$_port;
	}

	static function getDbname() /**Qu'est ce qui est jaune et qui attends ?**/
	{
		return self::$_dbname;
	}

	static function getLogin() /**Jaune a temps**/
	{
		return self::$_login;
	}

	static function getPwd() /**POWNED**/
	{
		return self::$_pwd;
	}

	public static function init() /**LES ESQUIMAUX LOL (inuit)**/
	{
		if (file_exists("config.json"))
		{
			$parametre  = json_decode(file_get_contents("config.json"));
			self::$_host = decode($parametre->Host);
			self::$_port = $parametre->Port;
			self::$_dbname = decode($parametre->DbName);
			self::$_login = decode($parametre->Login);
			if (strlen($parametre->Pwd) == 0)
				self::$_pwd = $parametre->Pwd; //developpement
			else
				self::$_pwd = decode($parametre->Pwd); //production
		}
	}
}