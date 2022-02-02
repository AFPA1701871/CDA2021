<?php

echo '<main>';

echo '<div class="flex-0-1"></div>';

echo '<div>';


$objets = PaniersManager::getList();
if (!$objets) echo '<div class="caseListe titreListe center">Pas de paniers actuellement disponibles </div>';
else {
	//Création du template de la grid
	echo '<div class="grid-col-2 gridListe">';

	echo '<div class="caseListe titreListe grid-columns-span-2">Information sur les Paniers </div>';
	echo '<div class="caseListe grid-columns-span-2">
<div></div>
<div></div>
</div>';

	echo '<div class="caseListe labelListe">Client</div>';
	echo '<div class="caseListe labelListe">Nombre d\'articles</div>';


	// Affichage des ennregistrements de la base de données
	foreach ($objets as $unObjet) {
		$nbArticles = 0;
		$lesLignes = LignesPaniersManager::getList(null, ["idPanier" => $unObjet->getIdPanier()], "idPanier");
		foreach ($lesLignes as $value) {
			$nbArticles += $value->getQuantite();
		}
		echo '<div class="caseListe donneeListe">' . UtilisateursManager::findById($unObjet->getIdClient())->toString() . '</div>';
		echo '<div class="caseListe donneeListe">' . $nbArticles . '</div>';
	}
	//Derniere ligne du tableau (bouton retour)
	echo '<div class="caseListe grid-columns-span-2">
	<div></div>
	<a href="index.php?page=Accueil"><button><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a>
	<div></div>
</div>';

	echo '</div>'; //Grid
	echo '</div>'; //Div
	echo '<div class="flex-0-1">';
}
echo '</div></main>';
