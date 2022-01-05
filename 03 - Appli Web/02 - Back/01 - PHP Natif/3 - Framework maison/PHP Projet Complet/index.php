<?PHP

include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");

//on active la connexion à la base de données
Parametre::init();
DbConnect::init();

session_start(); // initialise la variable de Session

/***************************GESTION DES LANGUES ******************/
// on recupere la langue de l'URL
if (isset($_GET['lang'])) {
    // tester si la langue est gérée
    $_SESSION['lang'] = $_GET['lang'];
}

//on prend la langue de la session sinon FR par défaut
$lang = isset($_SESSION['lang']) ? $_SESSION['lang'] : 'FR';


/* création d'un tableau de redirection, en fonction du page, on choisit la page à afficher */
// Dossier / Nom du fichier / Titre de la page / Autorisation requise / Api ou pas 
$routes = [
    "default" => ["PHP/VIEW/FORM/", "FormConnection", "Identification", 0, false],

    "inscription" => ["PHP/VIEW/FORM/", "FormInscription", "Identification", 0, false],
    "actionInscription" => ["PHP/CONTROLLER/ACTION/", "actionInscription", "Erreur", 0, false],
    "connection" => ["PHP/VIEW/FORM/", "FormConnection", "Identification", 0, false],
    "actionConnection" => ["PHP/CONTROLLER/ACTION/", "actionConnection", "Erreur", 0, false],
    "accueil" => ["PHP/VIEW/GENERAL/", "Accueil", "Accueil", 0, false],
    "deconnection" => ["PHP/CONTROLLER/ACTION/", "Actiondeconnection", "Erreur", 0, false],

    "listeProduit" => ["PHP/VIEW/LISTE/", "ListeProduit", "Liste de produits", 1, false],
    "formProduit" => ["PHP/VIEW/FORM/", "FormProduit", "Détail du produit", 1, false],
    "actionProduit" => ["PHP/CONTROLLER/ACTION/", "ActionProduit", "Mise à jour du produit", 1, false],

    "listeCategorie" => ["PHP/VIEW/LISTE/", "ListeCategorie", "Liste des Catégories", 2, false],
    "formCategorie" => ["PHP/VIEW/FORM/", "FormCategorie", "Gestion des catégories", 2, false],
    "actionCategorie" => ["PHP/CONTROLLER/ACTION/", "ActionCategorie", "Mise à jour du produit", 2, false]
];

if (isset($_GET["page"])) {
    $page = $_GET["page"];
    //Si cette route existe dans le tableau des routes
    if (isset($routes[$page])) {
        //Afficher la page correspondante
        AfficherPage($routes[$page]);
    } else {
        //Sinon afficher la page par defaut
        AfficherPage($routes["default"]);
    }
} else {
    //Sinon afficher la page par defaut
    AfficherPage($routes["default"]);
}
