<?php
$pasDErreur = true;
//var_dump($_POST);
$p = new Categories($_POST);
// var_dump($p);
switch ($_GET['mode']) {
    case "Ajouter": {
            $pasDErreur = CategoriesManager::add($p);
            break;
        }
    case "Modifier": {
            $pasDErreur = CategoriesManager::update($p);
            break;
        }
    case "Supprimer": {
            $listeProduit = ProduitsManager::getListByCategorie($p->getIdCategorie());
            /**** Technique informative */
            //    if (count($listeProduit)>0)
            //    {
            //        echo 'Il reste des produits';
            //        $pasDErreur=false;

            //    }
            //    else{
            //     CategoriesManager::delete($p);
            //    }

            /**** Technique de suppression en cascade */
            foreach ($listeProduit as $unProduit) {
                ProduitsManager::delete($unProduit);
            }
            $pasDErreur = CategoriesManager::delete($p);
            break;
        }
}

if ($pasDErreur) {  // si pas d'erreur
    header("location:index.php?page=listeCategorie");   //redirection directe
} else {
    header("location:index.php?page=erreur&cible=listeCategorie&codeErreur=erreur" . $_GET['mode']);    // on redirigege vers la page d'erreur
}
