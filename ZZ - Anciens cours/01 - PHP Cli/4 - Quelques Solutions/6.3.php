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
afficheTableau($tab);