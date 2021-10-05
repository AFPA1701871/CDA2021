<?php
include "FonctionsTableaux.php";
$tab = creerTableauAvecTaille(5);
$consec = true;
$i = 0;
if ($tab[0] < $tab[$i + 1])
{ //Sens croissant
    $sens = 1;
}
else
{
    $sens = 0; //Evite une erreur undefined variable si le tableau est décroissant
}

do
{
    $consec = false;
    if ($sens == 1)
    { //Sens croissant
        if ($tab[$i] + 1 == $tab[$i + 1])
    {
            $i += 1;
            $consec = true;
        }
    }
    else
    { //Sens décroissant
        if ($tab[$i] - 1 == $tab[$i + 1])
    {
            $i += 1;
            $consec = true;
        }

    }

} while ($consec && $i < count($tab) - 1);
//conclusion
if ($consec == true)
{
    echo "Le tableau est consécutif";
}
else
{
    echo "Le tableau n'est pas consécutif";
}
