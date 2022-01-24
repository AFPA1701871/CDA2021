<?php
class AuteursManager
{

	public static function add(Auteurs $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("INSERT INTO Auteurs(nomAuteur,prenomAuteur,dateNaissanceAuteur) VALUES (:nomAuteur,:prenomAuteur,:dateNaissanceAuteur)");
		$requete->bindValue(":nomAuteur", $obj->getNomAuteur());
		$requete->bindValue(":prenomAuteur", $obj->getPrenomAuteur());
		$requete->bindValue(":dateNaissanceAuteur", $obj->getDateNaissanceAuteur());
		$requete->execute();
	}

	public static function update(Auteurs $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("UPDATE Auteurs SET nomAuteur=:nomAuteur,prenomAuteur=:prenomAuteur,dateNaissanceAuteur=:dateNaissanceAuteur WHERE idAuteur=:idAuteur");
		$requete->bindValue(":idAuteur", $obj->getIdAuteur());
		$requete->bindValue(":nomAuteur", $obj->getNomAuteur());
		$requete->bindValue(":prenomAuteur", $obj->getPrenomAuteur());
		$requete->bindValue(":dateNaissanceAuteur", $obj->getDateNaissanceAuteur());
		$requete->execute();
	}

	public static function delete(Auteurs $obj)
	{
		$db = DbConnect::getDb();
		$db->exec("DELETE FROM Auteurs WHERE idAuteur=" . $obj->getIdAuteur());
	}

	public static function findById($id)
	{
		$db = DbConnect::getDb();
		$id = (int) $id; //Pour se protéger de la surcharge d'URL
		$requete = $db->query("SELECT * FROM Auteurs WHERE idAuteur =" . $id);
		$resultat = $requete->fetch(PDO::FETCH_ASSOC);
		if ($resultat != false) {
			return new Auteurs($resultat);
		} else {
			return false;
		}
	}

	public static function getList($api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM Auteurs");
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeAuteurs[] = $donnees;
			}else{
				$listeAuteurs[] = new Auteurs($donnees);
			}
		}
		return $listeAuteurs;
	}

}