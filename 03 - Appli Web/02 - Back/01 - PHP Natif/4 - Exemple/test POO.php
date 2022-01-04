<?php

include "POO.php";
$p = new Personnes(["nom"=>"Dupond","prenom"=>"toto"]);
echo $p->getNom();
var_dump($p);
