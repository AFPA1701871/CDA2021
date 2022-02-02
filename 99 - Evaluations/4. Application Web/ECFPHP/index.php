<?php

include "./PHP/CONTROLLER/Outils.php";

spl_autoload_register("ChargerClasse");

Parametres::init();

DbConnect::init();

session_start();

/******Les langues******/
/***On récupère la langue***/
if (isset($_GET['lang']) && TextesManager::checkIfLangExist($_GET['lang'])) {
	// tester si la langue est gérée
	$_SESSION['lang'] = $_GET['lang'];
} else if (isset($_COOKIE['lang'])) {
	$_SESSION['lang'] = $_COOKIE['lang'];
} else {
	$_SESSION['lang'] = 'FR';
}
//Crée un cookie lang sur la machine de l'utilisateur d'une durée de 10h.
setcookie("lang", $_SESSION['lang'], time() + 36000, '/');
/******Fin des langues******/

$routes = [
	"Default" => ["PHP/VIEW/FORM/", "FormConnexion", "Connexion", 0, false],
	"Inscription" => ["PHP/VIEW/FORM/", "FormInscription", "Inscription", 0, false],
	"Accueil" => ["PHP/VIEW/GENERAL/", "Accueil", "Accueil", 0, false],
	"Erreur" => ["PHP/VIEW/GENERAL/", "Erreur", "titreErreur", 0, false],

	"ActionConnexion" => ["PHP/CONTROLLER/ACTION/", "ActionConnexion", "Action de la connexion", 0, false],
	"ActionInscription" => ["PHP/CONTROLLER/ACTION/", "ActionInscription", "Action de l'inscription", 0, false],
	"ActionDeconnexion" => ["PHP/CONTROLLER/ACTION/", "ActionDeconnexion", "Action de deconnexion", 0, false],

	"ListeMailAPI" => ["PHP/MODEL/API/", "ListeMailAPI", "ListeMailAPI", 0, true],

	"Catalogue" => ["PHP/VIEW/LISTE/", "ListeCatalogue", "Catalogue", 1, false],
	"FormArticlesClients" => ["PHP/VIEW/FORM/", "FormArticlesClients", "Formulaire Articles", 1, false],

	"ListeArticles" => ["PHP/VIEW/LISTE/", "ListeArticles", "Liste Articles", 2, false],
	"FormArticles" => ["PHP/VIEW/FORM/", "FormArticles", "Formulaire Articles", 2, false],
	"ActionArticles" => ["PHP/CONTROLLER/ACTION/", "ActionArticles", "Action Articles", 2, false],

	"ListePaniers" => ["PHP/VIEW/LISTE/", "ListePaniers", "Liste Paniers", 2, false],
	"FormPaniers" => ["PHP/VIEW/FORM/", "FormPaniers", "Formulaire Paniers", 2, false],
	"ActionPaniers" => ["PHP/CONTROLLER/ACTION/", "ActionPaniers", "Action Paniers", 2, false],

	"ListeLignesPaniers" => ["PHP/VIEW/LISTE/", "ListeLignesPaniers", "Liste Lignes de Paniers", 1, false],
	"FormLignesPaniers" => ["PHP/VIEW/FORM/", "FormLignesPaniers", "Formulaire Lignes de Paniers", 1, false],
	"ActionLignesPaniers" => ["PHP/CONTROLLER/ACTION/", "ActionLignesPaniers", "Action LignesPaniers", 1, false],

	"ListeTypesArticles" => ["PHP/VIEW/LISTE/", "ListeTypesArticles", "Liste Types d'Articles", 2, false],
	"FormTypesArticles" => ["PHP/VIEW/FORM/", "FormTypesArticles", "Formulaire Types d'Articles", 2, false],
	"ActionTypesArticles" => ["PHP/CONTROLLER/ACTION/", "ActionTypesArticles", "Action TypesArticles", 2, false],

	"ListeUtilisateurs" => ["PHP/VIEW/LISTE/", "ListeUtilisateurs", "Liste Clients", 2, false],
	"FormUtilisateurs" => ["PHP/VIEW/FORM/", "FormUtilisateurs", "Formulaire Clients", 2, false],
	"ActionUtilisateurs" => ["PHP/CONTROLLER/ACTION/", "ActionUtilisateurs", "Action Utilisateurs", 2, false],

];

if (isset($_GET["page"])) {

	$page = $_GET["page"];

	if (isset($routes[$page])) {
		AfficherPage($routes[$page]);
	} else {
		AfficherPage($routes["Default"]);
	}
} else {
	AfficherPage($routes["Default"]);
}
