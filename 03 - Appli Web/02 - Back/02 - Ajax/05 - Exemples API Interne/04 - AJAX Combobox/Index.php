<?PHP
include 'PHP/Outils.php';

//on recupere les paramètres de l'application
Parametre::init();
//on active la connexion à la base de données
DbConnect::init();
session_start(); // initialise la variable de Session

/***************************GESTION DES LANGUES ******************/
// on recupere la langue de l'URL
if (isset($_GET['lang'])) {
    $_SESSION['lang'] = $_GET['lang'];
}

//on prend la langue de la session sinon FR par défaut
$lang = isset($_SESSION['lang']) ? $_SESSION['lang'] : 'FR';

/**
 * fonction qui ramène le texte dans la bonne langue
 */
function texte($codetexte)
{
    global $lang; //on appel la variable globale
    return TexteManager::findByCodes($lang, $codetexte);
}
/************************ FIN GESTION DES LANGUES ******************/

/* création d'un tableau de redirection, en fonction du code, on choisit la page à afficher */
$routes = [
    "default" => ["PHP/VIEW/", "Accueil", "Accueil",false],
    "accueil" => ["PHP/VIEW/", "Accueil", "Accueil",false],
    "listeAPI" => ["PHP/MODEL/API/", "ListeAPI", "Accueil", true]
];

if (isset($_GET["codePage"])) {

    $code = $_GET["codePage"];

    //Si cette route existe dans le tableau des routes
    if (isset($routes[$code])) {
        //Afficher la page correspondante
        AfficherPage($routes[$code]);
    } else {
        //Sinon afficher la page par defaut
        AfficherPage($routes["default"]);
    }

} else {
    //Sinon afficher la page par defaut
    AfficherPage($routes["default"]);

}
