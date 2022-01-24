<?php
class AuteursOeuvresManager
{

	public static function getList($api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM auteurs_oeuvres");
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeAuteursOeuvres[] = $donnees;
			}else{
				$listeAuteursOeuvres[] = new AuteursOeuvres($donnees);
			}
		}
		return $listeAuteursOeuvres;
	}

	public static function getListByAuteur($idAuteur,$api)
	{
		$id=(int) $idAuteur;
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM auteurs_oeuvres WHERE idAuteur=$id");
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeByAuteur[] = $donnees;
			}else{
				$listeByAuteur[] = new AuteursOeuvres($donnees);
			}
		}
		return $listeByAuteur;
	}

}

