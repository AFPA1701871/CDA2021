<?php
function ChargerClasse($classe)
{
	if (file_exists("PHP/CONTROLLER/CLASSE/" . $classe . ".Class.php")) {
		require "PHP/CONTROLLER/CLASSE/" . $classe . ".Class.php";
	}
	if (file_exists("PHP/MODEL/MANAGER/" . $classe . ".Class.php")) {
		require "PHP/MODEL/MANAGER/" . $classe . ".Class.php";
	}
}
spl_autoload_register("ChargerClasse");

function uri()
{
	$uri = $_SERVER['REQUEST_URI'];
	if (substr($uri, strlen($uri) - 1) == "/") // se termine par /
	{
		$uri .= "index.php?";
	} else if (in_array("?", str_split($uri))) // si l'uri contient deja un ?
	{
		$uri .= "&";
	} else {
		$uri .= "?";
	}
	return $uri;
}

function crypte($mot)
{
	return md5(md5($mot));
}

function texte($codeTexte)
{
	return TexteManager::findByCodes($_SESSION['lang'], $codeTexte);
}

function afficherPage($page)
{
	$chemin = $page[0];
	$nom = $page[1];
	$titre = $page[2];
	$roleRequis = $page[3];;
	$api = $page[4];
	$roleConnecte = isset($_SESSION["utilisateur"]) ? $_SESSION["utilisateur"]->getRole() : 0;
	if ($roleConnecte >= $roleRequis) {
		if ($api) {
			include $chemin . $nom . '.php';
		} else {
			include 'PHP/VIEW/GENERAL/Head.php';
			include 'PHP/VIEW/GENERAL/Header.php';
			include 'PHP/VIEW/GENERAL/Nav.php';
			include $chemin . $nom . '.php'; //Chargement de la page en fonction du chemin et du nom
			include 'PHP/VIEW/GENERAL/Footer.php';
		}
	} else {
		$titre = "Authorisation insuffisante";
		include 'PHP/VIEW/GENERAL/Head.php';
		include 'PHP/VIEW/GENERAL/Header.php';
		include 'PHP/VIEW/FORM/FormConnection.php';
		include 'PHP/VIEW/GENERAL/Nav.php';
	}
}

// A coder pour décoder les informations base de données dans le json
function decode($texte)
{
	return $texte;
}

/* tableau qui stocke les regex les + communes*/
$regex = [
	"alpha" => "[[:alpha:]]",
	"alphaNum" => "[[:alnum:]]",
	"alphaMaj" => "[A-Z]",
	"alphaMin" => "[a-z]",
	"ucFirst" => "[A-Z][a-z]+",
	"email" => "[[:alpha:]]([\.\-_]?[[:alnum:]])+@[[:alpha:]]([\.\-_]?[[:alnum:]])+\.[[:alpha:]]{2,4}",
	"date" => "[0-3]?[0-9](\/|-)(0|1)?[0-9](\/|-)[0-9]{4}",
	"pwd" => "(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}",
	"tel" => "0[0-9]([-/. ][0-9]{2}){4}",
	"postal" => "[0-9]{5}"
];
