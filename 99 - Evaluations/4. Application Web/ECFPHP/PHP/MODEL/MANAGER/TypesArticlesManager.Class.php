<?php

class TypesArticlesManager 
{

	public static function add(TypesArticles $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(TypesArticles $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(TypesArticles $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select(TypesArticles::getAttributes(),"TypesArticles",["IdTypeArticle" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?TypesArticles::getAttributes():$nomColonnes;
		return DAO::select($nomColonnes,"TypesArticles",   $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}