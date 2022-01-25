<?php

 echo '<main>';

 echo '<div class="flex-0-1"></div>';

 echo '<div>';
 

$objets = ProduitsManager::getList();
//Création du template de la grid
echo '<div class="grid-col-8 gridListe">';

echo '<div class="caseListe grid-columns-span-8">Liste des Produits </div>';
echo '<div class="caseListe grid-columns-span-8">
<div></div>
<div class="caseListe"><a href="index.php?page=FormProduits&mode=Ajouter"><i class="fas fa-plus"></i></a></div>
<div></div>
</div>';

echo '<div class="caseListe">LibelleProduit</div>';
echo '<div class="caseListe">Prix</div>';
echo '<div class="caseListe">DateDePeremption</div>';
echo '<div class="caseListe">IdCategorie</div>';
echo '<div class="caseListe">Image</div>';

//Remplissage de div vide pour la structure de la grid
echo '<div class="caseListe"></div>';
echo '<div class="caseListe"></div>';
echo '<div class="caseListe"></div>';

// Affichage des ennregistrements de la base de données
foreach($objets as $unObjet)
{
echo '<div class="caseListe">'.$unObjet->getLibelleProduit().'</div>';
echo '<div class="caseListe">'.$unObjet->getPrix().'</div>';
echo '<div class="caseListe">'.$unObjet->getDateDePeremption().'</div>';
echo '<div class="caseListe">'.$unObjet->getIdCategorie().'</div>';
echo '<div class="caseListe">'.$unObjet->getImage().'</div>';
echo '<div class="caseListe"> <a href="index.php?page=FormProduits&mode=Afficher&id='.$unObjet->getIdProduit().'"><i class="fas fa-file-contract"></i></a></div>';
                                                    
echo '<div class="caseListe"> <a href="index.php?page=FormProduits&mode=Modifier&id='.$unObjet->getIdProduit().'"><i class="fas fa-pen"></i></a></div>';
                                                    
echo '<div class="caseListe"> <a href="index.php?page=FormProduits&mode=Supprimer&id='.$unObjet->getIdProduit().'"><i class="fas fa-trash-alt"></i></a></div>';
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