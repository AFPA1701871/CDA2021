<?php

class ArticlesManager 
{

	public static function add(Articles $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Articles $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Articles $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(Articles::getAttributes(),"Articles",["IdArticle" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?Articles::getAttributes():$nomColonnes;
		return DAO::select($nomColonnes,"Articles",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}