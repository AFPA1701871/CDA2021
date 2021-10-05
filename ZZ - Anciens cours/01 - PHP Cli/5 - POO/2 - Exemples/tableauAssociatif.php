<?php

function AfficheTab($tab)
{
    foreach ($tab as $elt)
    {
        echo $elt . " ";
    }
    echo "\n";
}

function AfficheTabAssoc($tab)
{
    foreach ($tab as $key=>$elt)
    {
        echo $key." a obtenu ".$elt . " \n";
    }
    echo "\n";

}
$tabNormal = [1, 2, 3, 4, 5];

$note=["toto"=>15,"titi"=>10,"tata"=>12];
AfficheTabAssoc($note);