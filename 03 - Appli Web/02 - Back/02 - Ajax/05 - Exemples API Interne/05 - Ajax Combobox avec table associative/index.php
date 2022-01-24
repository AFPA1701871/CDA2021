<?php

include "./PHP/outils.php";
spl_autoload_register("autoload");

Parametres::init();
DbConnect::init();
session_start();  // initialise la variable de Session

$routes = [
    "accueil"=>["PHP/VIEW/","accueil", "Oeuvres",false,[0],false],
    "APIAuteurs"=>["PHP/MODEL/API/","APIAuteurs", "APIAuteurs",false,[0],true],
    "APICreations"=>["PHP/MODEL/API/","APICreations", "APICreations",false,[0],true],
    "APIOeuvres"=>["PHP/MODEL/API/","APIOeuvres", "APIOeuvres",false,[0],true],
    "APIAuteursOeuvres"=>["PHP/MODEL/API/","APIAuteursOeuvres", "APIAuteursOeuvres",false,[0],true]
];

if (isset($_GET['page']))
{
    if (isset($routes[$_GET['page']]))
    {
        AfficherPage($routes[$_GET['page']]);
    }
    else{
        AfficherPage($routes["accueil"]);
    }
}
else
{
    AfficherPage($routes["accueil"]);
}