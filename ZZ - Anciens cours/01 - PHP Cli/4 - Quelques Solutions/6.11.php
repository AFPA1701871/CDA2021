<?php
require "FonctionsTableaux.php";
//initialisation
echo "\nRemplissage du tableau 1\n";
$longueur1 = demandeEntier("Quelle est la taille du 1er tableau");
$t1 = creerTableauAvecTaille($longueur1);
echo "\nRemplissage du tableau 2\n";
$longueur2 = demandeEntier("Quelle est la taille du 2nd tableau");
$t2 = creerTableauAvecTaille($longueur2);

$sch=0;
//calcul

for ($iT2=0;$iT2<$longueur2;$iT2++)
{
    for ($iT1=0;$iT1<$longueur1;$iT1++)
    {
        $sch += $t2[$iT2]*$t1[$iT1];
        echo "iT2 = ".$iT2. "\t iT1 = ".$iT1. "\t t2[iT2] = ".$t2[$iT2]. "\t t1[iT1] = ".$t1[$iT1].  "\t sch = ". $sch."\n";
    }

}


//affichage
echo "\nTableau 1\n";
afficheTableau($t1);

echo "\nTableau 2\n";
afficheTableau($t2);

echo "\nLe schtroumpf est  : ". $sch. "\n";