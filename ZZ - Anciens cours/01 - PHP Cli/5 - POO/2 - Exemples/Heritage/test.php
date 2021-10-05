<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$a1 = new Animal(["nom"=>"toto","race"=>"animal"]);
$c1 = new Chien(["nom"=>"tata","race"=>"chien","puce"=>123]);
$c2 = new Chien(["nom"=>"titi","race"=>"chien","puce"=>456]);

echo $a1->toString();
echo $c1->toString();
echo $c2->toString();
echo "\n".Animal::getCompteur();