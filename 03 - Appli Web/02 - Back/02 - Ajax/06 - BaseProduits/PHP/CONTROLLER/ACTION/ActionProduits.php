<?php
$elm = new Produits($_POST);

switch ($_GET['mode']) {
	case "Ajouter": {
		$elm = ProduitsManager::add($elm);
		break;
	}
	case "Modifier": {
		$elm = ProduitsManager::update($elm);
		break;
	}
	case "Supprimer": {
		$elm = ProduitsManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeProduits");