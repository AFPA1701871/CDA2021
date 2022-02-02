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
	$elm = ArticlesManager::findById($_GET['id']);
} else {
	$elm = new Articles();
}
echo '<main class="center">';

echo '<form class="GridForm" action="index.php?page=ActionArticles&mode='.$_GET['mode'].'" method="post" enctype="multipart/form-data"/>';

echo '<div class="caseForm col-span-form titreForm">'.$mode.' un article</div>';
if ($mode != "Ajouter") {
	echo '<div class="noDisplay"><input type="hidden" value="'.$elm->getIdArticle().'" name=IdArticle></div>';
};
echo '<label for=LibelleArticle class="caseForm labelForm">'.texte("LibelleArticle").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getLibelleArticle().'" name=LibelleArticle pattern="'.$regex["*"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=DescriptionArticle class="caseForm labelForm">'.texte("DescriptionArticle").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getDescriptionArticle().'" name=DescriptionArticle pattern="'.$regex["*"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=PrixArticle class="caseForm labelForm">'.texte("PrixArticle").'</label>';
echo '<div class="caseForm donneeForm"><input type="text" '.$disabled .'value="'.$elm->getPrixArticle().'" name=PrixArticle pattern="'.$regex["num"].'"></div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=IdTypeArticle class="caseForm labelForm">'.texte("IdTypeArticle").'</label>';
echo '<div class="caseForm donneeForm">'.creerSelect($elm->getIdTypeArticle(),"TypesArticles",["LibelleTypeArticle"],$disabled).'</div>';
echo '<div class="caseForm infoForm"><i class="fas fa-question-circle"></i></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<label for=Photos class="caseForm labelForm">'.texte("Photos").'</label>';
echo '<div class="caseForm donneeForm"><img src="./IMG/'.$elm->getPhotos().'" /></div>';
echo '<div class="caseForm">
				<input type="hidden" name="AnciennePhotos" value="'.$elm->getPhotos().'">
				<input type="file" name="Photos" '.$disabled.'/></div>';
echo '<div class="caseForm checkForm"><i class="fas fa-check-circle"></i></div>';

echo '<div class="caseForm col-span-form">
	<div></div>
	<div><a href="index.php?page=ListeArticles"><button type="button"><i class="fas fa-sign-out-alt fa-rotate-180"></i></button></a></div>
	<div class="flex-0-1"></div>';
	echo ($mode == "Afficher") ? "" : " <div><button type=\"submit\"><i class=\"fas fa-paper-plane\"></i></button></div>";
	echo'<div></div>
	</div>';

echo'</form>';

echo '</main>';