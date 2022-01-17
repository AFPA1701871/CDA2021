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
		return DAO::select(Departements::getAttributes(), "Departements", ["dep_id" => $id]);
	}

	public static function getList()
	{
		return DAO::select(Departements::getAttributes(), "Departements");
	}
}
