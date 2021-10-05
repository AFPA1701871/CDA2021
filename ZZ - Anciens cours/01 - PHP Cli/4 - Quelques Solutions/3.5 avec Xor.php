<?php
$rep = readline("entrez une valeur: \n");
$rep2 = readline("entrez la deuxieme valeur: \n");
	
if ($rep == 0  or $rep2 == 0) 
{
    echo "le produit est nul";
} 
elseif ($rep<0 xor $rep2< 0) 
	echo "le produit est négatif";
else 
	echo " le produit est positif";