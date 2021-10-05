<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

//CREATION DU RECTANGLE
$r = new Rectangle(["Largeur" => 10, "Longueur" => 5]);
echo "\nLe RECTANGLE\n".$r->toString(); // AFFICHAGE DE RECTANGLE

//CREATION DU TRIANGLE
$t1 = new Triangle(["Base" => 10, "Hauteur" => 5]);
echo "\nLe TRIANGLE\n".$t1->toString(); //AFFICHAGE DU TRIANGLE


//CREATION De CERCLE
$c1 = new Cercle(["Diametre" => 10]);
echo "\n\nLe CERCLE\n".$c1->toString()."\n"; //AFFICHAGE De CERCLE

//CREATION De PAVE
$p1 = new Pave(["Largeur" => 10,"Longueur"=>5,"Hauteur"=>7]);
echo "\nLe PAVE\n".$p1->toString();

//CREATION De SPHERE
$s1 = new Sphere(["Diametre" => 6]);
echo "\nLa SPHERE\n".$s1->toString();

//CREATION De Pyramide
$py1 = new Pyramide(["Base" => 10, "Hauteur" => 5, "Haut"=>7]);
echo "\nLa PYRAMIDE\n".$py1->toString();