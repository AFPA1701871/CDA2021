<?php
class TexteManager 
{
	public static function findByCodes($codeLangue,$codeTexte)
	{
		$db=DbConnect::getDb();
		$q=$db->prepare("SELECT texte FROM Texte WHERE codeTexte =:codeTexte and codeLangue = :codeLangue");
		$q->bindValue(":codeTexte", $codeTexte,PDO::PARAM_STR);
		$q->bindValue(":codeLangue", $codeLangue,PDO::PARAM_STR);
		$q->execute();
		$results = $q->fetch(PDO::FETCH_ASSOC);
		if($results != false)
		{
			return $results['texte'];  // on ne retourne que le texte, pas un objet
		}
		else
		{
			return false;
		}
	}
}