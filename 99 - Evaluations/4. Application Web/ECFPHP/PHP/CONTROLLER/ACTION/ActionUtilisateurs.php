<?php
$elm = new Utilisateurs($_POST);
$elm->setRole(1);
$elm->setMotDePasse(crypte($elm->getNom().$elm->getPrenom()));
switch ($_GET['mode']) {
	case "Ajouter": {
		$elm = UtilisateursManager::add($elm);
		break;
	}
	case "Modifier": {
		$elm = UtilisateursManager::update($elm);
		break;
	}
	case "Supprimer": {
		$elm = UtilisateursManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeUtilisateurs");