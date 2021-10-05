<?php

//Saisie d'un entier
do
{
    do
    {
        $nombre = readline("Entrer un nombre : ");
    } while (!is_numeric($nombre));  // on verifie que la chaine de caracterer ne contient que des chiffres
} while (!is_int($nombre * 1)); // on vérifie que le nombre est entier (pas réel)

$facto = 1;
/* Calculer la factorielle */
/*for ($i=1;$i<=$nombre;$i++)
{
    $facto = $facto *$i;   //$facto *=$i;
    echo $i;
    if ($i==$nombre)
    {
        echo " = ";
    }
    else{
        echo " x ";
    }
}
echo $facto;*/

/* Calculer la factorielle */
echo "1";
for ($i=2;$i<=$nombre;$i++)
{
    echo " x " .$i;
    $facto = $facto *$i;   //$facto *=$i;
}
echo " = ".$facto;