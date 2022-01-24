<?php

class RegionsManager
{
	  
	static public function add(Regions $region)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Pr�paration de la requ�te d'insertion.
		$q = $db->prepare('INSERT INTO regions(libelleRegion) VALUES(:libelleRegion)');
		
		// Assignation des valeurs pour le nom, le pr�nom.
		$q->bindValue(':libelleRegion', $region->getLibelleRegion());		
		// Ex�cution de la requ�te.
		$q->execute();
		
	}
	
	static public function delete(Regions $region)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Ex�cute une requ�te de type DELETE.
		$db->exec('DELETE FROM regions WHERE idRegion = '.$region->getIdRegion());
	}
	/**
	 * Si API = True on renvoi un tableau asociatif
	 * sinon on renvoi un tableau de Personnes
	 */
	static public function getById($id,$api)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Ex�cute une requ�te de type SELECT avec une clause WHERE, et retourne un objet Personne.
		$id = (int) $id;
		
		$q = $db->query('SELECT idRegion, libelleRegion FROM regions WHERE idRegion = '.$id);
		$donnees = $q->fetch(PDO::FETCH_ASSOC);
		
		if ($api)  return $donnees;
		return new Regions($donnees);
	}
	/**
	 * Si API = True on renvoi un tableau asociatif
	 * sinon on renvoi un tableau de Personnes
	 */
	static public function getList($api)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Retourne la liste de tous les personnes.
		
		$q = $db->query('SELECT idRegion, libelleRegion FROM regions ORDER BY idRegion');
		
		while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
		{
			$regions[] = new Regions($donnees);
			$json[]=$donnees;
		}
		if (!$api)  return $regions;
		return $json;
	}
	
	
	static public function update(Regions $region)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Pr�pare une requ�te de type UPDATE.
		$q = $db->prepare('UPDATE regions SET libelleRegion=:libelleRegion WHERE idRegion = :idRegion');
		
		// Assignation des valeurs � la requ�te.
		$q->bindValue(':idRegion', $region->getIdRegion());
		$q->bindValue(':libelleRegion', $region->getLibelleRegion());		
		// Ex�cution de la requ�te.
		$q->execute();
	}
	
	static public function count()
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		
		$q = $db->query('SELECT count(*) as nb FROM regions');
		
		$donnees = $q->fetch(PDO::FETCH_ASSOC);
		
		return $donnees;
	}
	
}