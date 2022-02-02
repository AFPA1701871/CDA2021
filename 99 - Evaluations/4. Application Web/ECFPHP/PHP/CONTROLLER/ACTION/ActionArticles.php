<?php
$elm = new Articles($_POST);
switch ($_GET['mode']) {
	case "Ajouter": {
		$elm->setPhotos(chargerImage());
		$elm = ArticlesManager::add($elm);
		break;
	}
	case "Modifier": {
		if (isset($_POST["modifImage"]))
		{   /* suppression de l'ancienne image*/
			unlink("IMG/" . $_POST['AnciennePhotos']);
			/* on charge la nouvelle image */
			$elm->setPhotos(chargerImage());
		}
		else $elm->setPhotos($_POST['AnciennePhotos']);
		$elm = ArticlesManager::update($elm);
		break;
	}
	case "Supprimer": {
		/*suppression de l'image */
		unlink("IMG/" . $elm->getPhotos());
		$elm = ArticlesManager::delete($elm);
		break;
	}
}

header("location:index.php?page=ListeArticles");

function chargerImage()
{
    if (is_uploaded_file($_FILES["Photos"]["tmp_name"]))
    {
        $leNom = uniqid('jpg_') . '.jpg';
        move_uploaded_file($_FILES['Photos']['tmp_name'], 'IMG/' . $leNom);
    }
    return $leNom;
}