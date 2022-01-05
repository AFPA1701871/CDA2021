<?php
$erreur = false;
 //var_dump($_POST);
$p = new Categories($_POST);
 // var_dump($p);
switch ($_GET['mode']) {
    case "Ajouter": {
            CategoriesManager::add($p);
            break;
        }
    case "Modifier": {
            CategoriesManager::update($p);
            break;
        }
    case "Supprimer": {
            $listeProduit = ProduitsManager::getListByCategorie($p->getIdCategorie());
            /**** Technique informative */
            //    if (count($listeProduit)>0)
            //    {
            //        echo 'Il reste des produits';
            //        $erreur=true;

            //    }
            //    else{
            //     CategoriesManager::delete($p);
            //    }

            /**** Technique de suppression en cascade */
            foreach ($listeProduit as $unProduit) {
                ProduitsManager::delete($unProduit);
            }
            CategoriesManager::delete($p);
            break;
        }
}

if (!$erreur) {  // si pas d'erreur
    header("location:index.php?page=listeCategorie");   //redirection directe
} else {
    header("refresh:3;url=index.php?page=listeCategorie");    // on attend 3 secondes avant la redirection
}
