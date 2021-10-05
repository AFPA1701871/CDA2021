<?php
/*
départ : mot
arrivée : tom

inverser un mot consiste à mettre la 1ere lettre en 1er et inverser le reste du mot

 */

function inverseMot($mot)
{
    $longueur = strlen($mot);
    if ($longueur == 1)
    {
        return $mot;
    }
    else
    {
        return substr($mot, $longueur - 1).inverseMot(substr($mot,0,$longueur-1));
    }

}

echo inverseMot("solution");
