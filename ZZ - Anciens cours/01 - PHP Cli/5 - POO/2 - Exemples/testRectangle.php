<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");


$r = new Rectangle(["longueur"=>10,"largeur"=>10]);
$r->AfficherRectangle();
