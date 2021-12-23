<?php
/**
 * Fonction qui renvoi l'objet renvoyé par l'appel de la methode static FindById situé dans le manager de la classe
 * @nomTable : contient le nom de la table / classe
 * @id : contient l'id recherché 
 */
function appelFindById($nomTable,$id)
{
    // $methode = "Table_".$nomTable."Manager::findById";
    $methode = $nomTable."Manager::findById";
    return call_user_func($methode,$id);
}

