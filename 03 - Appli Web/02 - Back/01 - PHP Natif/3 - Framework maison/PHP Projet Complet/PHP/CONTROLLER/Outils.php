<?php
/* Autoload permet de charger toutes les classes necessaires */
function ChargerClasse($classe)
{
    if (file_exists("PHP/CONTROLLER/CLASSE/" . $classe . ".Class.php")) {
        require "PHP/CONTROLLER/CLASSE/" . $classe . ".Class.php";
    }
    if (file_exists("PHP/MODEL/MANAGER/" . $classe . ".Class.php")) {
        require "PHP/MODEL/MANAGER/" . $classe . ".Class.php";
    }
}




/**
 * Méthode qui permet d'affiche une page en fonction de ces paramètres
 * $page tableau contenant 3 valeurs    le chemein d'acces à la page
 *                                      le nom de la page
 *                                      le titre à afficher sur la page
 */
function AfficherPage($page)
{
    $chemin = $page[0];
    $nom = $page[1];
    $titre = $page[2];
    $roleRequis = $page[3];
    $api = $page[4];
    $roleConnecte = isset($_SESSION["utilisateur"])?$_SESSION["utilisateur"]->getRole():0;
    if  ($roleConnecte>= $roleRequis) {
        include 'PHP/VIEW/GENERAL/Head.php';
        include 'PHP/VIEW/GENERAL/Header.php';
        include 'PHP/VIEW/GENERAL/Nav.php';
        include $chemin . $nom . '.php'; //Chargement de la page en fonction du chemin et du nom
        include 'PHP/VIEW/GENERAL/Footer.php';
    } else {
        $titre = "Authorisation insuffisante";
        include 'PHP/VIEW/GENERAL/Head.php';
        include 'PHP/VIEW/GENERAL/Header.php';
        include 'PHP/VIEW/FORM/FormConnection.php';
        include 'PHP/VIEW/GENERAL/Footer.php';
    }
}

/**
 * fonction qui ramène le texte dans la bonne langue
 */
function texte($codetexte)
{
    global $lang; //on appel la variable globale
    return TexteManager::findByCodes($lang, $codetexte);
}

function crypte($mot) //fonction qui crypte le mot de passe
{
    return md5(md5($mot) . strlen($mot));
}
// A coder pour décoder les informations base de données dans le json
function decode($texte)
{
    return $texte;
}
