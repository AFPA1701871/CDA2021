<?php

 echo '<main>';

 echo '<div class="flex-0-1"></div>';

 echo '<div>';
 

$objets = ArticlesManager::getList();
//Création du template de la grid
echo '<div class="grid-col-8 gridListe">';

echo '<div class="caseListe grid-columns-span-8 titre" >Liste des Articles </div>';
echo '<div class="caseListe grid-columns-span-8">
<div></div>
<div class="caseListe"><a href="index.php?page=FormArticles&mode=Ajouter"><i class="fas fa-plus"></i></a></div>
<div></div>
</div>';

echo '<div class="caseListe"></div>';
echo '<div class="caseListe gridLabel">'.texte("Libelle").'</div>';
echo '<div class="caseListe gridLabel">'.texte("Description").'</div>';
echo '<div class="caseListe gridLabel">'.texte("Prix").'</div>';
echo '<div class="caseListe gridLabel">'.texte("Type d'article").'</div>';

//Remplissage de div vide pour la structure de la grid
echo '<div class="caseListe"></div>';
echo '<div class="caseListe"></div>';
echo '<div class="caseListe"></div>';

// Affichage des ennregistrements de la base de données
foreach($objets as $unObjet)
{
	echo '<div class="caseListe color5 left gridCase"><img src="./IMG/'.$unObjet->getPhotos().'"/></div>';
	echo '<div class="caseListe left  color5 gridCase">'.$unObjet->getLibelleArticle().'</div>';
echo '<div class="caseListe left  color5 gridCase">'.$unObjet->getDescriptionArticle().'</div>';
echo '<div class="caseListe  color5 gridCase">'.$unObjet->getPrixArticle().'</div>';
echo '<div class="caseListe left color5  gridCase">'.TypesArticlesManager::findById($unObjet->getIdTypeArticle())->ToString().'</div>';
echo '<div class="caseListe"> <a href="index.php?page=FormArticles&mode=Afficher&id='.$unObjet->getIdArticle().'"><i class="fas fa-file-contract"></i></a></div>';
                                                    
echo '<div class="caseListe"> <a href="index.php?page=FormArticles&mode=Modifier&id='.$unObjet->getIdArticle().'"><i class="fas fa-pen"></i></a></div>';
                                                    
echo '<div class="caseListe"> <a href="index.php?page=FormArticles&mode=Supprimer&id='.$unObjet->getIdArticle().'"><i class="fas fa-trash-alt"></i></a></div>';
}
//Derniere ligne du tableau (bouton retour)
echo '<div class="caseListe grid-columns-span-8">
	<div></div>
	<a href="index.php?page=Accueil"><button><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a>
	<div></div>
</div>';

echo'</div>'; //Grid
echo'</div>'; //Div
echo '<div class="flex-0-1"></div>';
echo '</main>';