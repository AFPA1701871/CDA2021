<?php
    
$uti =  UtilisateursManager::getList(null, ['adresseMail' => $_POST['adresseMail']]);
if ($uti != null) {
    if ($uti[0]->getMotDePasse() == crypte($_POST['motDePasse'])) {       
        echo 'connection reussie';
        $_SESSION['utilisateur'] = $uti[0];
        header("location:index.php?page=Accueil");
    } else {
        header("location:index.php?page=Default");
    }
} else {
    header("location:index.php?page=Default");
}