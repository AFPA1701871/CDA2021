<?php

class CategoriesManager 
{
	public static function add(Categories $obj)
	{
 		$db=DbConnect::getDb();
		$q=$db->prepare("INSERT INTO Categories (LibelleCategorie) VALUES (:LibelleCategorie)");
		// vérifier qu'il ne contient pas de ;
		$q->bindValue(":LibelleCategorie", $obj->getLibelleCategorie(), PDO::PARAM_STR);
		$q->execute();
	}

	public static function update(Categories $obj)
	{
 		$db=DbConnect::getDb();
		$q=$db->prepare("UPDATE Categories SET LibelleCategorie=:LibelleCategorie WHERE idCategorie=:idCategorie");
		$q->bindValue(":idCategorie", $obj->getIdCategorie(), PDO::PARAM_INT);
		$q->bindValue(":LibelleCategorie", $obj->getLibelleCategorie(),PDO::PARAM_STR);
		$q->execute();
	}
	public static function delete(Categories $obj)
	{
 		$db=DbConnect::getDb();
		$id = (int) $obj->getIdCategorie(); // permet de bloquer les injections SQL
		$db->exec("DELETE FROM Categories WHERE idCategorie=" .$id);
	}
	public static function findById($id)
	{
 		$db=DbConnect::getDb();
		$id = (int) $id;
		$q=$db->query("SELECT * FROM Categories WHERE idCategorie =".$id);
		$results = $q->fetch(PDO::FETCH_ASSOC);
		if($results != false)
		{
			return new Categories($results);
		}
		else
		{
			return false;
		}
	}
	public static function getList()
	{
 		$db=DbConnect::getDb();
		$liste = [];
		$q = $db->query("SELECT * FROM Categories");
		while($donnees = $q->fetch(PDO::FETCH_ASSOC))
		{
			if($donnees != false)
			{
				$liste[] = new Categories($donnees);
			}
		}
		return $liste;
	}
}