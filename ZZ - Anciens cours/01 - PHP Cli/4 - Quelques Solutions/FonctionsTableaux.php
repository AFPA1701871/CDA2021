<?php


function demandeEntier($invite) // Demande un entier à l'utilisateur
{
    do
    {
        do
        {
            $nombre = readline($invite);
        } while (!is_numeric($nombre)); // on verifie que la chaine de caracterer ne contient que des chiffres
    } while (!is_int($nombre * 1)); // on vérifie que le nombre est entier (pas réel)
    return $nombre; //renvoi le nombre saisi
}


/*
Description : Affiche les éléments du tableau séparés par une tabulation // Utilisation du foreach
$tab : tableau à afficher
*/
function afficheTableau($tab)
{
    echo "\n";
    foreach ( $tab as $elt)  // le tableau est parcouru de la 1ere à la dernière case, les cases sont mises tour à tous dans $elt
    {
        echo $elt."\t";
    }
    echo "\n";
}

/*
Description : cette fonction permet de créer un tableau de taille passée en parametre avec les éléments saisis par l'utilisateur
$tailleTableau : taille du tableau
return  : renvoi le tableau rempli
*/
function creerTableauAvecTaille($tailleTableau) 
{
    for ($i=0;$i<$tailleTableau;$i++)
    {
        $tab[]=demandeEntier("Entrer une valeur");
    }
    return $tab;
}

/*
Description : cette fonction permet de créer un tableau avec les éléments saisis par l'utilisateur, fin de saisi avec la saisie de 0
return  : renvoi le tableau rempli
*/
function creerTableauTermineParZero()
{
    do{
        $nb = demandeEntier("Entrer une valeur");
        if ($nb != 0 ) //evite que le dernier 0 entre dans le tableau
        {
            $tab[]=$nb;
        }
    }
    while ($nb != 0 );
    return $tab;
}

