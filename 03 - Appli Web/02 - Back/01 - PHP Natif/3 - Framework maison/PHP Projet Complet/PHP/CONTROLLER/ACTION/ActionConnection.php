<?php
$uti = UtilisateursManager::findByPseudo($_POST['pseudo']);
if ($uti != false) {
    echo "motBDD " . $uti->getMotDePasse() . "  saisi" . $_POST['motDePasse'] . "crypte   " . crypte($_POST['motDePasse']) . "<br>";
    if (crypte($_POST['motDePasse']) == $uti->getMotDePasse()) {
        echo 'connection reussie';
        $_SESSION['utilisateur'] = $uti;
        header("location:index.php?page=accueil");
    } else {
        header("location:index.php?page=erreur&cible=connection&codeErreur=MdpIncorrect");
    }
} else {
    header("location:index.php?page=erreur&cible=connection&codeErreur=PseudoUnkn");
}
