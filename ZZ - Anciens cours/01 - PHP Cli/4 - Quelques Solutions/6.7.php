<?php
/*
/*inclus le fichier 
include "FonctionsTableaux.php";

/* inclus le fichier s'il n'est pas présent
include_once "FonctionsTableaux.php";
*/


/* le fichier est requis, le programme s'arrête si le fichier n'est pas dispo */
require "FonctionsTableaux.php";


$tab=creerTableauAvecTaille(9);

// V1
$somme = 0;
foreach ($tab as $elt)
{
    $somme += $elt;     // equivaut à somme = somme + elt
}

afficheTableau($tab);
echo "La moyenne est de  : ". $somme / count($tab);



/* ou */


//V2
echo "La moyenne est de  : ". array_sum($tab) / count($tab);
