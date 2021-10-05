<?php
require "FonctionsTableaux.php";

$nbrValeur = demandeEntier("Combien de valeur voulez vous?");
$tableau = creerTableauAvecTaille($nbrValeur);

//Calcul de la moyenne
/* V1 */
$somme = 0;
for ($i = 0; $i < count($tableau); $i++)
{
    $somme += $tableau[$i];
}
$moy = $somme/count($tableau);

/* V2 */
$moy = array_sum($tableau)/count($tableau);
//fin V2

echo "la moyenne est de $moy\n";
$compteur = 0;
// recherche des valeurs > à la moyenne
for ($i = 0; $i < count($tableau); $i++)
{
    if ($moy< $tableau[$i])
    {
        $compteur++;
    }
}


//affichage
afficheTableau($tableau);
echo "Le nombre de notes > à la moyenne est de $compteur \n";
