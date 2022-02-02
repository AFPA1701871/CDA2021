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
	$elm = UtilisateursManager::findById($_GET['id']);
} else {
	$elm = new Utilisateurs();
}
echo '<main class="center">';

echo '<form class="GridForm" action="index.php?page=ActionUtilisateurs&mode='.$_GET['mode'].'" method="post"/>';

echo '<div class="caseForm titreForm col-span-form">'.$mode.' un client</div>';
	echo '<div class="noDisplay"><input type="hidden" value="'.$elm->getIdUtilisateur().'" name=IdUtilisateur></div>';
echo '<label for=Nom class="caseForm labelForm">'.texte("Nom").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getNom().'" name=Nom pattern="'.$regex["*"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=Prenom class="caseForm labelForm">'.texte("Prenom").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getPrenom().'" name=Prenom pattern="'.$regex["*"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=AdresseMail class="caseForm labelForm">'.texte("AdresseMail").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getAdresseMail().'" name=AdresseMail pattern="'.$regex["email"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<div class="caseForm col-span-form">Le role sera 1 (Client )</div>';
echo '<div class="caseForm col-span-form">Le mot de passe sera (re)initialisé à NomPrenom</div>';

echo '<div class="caseForm col-span-form">
	<div></div>
	<div><a href="index.php?page=ListeUtilisateurs"><button type="button"><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a></div>
	<div class="flex-0-1"></div>';
	echo ($mode == "Afficher") ? "" : " <div><button type=\"submit\"><i class=\"fas fa-paper-plane\"></i></button></div>";
	echo'<div></div>
	</div>';

echo'</form>';

echo '</main>';