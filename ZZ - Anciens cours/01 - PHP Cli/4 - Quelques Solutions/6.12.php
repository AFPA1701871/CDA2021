<?php
require "FonctionsTableaux.php";


$nbrValeur = demandeEntier("Combien de valeur voulez vous?");
$tableau = creerTableauAvecTaille($nbrValeur);


//calcul
for ($i=0;$i<count($tableau);$i++)
{   
    $tab2[$i]=$tableau[$i]+1;
}


//affichage
afficheTableau($tab2);