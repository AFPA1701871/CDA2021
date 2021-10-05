<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$c1 = new Categorie(["libelle"=>"Médical","tva"=>23]);
$c2 = new Categorie(["libelle"=>"Première Nécessité","tva"=>30]);

$l1 = new LieuDeStockage(["numeroEntrepot"=>1,"zone"=>"A1","ville"=>"dunkerque"]);
$l2 = new LieuDeStockage(["numeroEntrepot"=>2,"zone"=>"B1","ville"=>"dunkerque"]);
$l3 = new LieuDeStockage(["numeroEntrepot"=>3,"zone"=>"A1","ville"=>"lille"]);

$p1= new Produit(["numero"=>1212,"designation"=>"stylo","couleur"=>"blanc","dateDeValidite"=>new DateTime("2020-11-25"),"categorie"=>$c1, "lieuxStockage"=>[$l1,$l2],"prixHt"=>20]);
// var_dump($p1);
echo $p1->toString();