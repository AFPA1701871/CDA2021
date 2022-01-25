<?php

class MavueManager 
{

	public static function add(Mavue $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Mavue $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Mavue $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(Mavue::getAttributes(),"Mavue",["idProduit" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?Mavue::getAttributes():$nomColonnes;
		return DAO::select($nomColonnes,"Mavue",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}