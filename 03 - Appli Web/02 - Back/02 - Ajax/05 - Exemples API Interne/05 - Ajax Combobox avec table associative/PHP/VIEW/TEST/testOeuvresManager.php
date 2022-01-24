<?php

//Test class Oeuvres
$test = new Oeuvres(["titreOeuvre" => "Test","typeOeuvre" => "Test","dateOeuvre" => "Test"]);
var_dump($test);
echo $test->toString();

//Test OeuvresManager
OeuvresManager::add($test);
$test = OeuvresManager::findById(2);
echo $test->toString();

var_dump(OeuvresManager::getList());
$test->setTitreOeuvre("test");
OeuvresManager::update($test);
$test = OeuvresManager::findById(2);
echo $test->toString();
OeuvresManager::delete($test);
var_dump(OeuvresManager::getList());