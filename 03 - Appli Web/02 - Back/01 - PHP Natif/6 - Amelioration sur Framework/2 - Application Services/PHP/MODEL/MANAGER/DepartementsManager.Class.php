<?php

class DepartementsManager 
{

	public static function add(Departements $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Departements $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Departements $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(Departements::getAttributes(),"Departements",["idDepartement" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
		$nomColonnes = ($nomColonnes==null)?Departements::getAttributes():$nomColonnes;
		var_dump($nomColonnes);
 		return DAO::select($nomColonnes,"Departements",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );
	}
}