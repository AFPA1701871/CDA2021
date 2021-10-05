<?php

function remplirTableauAlea()
{
    $ligne = readline("Ligne : ");
    $colonne = readline("Colonne : ");
    for ($i = 0; $i < $ligne; $i++)
    {
        for ($j = 0; $j < $colonne; $j++)
        {
            $t[$i][$j] = rand(0, 10);
        }
    }
    return $t;
}

function afficheTableau2Dim($t)
{
    echo "\n";
    $nbCol = count($t[0]);
    // on prepare les séparateurs et le titre
    $ligneSuperieure = "";
    $ligneIntermediaire = "";
    $titre = "";
    for ($k = 1; $k <= $nbCol; $k++)
    {
        //on commence à 1 pour afficher les numeros des colonnes
        $titre .= "\t    " . $k;
        if ($k == $nbCol)
        {
            $ligneSuperieure .= "_______";
        }
        else
        {
            $ligneSuperieure .= "________";
        }
        $ligneIntermediaire .= "_______|";
    }

    //Affiche ligne par ligne
    for ($i = 0; $i < count($t); $i++)
    {
        if ($i == 0) //haut du tableau
        {
            echo $titre . "\n\t ";
            //ligne supérieur du tableau
            echo $ligneSuperieure."\n";
        }
        else //Centre du tableau
        {
            //ligne intermédiaire

            echo $ligneIntermediaire . "\n";
        }
        //affichage du numéro de la ligne
        $chiffre = $i + 1;
        echo "    " . $chiffre;
        //affichage des élément du tableau
        for ($j = 0; $j < $nbCol; $j++)
        {
            echo "\t|   " . $t[$i][$j];
        }
        echo "\t|\n\t|";
    }
    //bas du tableau
    echo $ligneIntermediaire."\n";

}

$tab = remplirTableauAlea();
afficheTableau2Dim($tab);
