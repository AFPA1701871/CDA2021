<?php

require("PHP/CONTROLLER/Outils.php");

Parametres::init();

DbConnect::init();

session_start();

$routes=[
	"default"=>["PHP/VIEW/","ListeMenus","Liste de menus"],
	"ListeMenus"=>["PHP/VIEW/","ListeMenus","Liste des menus"],
	"ListePlats"=>["PHP/VIEW/","ListePlats","Liste de plats"],
	"FormMenus"=>["PHP/VIEW/","FormMenus","Détail du menu"],
	"FormPlats"=>["PHP/VIEW/","FormPlats","Détail du plat"],
	"ActionMenus"=>["PHP/CONTROLLER/","ActionMenus","Action  menus"],
	"ActionPlats"=>["PHP/CONTROLLER/","ActionPlats","Action  plats"],
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