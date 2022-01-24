<?php

class DepartementsManager
{
	  
	static public function add(Departements $departement)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Pr�paration de la requ�te d'insertion.
		$q = $db->prepare('INSERT INTO departements(libelleDepartement, idRegion) VALUES(:libelleDepartement, :idRegion)');
		
		// Assignation des valeurs pour le nom, le pr�nom.
		$q->bindValue(':libelleDepartement', $departement->getLibelleDepartement());
		$q->bindValue(':idRegion', $departement->getIdRegion());		
		// Ex�cution de la requ�te.
		$q->execute();
		
	}
	
	static public function delete(Departements $departement)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Ex�cute une requ�te de type DELETE.
		$db->exec('DELETE FROM departements WHERE idDepartement = '.$departement->getIdDepartement());
	}
	/**
	 * Si API = True on renvoi un tableau asociatif
	 * sinon on renvoi un tableau de departements
	 */
	static public function getById($id,$api)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Ex�cute une requ�te de type SELECT avec une clause WHERE, et retourne un objet Personne.
		$id = (int) $id;
		
		$q = $db->query('SELECT idRegion, libelleRegion FROM departements WHERE idRegion = '.$id);
		$donnees = $q->fetch(PDO::FETCH_ASSOC);
		
		if ($api)  return $donnees;
		return new Departements($donnees);
	}
	/**
	 * Si API = True on renvoi un tableau asociatif
	 * sinon on renvoi un tableau de departements
	 */
	static public function getList($api)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Retourne la liste de tous les departements.
		
		$q = $db->query('SELECT idDepartement, libelleDepartement,idRegion FROM departements ORDER BY idDepartement');
		
		while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
		{
			$departements[] = new Departements($donnees);
			$json[]=$donnees;
		}
		if (!$api)  return $departements;
		return $json;
	}
	
	
	static public function update(Departements $departement)
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Pr�pare une requ�te de type UPDATE.
		$q = $db->prepare('UPDATE departements SET libelleDepartement=:libelleDepartement,idRegion=:idRegion,  WHERE idDepartement = :idDepartement');
		
		// Assignation des valeurs � la requ�te.
		$q->bindValue(':idDepartement', $departement->getIdDepartement());
		$q->bindValue(':libelleDepartement', $departement->getLibelleDepartement());
		$q->bindValue(':idRegion', $departement->getIdRegion());		
		// Ex�cution de la requ�te.
		$q->execute();
	}
	
	static public function count()
	{
		$db = DbConnect::getDb(); // Instance de PDO.
		// Retourne la liste de tous les departements.
		
		$q = $db->query('SELECT count(*) as nb FROM departements');
		
		$donnees = $q->fetch(PDO::FETCH_ASSOC);
		
		return $donnees;
	}

	public static function getListByRegion($idRegion, $api){
        $id=(int) $idRegion;
        $db = DbConnect::getDb();
        $liste = [];
        $q = $db->query("SELECT * FROM departements where idRegion=$id");
        while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
        {
            if ($donnees != false)
            {
				$liste[] = new Departements($donnees);
				$json[]=$donnees;
            }
        }
		if (!$api)  return $liste;
		return $json;
    }
	
}