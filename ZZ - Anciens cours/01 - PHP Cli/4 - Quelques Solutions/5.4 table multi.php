<?php
/*
//Saisie d'un nombre
do
{
    $x = readline("Entrer un nombre : ");
} while (!is_numeric($x));

//Saisie d'un entier
do
{
    do
    {
        $x = readline("Entrer un nombre : ");
    } while (!is_numeric($x));
} while (!is_int($x * 1));

*/


/* Saisie par l'utilisateur du nombre*/
do
{
    do
    {
        $nombre = readline("Entrer un nombre : ");
    } while (!is_numeric($nombre));
} while (!is_int($nombre * 1));

/* Afficher la table de multiplication */

for ($i=1;$i<=10;$i++)
{
    echo $nombre."\t x ".$i."\t = ".($nombre*$i)."\n";
}