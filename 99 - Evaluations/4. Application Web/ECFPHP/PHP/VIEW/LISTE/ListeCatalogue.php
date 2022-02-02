<?php

echo '<main>';

echo '<div class="flex-0-1"></div>';

echo '<div>';


$objets = ArticlesManager::getList(null, null, "idTypeArticle");
//Création du template de la grid
echo '<div class="grid-col-4 gridListe">';

echo '<div class="caseListe grid-columns-span-4 titreListe" >Catalogue</div>';
echo '<div class="caseListe grid-columns-span-4">
<div></div>

<div></div>
</div>';

//ouverture du type 
$idTypeActuel = $objets[0]->getIdTypeArticle();
echo '<div class="caseListe titre">Type : ' . TypesArticlesManager::findById($idTypeActuel)->getLibelleTypeArticle() . '</div>';
echo '<div class="caseListe grid-columns-span-4">';
// Affichage des ennregistrements de la base de données
foreach ($objets as $unObjet) {
	/* gestion du changement de type */
	if ($unObjet->getIdTypeArticle() != $idTypeActuel) {

		$idTypeActuel = $unObjet->getIdTypeArticle();
		// fermeture du type et ouverture du nouveau
		echo '</div>';
		//ouverture du type 
		echo '<div class="caseListe titre">Type : ' . TypesArticlesManager::findById($idTypeActuel)->getLibelleTypeArticle() . '</div>';
		echo '<div class="caseListe grid-columns-span-4">';
	}
	echo '<div class="colonne">';
	echo '<div class="caseListe color5 left gridCase"><img src="./IMG/' . $unObjet->getPhotos() . '" /></div>';
	echo '<div>
				<div class="colonne">
					<div class="caseListe left titre color5 gridCase">' . $unObjet->getLibelleArticle() . '</div>';
	echo '			<div class="caseListe left  color5 gridCase">' . $unObjet->getDescriptionArticle() . '</div>';
	echo '		</div>';
	if (isset($_SESSION['utilisateur']) && $_SESSION['utilisateur']->getRole() == 1)
		echo '	<div class="caseListe"> <a href="index.php?page=ActionLignesPaniers&mode=Ajouter&id=' . $unObjet->getIdArticle() . '"><i class="fas fa-cart-plus"></i></a></div>';
	echo '</div>
	</div>';
}
// fermeture du type
echo '</div>';

//Derniere ligne du tableau (bouton retour)
echo '<div class="caseListe grid-columns-span-4">
	<div></div>
	<a href="index.php?page=Accueil"><button><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a>
	<div></div>
</div>';

echo '</div>'; //Grid
echo '</div>'; //Div
echo '<div class="flex-0-1"></div>';
echo '</main>';
