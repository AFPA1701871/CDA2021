<?php

// var_dump($_POST);
if ($_POST['motDePasse'] == $_POST['confirmation']) {
    // recherche si le pseudo existe
    $uti = UtilisateursManager::findByPseudo($_POST['pseudo']);
    if ($uti == false) {
        $u = new Utilisateurs($_POST);
        //encodage du mot de passe
        $u->setMotDePasse(crypte($u->getMotDePasse()));
        UtilisateursManager::add($u);
        header("location:index.php?page=connection");
    } else {
        echo '<div class="erreur">le pseudo existe deja</div>';
    }
} else {

    echo '<div class="erreur">la confirmation ne correspond pas au mot de passe</div>';
}
header("refresh:3;url=index.php?page=inscription");
