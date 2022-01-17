<?php

class Test1Manager 
{

	public static function add(Test1 $obj)
	{
 		Services::add($obj);
	}

	public static function update(Test1 $obj)
	{
 		Services::update($obj);
	}

	public static function delete(Test1 $obj)
	{
 		Services::delete($obj);
	}

	public static function findById($id)
	{
 		Services::select(Test1::getAttributes(),"Test1",["idTest1" => $id]);
	}

	public static function getList()
	{
 		Services::select(Test1::getAttributes(),"Test1");
	}
}