<?php
require "FonctionsTableaux.php";


$nbrValeur = demandeEntier("Combien de valeur voulez vous?");
$tableau = creerTableauAvecTaille($nbrValeur);
//declaration des compteurs
$nbPositif=0;
$nbNegatif =0;

//calcul
foreach ($tableau as $case)
{   
    if ($case>=0)
    {
        $nbPositif++;
    }
    else{
        $nbNegatif++;
    }
}


//affichage
echo "\n Il y a " . $nbPositif ." valeurs positives et ". $nbNegatif. " valeurs négatives \n";