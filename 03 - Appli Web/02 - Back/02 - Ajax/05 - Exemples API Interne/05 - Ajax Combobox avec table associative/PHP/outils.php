<?php

function autoload($classe)
{
    if (file_exists("PHP/CONTROLLER/" . $classe . ".Class.php")) {
        require "PHP/CONTROLLER/" . $classe . ".Class.php";
    }

    if (file_exists("PHP/MODEL/" . $classe . ".Class.php")) {
        require "PHP/MODEL/" . $classe . ".Class.php";
    }
}

function AfficherPage($page)
{
    $chemin = $page[0];
    $nom = $page[1];
    $titre = $page[2];
    $connexionNecessaire = $page[3];
    $roleNecessaire = $page[4];
    if ($page[5]) { //Si c'est une API
        require $chemin . $nom . '.php';
    } else {
        require "./PHP/VIEW/head.php";
        require "./PHP/VIEW/header.php";
        if (($connexionNecessaire && !isset($_SESSION['utilisateur']))
            //qqn sans connexion alors qu'il faut être connecté
             ||
            //qqn avec une connexion mais pas le bon rôle
            (isset($_SESSION['utilisateur']) && !in_array($_SESSION['utilisateur']->getRole(), $roleNecessaire))) {
            $chemin = "PHP/VIEW/PAGES/";
            $nom = "accueil";
        }
        require $chemin . $nom . '.php'; //Chargement de la page en fonction du chemin et du nom
        require "./PHP/VIEW/footer.php";
    }
}

function crypte($mot) //fonction qui crypte le mot de passe

{
    //à crypter
    return $mot;
}
