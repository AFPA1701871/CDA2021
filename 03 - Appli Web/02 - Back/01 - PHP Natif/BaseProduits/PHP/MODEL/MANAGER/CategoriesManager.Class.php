<?php

class CategoriesManager 
{

	public static function add(Categories $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Categories $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Categories $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(Categories::getAttributes(),"Categories",["idCategorie" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?Categories::getAttributes():$nomColonnes;
		return DAO::select($nomColonnes,"Categories",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}