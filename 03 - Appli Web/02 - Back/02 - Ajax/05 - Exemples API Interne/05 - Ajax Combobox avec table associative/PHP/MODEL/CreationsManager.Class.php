<?php
class CreationsManager
{

	public static function add(Creations $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("INSERT INTO Creations(idAuteur,idOeuvre) VALUES (:idAuteur,:idOeuvre)");
		$requete->bindValue(":idAuteur", $obj->getIdAuteur());
		$requete->bindValue(":idOeuvre", $obj->getIdOeuvre());
		$requete->execute();
	}

	public static function update(Creations $obj)
	{
		$db = DbConnect::getDb();
		$requete = $db->prepare("UPDATE Creations SET idAuteur=:idAuteur,idOeuvre=:idOeuvre WHERE idCreation=:idCreation");
		$requete->bindValue(":idCreation", $obj->getIdCreation());
		$requete->bindValue(":idAuteur", $obj->getIdAuteur());
		$requete->bindValue(":idOeuvre", $obj->getIdOeuvre());
		$requete->execute();
	}

	public static function delete(Creations $obj)
	{
		$db = DbConnect::getDb();
		$db->exec("DELETE FROM Creations WHERE idCreation=" . $obj->getIdCreation());
	}

	public static function findById($id)
	{
		$db = DbConnect::getDb();
		$id = (int) $id; //Pour se protéger de la surcharge d'URL
		$requete = $db->query("SELECT * FROM Creations WHERE idCreation =" . $id);
		$resultat = $requete->fetch(PDO::FETCH_ASSOC);
		if ($resultat != false) {
			return new Creations($resultat);
		} else {
			return false;
		}
	}

	public static function getList($api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM Creations");
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeCreations[] = $donnees;
			}else{
				$listeCreations[] = new Creations($donnees);
			}
		}
		return $listeCreations;
	}
	public static function getListByAuteur($idAuteur, $api)
	{
		$db = DbConnect::getDb();
		$requete = $db->query("SELECT * FROM Creations where idAuteur = ".$idAuteur);
		while ($donnees = $requete->fetch(PDO::FETCH_ASSOC)) {
			if ($api) {
				$listeCreations[] = $donnees;
			}else{
				$listeCreations[] = new Creations($donnees);
			}
		}
		return $listeCreations;
	}

}