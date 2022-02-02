<?php

class PaniersManager
{

	public static function add(Paniers $obj)
	{
		return DAO::add($obj);
	}

	public static function update(Paniers $obj)
	{
		return DAO::update($obj);
	}

	public static function delete(Paniers $obj)
	{
		return DAO::delete($obj);
	}

	public static function findById($id)
	{
		return DAO::select(Paniers::getAttributes(), "Paniers", ["IdPanier" => $id])[0];
	}

	public static function getList(array $nomColonnes = null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
		$nomColonnes = ($nomColonnes == null) ? Paniers::getAttributes() : $nomColonnes;
		return DAO::select($nomColonnes, "Paniers",   $conditions,  $orderBy,  $limit,  $api,  $debug);
	}
}
