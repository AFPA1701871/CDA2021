<?php
$pasDErreur = true;
var_dump($_POST);
$p = new Produits($_POST);
var_dump($p);
switch ($_GET['mode']) {
    case "Ajouter": {
            $pasDErreur = ProduitsManager::add($p);
            break;
        }
    case "Modifier": {

            $pasDErreur = ProduitsManager::update($p);
            break;
        }
    case "Supprimer": {

            $pasDErreur = ProduitsManager::delete($p);
            break;
        }
}
if ($pasDErreur) { // si pas d'erreur
    header("location:index.php?page=listeProduit");
} else {
    header("location:index.php?page=erreur&cible=listeProduit&codeErreur=erreur" . $_GET['mode']);
}
