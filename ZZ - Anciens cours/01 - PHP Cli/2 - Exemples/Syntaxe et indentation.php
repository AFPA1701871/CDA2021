<?php
/* Mal indenté*/
if ($note < 10)
$mauvaisEleve++;
if ($note > 18)
$excellentEleve++;
else
$bonEleve++;

/* Correctement indenté*/
if ($note < 10)
{
    $mauvaisEleve++;
}
if ($note > 18)
{
    $excellentEleve++;
}
else
{
    $bonEleve++;
}

/*Avec le else if */
if ($note < 10)
{
    $mauvaisEleve++;
}
else if ($note > 18)
{
    $excellentEleve++;
}
else {
    $bonEleve++;
}
