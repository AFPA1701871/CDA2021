<?php

//Test class Creations
$test = new Creations(["idAuteur" => "Test","idOeuvre" => "Test"]);
var_dump($test);
echo $test->toString();

//Test CreationsManager
CreationsManager::add($test);
$test = CreationsManager::findById(2);
echo $test->toString();

var_dump(CreationsManager::getList());
$test->setIdAuteur("test");
CreationsManager::update($test);
$test = CreationsManager::findById(2);
echo $test->toString();
CreationsManager::delete($test);
var_dump(CreationsManager::getList());