<?php
require "FonctionsTableaux.php";


$nbrValeur = demandeEntier("Combien de valeur voulez vous?");
$tableau = creerTableauAvecTaille($nbrValeur);

/* V1 */ 
$maxi=$tableau[0];
$pos=0;
//calcul
for ($i=0;$i<count($tableau);$i++)
{   
    if ($maxi<$tableau[$i])
    {
        $maxi=$tableau[$i];
        $pos=$i;
    }
}

//affichage
afficheTableau($tableau);
echo "Le + grand est $maxi, il est à la position $pos \n";

/* V2 */

echo "Le + grand est ". max($tableau).", il est à la position ". array_search(max($tableau),$tableau);