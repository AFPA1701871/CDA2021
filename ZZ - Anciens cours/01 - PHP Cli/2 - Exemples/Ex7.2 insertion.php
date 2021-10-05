<?php


require "FonctionsTableaux.php";

// Création d'un tableau avec des valeur aléatoire
$longueur = demandeEntier ("Quelle est la taille du tableau ? ");
$tab = creerTableauAvecRand($longueur);

rsort($tab);
afficheTableau($tab);
// On parcourt le tableau à la recherche de la plus petite valeur
for ($i = 0; $i < count($tab)-1; $i++) {
    $mini = $tab[$i];
    $pos = $i;

    // On trie le tableau dans l'ordre décroissant
    for ($j = $i + 1; $j < count($tab); $j++) {
        if ($tab[$j] > $mini) {
            $mini = $tab[$j];
            $pos = $j;
        }
        // echo "i : $i j : $j tab[j] : $tab[$j] mini : $mini pos : $pos \n";
    }
    

$tab[$pos] = $tab[$i];
$tab[$i] = $mini;
afficheTableau($tab);
}

// Ou rsort($tab);



afficheTableau($tab);