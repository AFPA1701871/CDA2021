<?php
function demandeEntier() // Demande un entier à l'utilisateur
{
    do
    {
        do
        {
            $nombre = readline("Entrer un entier : ");
        } while (!is_numeric($nombre)); // on verifie que la chaine de caracterer ne contient que des chiffres
    } while (!is_int($nombre * 1)); // on vérifie que le nombre est entier (pas réel)
    return $nombre; //renvoi le nombre saisi
}

function demandeEntierPhrase($phrase) // Demande un entier à l'utilisateur
{
    do
    {
        do
        {
            $nombre = readline($phrase);
        } while (!is_numeric($nombre)); // on verifie que la chaine de caracterer ne contient que des chiffres
    } while (!is_int($nombre * 1)); // on vérifie que le nombre est entier (pas réel)
    return $nombre; //renvoi le nombre saisi
}
function factorielle($nombre) //calcule la factorielle d'un nombre
{
    $facto = 1;

/* Calculer la factorielle */
    for ($i = 2; $i <= $nombre; $i++)
    {
        $facto = $facto * $i; //$facto *=$i;
    }
    return $facto;
}

function addition ($n1,$n2)
{
    return $n1+$n2;
}


$nb1 = demandeEntierPhrase("Entrer le nb1 : ");
echo $nb1."! = ".factorielle($nb1)."\n";
$nb2=demandeEntierPhrase("Entrer une valeur : ");
echo "la somme = ".addition($nb1,$nb2);


