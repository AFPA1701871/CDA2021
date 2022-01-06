<?php
$defaultMode =  $_GET['mode'];
$modeTraduit = texte($defaultMode); // On traduit le mode pour la gestion des affichages
echo '<div class="demiPage colonne">';
echo '<div id="DivSousTitre">';


$disabled = " ";
switch ($defaultMode) {
    case "Editer":
    case "Supprimer":
        $disabled = " disabled ";
        break;
}
echo '  <h5>'.$modeTraduit . texte('titreCrud') .'</h5></div>
        <form id="formulaire" method="post" action="index.php?page=actionCategorie&mode='.$defaultMode.'">';

if (isset($_GET['id'])) {
    $categ = CategoriesManager::findById($_GET['id']);
}
else{
    $categ = new Categories();
}

echo '  <input type="hidden" name="idCategorie" value="' . $categ->getIdCategorie() . '">';
echo '  <label>'. texte('Libelle').' :</label>
        <input type="text" name="libelleCategorie" value="' . $categ->getLibelleCategorie() . '"' .$disabled.'>';
echo '<input type="submit" value="'.$modeTraduit.'" class=" crudBtn crudBtn'.$defaultMode.'"/>';

echo '<a href="index.php?page=listeCategorie" class=" crudBtn crudBtnRetour">'. texte('Annuler') .'</a>
</form>';