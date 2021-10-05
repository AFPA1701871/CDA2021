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

	static function init() /**LES ESQUIMAUX LOL (inuit)**/
	{
		if (file_exists("parametres.ini"))
		{
			$fp=fopen("parametres.ini","r");
			while(!feof($fp)) /**WHILE SMITH**/
			{
				$ligne=fgets($fp,4906);
				if ($ligne)
				{
					$info=explode(":",$ligne);
					$param[]=substr($info[1],0,strlen($info[1])-2);
				}
			}
			self::$_host=$param[0];
			self::$_port=$param[1];
			self::$_dbname=$param[2];
			self::$_login=$param[3];
			self::$_pwd=$param[4];
		}
	}
}