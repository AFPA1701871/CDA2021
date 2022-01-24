<?php

/* Autoload permet de charger toutes les classes necessaires */
function ChargerClasse($classe)
{
    if (file_exists("PHP/CONTROLLER/" . $classe . ".Class.php")) {
        require "PHP/CONTROLLER/" . $classe . ".Class.php";
    }
    if (file_exists("PHP/MODEL/" . $classe . ".Class.php")) {
        require "PHP/MODEL/" . $classe . ".Class.php";
    }
}
spl_autoload_register("ChargerClasse");

/**
 * fonctions pour crypter le mot de passe
 * 
 */
function cryptage($mot)
{

    return md5(md5(md5($mot).strlen($mot))."m6");

}

/**
 * Méthode qui permet d'affichre une page en fonction de ces paramètres
 * $page tableau contenant 3 valeurs    le chemein d'acces à la page
 *                                      le nom de la page
 *                                      le titre à afficher sur la page
 */
function AfficherPage($page)
{
    $chemin = $page[0];
    $nom = $page[1];
    $titre = $page[2];
    if ($page[3]) //c'est un appel API
    {
        include $chemin . $nom . '.php';
    }
    else
    {
        include 'PHP/VIEW/Head.php';
        include 'PHP/VIEW/Header.php';
        // include 'PHP/VIEW/Nav.php';
        include $chemin . $nom . '.php'; //Chargement de la page en fonction du chemin et du nom
        include 'PHP/VIEW/Footer.php';
    }
}