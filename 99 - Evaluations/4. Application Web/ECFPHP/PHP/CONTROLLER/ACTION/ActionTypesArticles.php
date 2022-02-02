<?php
$elm = new TypesArticles($_POST);

switch ($_GET['mode']) {
	case "Ajouter": {
		$elm = TypesArticlesManager::add($elm);
		break;
	}
	case "Modifier": {
		$elm = TypesArticlesManager::update($elm);
		break;
	}
	case "Supprimer": {
		$elm = TypesArticlesManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeTypesArticles");