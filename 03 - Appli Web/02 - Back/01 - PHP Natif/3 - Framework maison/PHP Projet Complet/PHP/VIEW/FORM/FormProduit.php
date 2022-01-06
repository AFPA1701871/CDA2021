<?php
$defaultMode =  $_GET['mode'];
$modeTraduit = texte($defaultMode);
echo '<div class="demiPage colonne">';
echo '<div id="DivSousTitre" >';

$disabled = " ";
switch ($defaultMode) {
    case "Editer":
    case "Supprimer":
        $disabled = " disabled ";
        break;
}

echo '<h5>' . $modeTraduit . texte('titreCrud') .'</h5></div>
<form id="formulaire" method="post" action="index.php?page=actionProduit&mode=' . $defaultMode . '">';
if (isset($_GET['id'])) {
    $prod = ProduitsManager::findById($_GET['id']);
    $idCateg = $prod->getIdCategorie();
} else {
    $prod = new Produits();
    $idCateg = null;
}

$listeCateg = CategoriesManager::getList();

// on crée les inputs du formulaire
// il faut que les name des input correspondent aux attributs de la class
// si on a les informations (cas Editer, Modifier, supp) on les mets à jour
echo '  <input type="hidden" name="idProduit" value="' . $prod->getIdProduit() . '">';
echo '  <label>'. texte('Libelle').' :</label>
        <input type="text" name="libelleProduit" value="' . $prod->getLibelleProduit() . '"' . $disabled . '>';
echo '  <label>'. texte('Prix').' :</label>
        <input type="number" name="prix" value="' . $prod->getPrix() . '"' . $disabled . '>';
echo '  <label>'. texte('DatePeremption').' :</label>
        <input type="date" name="dateDePeremption" value="' . $prod->getDateDePeremption() . '"' . $disabled . '>';
echo '  <label>'. texte('Categories').' :</label>
        <select name="idCategorie" '.$disabled.'>';
foreach ($listeCateg as $uneCategorie) {
    $sel = "";
    if ($uneCategorie->getIdCategorie() == $idCateg) {
        $sel = "selected";
    }

    echo '<option value="' . $uneCategorie->getIdCategorie() . '" ' . $sel . ' >' . $uneCategorie->getLibelleCategorie() . '</option>';
}

echo '
    </select>
    </div>';

echo '<div class="ligneDetail"><input type="submit" value="' . $modeTraduit . '" class=" crudBtn crudBtn' . $defaultMode . '"/>';
echo '
<a href="index.php?page=listeProduit" class=" crudBtn crudBtnRetour">'. texte('Annuler') .'</a>
</div>
</div>
</form>';