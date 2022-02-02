<?php

class LignesPaniersManager
{

	public static function add(LignesPaniers $obj)
	{
		return DAO::add($obj);
	}

	public static function update(LignesPaniers $obj)
	{
		return DAO::update($obj);
	}

	public static function delete(LignesPaniers $obj)
	{
		return DAO::delete($obj);
	}

	public static function findById($id)
	{
		return DAO::select(LignesPaniers::getAttributes(), "LignesPaniers", ["IdLignePanier" => $id])[0];
	}

	public static function getList(array $nomColonnes = null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
		$nomColonnes = ($nomColonnes == null) ? LignesPaniers::getAttributes() : $nomColonnes;
		return DAO::select($nomColonnes, "LignesPaniers",   $conditions,  $orderBy,  $limit,  $api,  $debug);
	}
}
