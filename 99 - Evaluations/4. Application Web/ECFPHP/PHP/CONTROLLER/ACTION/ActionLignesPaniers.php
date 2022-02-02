<?php
$elm = new LignesPaniers($_POST);
/* On cherche si une Panier est en cours, sinon on la crée */
$cmd = PaniersManager::getList(null, ["idClient" => $_SESSION['utilisateur']->getIdUtilisateur()]);
if (!$cmd) {
	var_dump($_SESSION['utilisateur']->getIdUtilisateur());
	PaniersManager::add(new Paniers(["idClient" => $_SESSION['utilisateur']->getIdUtilisateur()]));
	$cmd = PaniersManager::getList(null, ["idClient" => $_SESSION['utilisateur']->getIdUtilisateur()]);
	var_dump($cmd);
}
$elm->setIdPanier($cmd[0]->getIdPanier());

switch ($_GET['mode']) {
	case "Ajouter": {
			$elm->setIdArticle($_GET["id"]);
			$elm->setQuantite(1);
			$elm = LignesPaniersManager::add($elm);
			break;
		}
	case "Modifier": {
			$elm = LignesPaniersManager::update($elm);
			break;
		}
	case "Supprimer": {
			$elm = LignesPaniersManager::delete($elm);
			break;
		}
}

header("location:index.php?page=ListeLignesPaniers");
