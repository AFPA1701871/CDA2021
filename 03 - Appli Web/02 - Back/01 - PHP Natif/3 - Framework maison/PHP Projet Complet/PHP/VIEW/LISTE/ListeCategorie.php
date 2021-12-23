<?php
$liste = CategoriesManager::getList();
?>
<div class="demiPage colonne">
    <div id="crudBarreOutil">
        <a class=" crudBtn crudBtnOutil" href='index.php?page=formCategorie&mode=Ajouter'>Ajouter </a>
    </div>
    <div id="crudTableau">

        <div class="crudColonne">Libellé</div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>

        <?php foreach ($liste as $elt) {

            echo '<div class="crudColonne">' . $elt->getLibelleCategorie() . '</div>
                <div></div>
                <a class=" crudBtn crudBtnEditer" href="index.php?page=formCategorie&mode=Editer&id=' . $elt->getIdCategorie() . '">Afficher </a>
                <a class=" crudBtn crudBtnModifier" href="index.php?page=formCategorie&mode=Modifier&id=' . $elt->getIdCategorie() . '">Modifier</a>
                <a class=" crudBtn crudBtnSupprimer" href="index.php?page=formCategorie&mode=Supprimer&id=' . $elt->getIdCategorie() . '">Supprimer</a>
             ';
        } ?>

    </div>

</div>