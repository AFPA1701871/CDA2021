<?php
class OeuvresManager
{

	public static function add(Oeuvres $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES (:titreOeuvre,:typeOeuvre,:dateOeuvre)");
		$requete->bindValue(":titreOeuvre", $obj->getTitreOeuvre());
		$requete->bindValue(":typeOeuvre", $obj->getTypeOeuvre());
		$requete->bindValue(":dateOeuvre", $obj->getDateOeuvre());
		$requete->execute();
	}

	public static function update(Oeuvres $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("UPDATE Oeuvres SET titreOeuvre=:titreOeuvre,typeOeuvre=:typeOeuvre,dateOeuvre=:dateOeuvre WHERE idOeuvre=:idOeuvre");
		$requete->bindValue(":idOeuvre", $obj->getIdOeuvre());
		$requete->bindValue(":titreOeuvre", $obj->getTitreOeuvre());
		$requete->bindValue(":typeOeuvre", $obj->getTypeOeuvre());
		$requete->bindValue(":dateOeuvre", $obj->getDateOeuvre());
		$requete->execute();
	}

	public static function delete(Oeuvres $obj)
	{
		$db = DbConnect::getDb();
		$db->exec("DELETE FROM Oeuvres WHERE idOeuvre=" . $obj->getIdOeuvre());
	}

	public static function findById($id)
	{
		$db = DbConnect::getDb();
		$id = (int) $id; //Pour se protéger de la surcharge d'URL
		$requete = $db->query("SELECT * FROM Oeuvres WHERE idOeuvre =" . $id);
		$resultat = $requete->fetch(PDO::FETCH_ASSOC);
		if ($resultat != false) {
			return new Oeuvres($resultat);
		} else {
			return false;
		}
	}

	public static function getList($api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM Oeuvres");
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeOeuvres[] = $donnees;
			}else{
				$listeOeuvres[] = new Oeuvres($donnees);
			}
		}
		return $listeOeuvres;
	}
	public static function getListbyId($listeId,$api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM Oeuvres where idOeuvre in ".$listeId);
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeOeuvres[] = $donnees;
			}else{
				$listeOeuvres[] = new Oeuvres($donnees);
			}
		}
		return $listeOeuvres;
	}
	
}