<?php


require "FonctionsTableaux.php";

// Création d'un tableau avec un nombre de valeurs aléatoire
$longueur = demandeEntier ("Quelle est la taille du tableau ? ");
$tab = creerTableauAvecRand($longueur);
rsort($tab);
afficheTableau($tab);
// On boucle tant que le tableau n'est pas trié
do {
    $trier = false;     // On initialise le flag a faux
    // echo "nouveau tour flag : $trier \n";
    for ($i = 0; $i < count($tab) - 1; $i++)  // On parcourt le tableau
    {
        if ($tab[$i] < $tab[$i + 1]) // On vérifie que la valeur N est supérieur à N -1
        {
            $temp = $tab[$i];                  // On stock temporairement une valeur
            $tab[$i] = $tab[$i + 1];            // On renplace la valeur N par N +1
            $tab[$i + 1] = $temp;              // On remplace la valeur N + 1 par la valeur temporaire
            $trier = true;                      // On initialise le flag à vrai pour relancer la boucle
            // echo "i : $i temp : $temp tab[i] : $tab[$i] tab[i+1] : " . $tab[$i+1]. " flag : $trier";
            // afficheTableau($tab);
        }   
    }
    afficheTableau($tab);
} while ($trier);

// Affichage
afficheTableau($tab);
