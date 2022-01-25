<?php

class ProduitsManager 
{

	public static function add(Produits $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Produits $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Produits $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(Produits::getAttributes(),"Produits",["idProduit" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?Produits::getAttributes():$nomColonnes;
		return DAO::select($nomColonnes,"Produits",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}