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
        header("location:index.php?page=erreur&cible=inscription&codeErreur=DoublePseudo");
    }
} else {
    header("location:index.php?page=erreur&cible=inscription&codeErreur=Confirm");
}
