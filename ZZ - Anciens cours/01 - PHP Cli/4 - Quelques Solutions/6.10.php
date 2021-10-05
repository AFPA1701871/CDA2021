<?php
require "FonctionsTableaux.php";
//initialisation
$longueur = demandeEntier("Quelle est la taille des tableaux");
echo "\nRemplissage du tableau 1\n";
$t1 = creerTableauAvecTaille($longueur);
echo "\nRemplissage du tableau 2\n";
$t2 = creerTableauAvecTaille($longueur);
//calcul
for ( $i=0;$i<$longueur;$i++)
{
    $t3[$i]=$t1[$i]+$t2[$i];
}
//affichage
echo "\nTableau 1\n";
afficheTableau($t1);

echo "\nTableau 2\n";
afficheTableau($t2);

echo "\nTableau Somme\n";
afficheTableau($t3);