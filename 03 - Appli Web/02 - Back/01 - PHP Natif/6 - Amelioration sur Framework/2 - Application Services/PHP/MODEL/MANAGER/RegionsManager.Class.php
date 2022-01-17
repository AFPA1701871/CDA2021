<?php

class RegionsManager
{

	public static function add(Regions $obj)
	{
		return DAO::add($obj);
	}

	public static function update(Regions $obj)
	{
		return DAO::update($obj);
	}

	public static function delete(Regions $obj)
	{
		return DAO::delete($obj);
	}

	public static function findById($id)
	{	// select renvoi 1 tableau avec 1 objet, on renvoi la 1ere case
		return DAO::select(Regions::getAttributes(), "Regions", ["reg_id" => $id])[0];
	}

	public static function getList()
	{
		return DAO::select(Regions::getAttributes(), "Regions");
	}
}
