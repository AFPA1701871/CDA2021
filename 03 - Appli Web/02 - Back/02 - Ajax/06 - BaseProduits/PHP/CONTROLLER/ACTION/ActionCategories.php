<?php
$elm = new Categories($_POST);

switch ($_GET['mode']) {
	case "Ajouter": {
		$elm = CategoriesManager::add($elm);
		break;
	}
	case "Modifier": {
		$elm = CategoriesManager::update($elm);
		break;
	}
	case "Supprimer": {
		$elm = CategoriesManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeCategories");