<?php

$routes=[
	"default"=>["PHP/","Formulaire","XSS CROSS Side"],
	"Formulaire"=>["PHP/","Formulaire","XSS CROSS Side"],
	"Reponse"=>["PHP/","Reponse","XSS CROSS Side"],
	
];

if(isset($_GET["page"]))
{

	$page=$_GET["page"];

	if(isset($routes[$page]))
	{
		AfficherPage($routes[$page]);
	}
	else
	{
		AfficherPage($routes["default"]);
	}
}
else
{
	AfficherPage($routes["default"]);
}

function afficherPage($page)
{
	$chemin = $page[0];
	$nom = $page[1];
	$titre = $page[2];

	include $chemin . $nom . '.php';
}
