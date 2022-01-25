<?php
$elm = new Mavue($_POST);

switch ($_GET['mode']) {
	case "Ajouter": {
		$elm = MavueManager::add($elm);
		break;
	}
	case "Modifier": {
		$elm = MavueManager::update($elm);
		break;
	}
	case "Supprimer": {
		$elm = MavueManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeMavue");