<?php

class Test2avecmajManager 
{

	public static function add(Test2avecmaj $obj)
	{
 		Services::add($obj);
	}

	public static function update(Test2avecmaj $obj)
	{
 		Services::update($obj);
	}

	public static function delete(Test2avecmaj $obj)
	{
 		Services::delete($obj);
	}

	public static function findById($id)
	{
 		Services::select(Test2avecmaj::getAttributes(),"Test2avecmaj",["idtest2" => $id]);
	}

	public static function getList()
	{
 		Services::select(Test2avecmaj::getAttributes(),"Test2avecmaj");
	}
}