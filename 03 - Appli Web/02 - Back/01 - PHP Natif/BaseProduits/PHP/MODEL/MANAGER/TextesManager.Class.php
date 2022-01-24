<?php

class TextesManager
{

	public static function findByCodes($codeLangue,$codeTexte)
	{
		 return DAO::select([$codeLangue],"textes",["codeTexte" => $codeTexte],null,null,true)[0][$codeLangue];
	}

	public static function checkIfLangExist($codeLangue)
	{
		$db=DbConnect::getDb();
		$q=$db->prepare("SHOW COLUMNS FROM textes LIKE :codeLangue");
		$q->bindValue(":codeLangue", $codeLangue, PDO::PARAM_STR);
		$q->execute();
		$results = $q->fetch(PDO::FETCH_ASSOC);
		return ($results != false); // renvoi vrai si la requete retourne des données, false sinon
	}
}