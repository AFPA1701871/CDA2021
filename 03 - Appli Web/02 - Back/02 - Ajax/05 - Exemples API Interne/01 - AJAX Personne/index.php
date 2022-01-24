<?php
function ChargerClasse($classe)
{
    if (file_exists("php/Controller/" . $classe . ".Class.php")) {
        require "php/Controller/" . $classe . ".Class.php";
    }

    if (file_exists("php/Model/" . $classe . ".Class.php")) {
        require "php/Model/" . $classe . ".Class.php";
    }

}
spl_autoload_register("ChargerClasse");
function afficherPage($chemin, $page, $titre) {
	require  'php/View/Head.php';
	require  'php/View/Header.php';
	require $chemin . $page.'.php';
	require 'php/View/Footer.php';
}
// on initialise les paramètres du fichier parametre.ini
Parametre::init();
//on active la connexion à la base de données
DbConnect::init();
session_start();


afficherPage ( 'Php/View/', 'Liste', "Personnes" );

