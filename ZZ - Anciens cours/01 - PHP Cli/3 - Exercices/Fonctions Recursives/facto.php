
<?php
/*

5! = 5 * 4 * 3 * 2 *1
4! = 4 * 3 * 2 *1
5! = 5* 4!

1! = 1

*/

function facto($nb)
{
    echo $nb."\n";
    if ($nb==1)     //conditoin d'arret
    {
        return 1;
    }
    else
    {
        return $nb * facto($nb-1);
    }
}

echo facto(5);