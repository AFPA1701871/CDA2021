<?php

class MenusManager 
{	
	// sans protection , le libellé recu dans le formulaire est directement injecté
	public static function addMenu($lib)
	{
 		$db=DbConnect::getDb();
		// var_dump("INSERT INTO Menus (libelleMenu) VALUES ('".$lib."')");
		$q=$db->exec("INSERT INTO Menus (libelleMenu) VALUES ('".$lib."')");
		
	}

	public static function add(Menus $obj)
	{
 		$db=DbConnect::getDb();
		$q=$db->prepare("INSERT INTO Menus (libelleMenu) VALUES (:libelleMenu)");
		$q->bindValue(":libelleMenu", $obj->getLibelleMenu());
		$q->execute();
	}

	public static function update(Menus $obj)
	{
 		$db=DbConnect::getDb();
		$q=$db->prepare("UPDATE Menus SET idMenu=:idMenu,libelleMenu=:libelleMenu WHERE idMenu=:idMenu");
		$q->bindValue(":idMenu", $obj->getIdMenu());
		$q->bindValue(":libelleMenu", $obj->getLibelleMenu());
		$q->execute();
	}
	public static function delete(Menus $obj)
	{
 		$db=DbConnect::getDb();
		$db->exec("DELETE FROM Menus WHERE idMenu=" .$obj->getIdMenu());
	}
	public static function findById($id)
	{
 		$db=DbConnect::getDb();
		$id = (int) $id;
		$q=$db->query("SELECT * FROM Menus WHERE idMenu =".$id);
		$results = $q->fetch(PDO::FETCH_ASSOC);
		if($results != false)
		{
			return new Menus($results);
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
		$q = $db->query("SELECT * FROM Menus");
		while($donnees = $q->fetch(PDO::FETCH_ASSOC))
		{
			if($donnees != false)
			{
				$liste[] = new Menus($donnees);
			}
		}
		return $liste;
	}
}