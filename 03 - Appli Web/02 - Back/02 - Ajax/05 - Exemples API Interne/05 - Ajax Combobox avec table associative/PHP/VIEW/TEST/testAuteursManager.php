<?php

//Test class Auteurs
$test = new Auteurs(["nomAuteur" => "Test","prenomAuteur" => "Test","dateNaissanceAuteur" => "Test"]);
var_dump($test);
echo $test->toString();

//Test AuteursManager
AuteursManager::add($test);
$test = AuteursManager::findById(2);
echo $test->toString();

var_dump(AuteursManager::getList());
$test->setNomAuteur("test");
AuteursManager::update($test);
$test = AuteursManager::findById(2);
echo $test->toString();
AuteursManager::delete($test);
var_dump(AuteursManager::getList());