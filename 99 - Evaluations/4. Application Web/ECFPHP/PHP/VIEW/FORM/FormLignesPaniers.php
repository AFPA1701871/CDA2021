<?php
global $regex;
$mode = $_GET['mode'];
$disabled = " ";
switch ($mode) {
	case "Afficher":
	case "Supprimer":
		$disabled = " disabled ";
		break;
}

if (isset($_GET['id'])) {
	$elm = LignesPaniersManager::findById($_GET['id']);
} else {
	$elm = new LignesPaniers();
}
echo '<main class="center">';

echo '<form class="GridForm" action="index.php?page=ActionLignesPaniers&mode=' . $_GET['mode'] . '" method="post"/>';

echo '<div class="caseForm titreForm col-span-form">Formulaire LignesPaniers</div>';
echo '<div class="noDisplay"><input type="hidden" value="' . $elm->getIdLignePanier() . '" name=IdLignePanier></div>';


echo '<label for=IdArticle class="caseForm labelForm">' . texte("Article") . '</label>';
echo '<div class="caseForm donneeForm">' . creerSelect($elm->getIdArticle(), "Articles", ["LibelleArticle"], $disabled) . '</div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

//echo '<label for=IdPanier class="caseForm labelForm">' . texte("IdPanier") . '</label>';
echo '<input type="hidden" ' . $disabled . 'value="' . $elm->getIdPanier() . '" name=IdPanier pattern="' . $regex["*"] . '">';

echo '<label for=Quantite class="caseForm labelForm">' . texte("Quantite") . '</label>';
echo '<div class="caseForm donneeForm"><input type="number" ' . $disabled . 'value="' . $elm->getQuantite() . '" name=Quantite pattern="' . $regex["*"] . '"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<div class="caseForm col-span-form">
	<div></div>
	<div><a href="index.php?page=ListeLignesPaniers"><button type="button"><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a></div>
	<div class="flex-0-1"></div>';
echo ($mode == "Afficher") ? "" : " <div><button type=\"submit\"><i class=\"fas fa-paper-plane\"></i></button></div>";
echo '<div></div>
	</div>';

echo '</form>';

echo '</main>';
