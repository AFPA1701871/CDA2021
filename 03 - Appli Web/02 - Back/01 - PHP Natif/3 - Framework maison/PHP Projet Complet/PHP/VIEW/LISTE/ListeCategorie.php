<?php
$liste = CategoriesManager::getList();
?>
<div class="demiPage colonne">
    <div id="crudBarreOutil">
        <a class=" crudBtn crudBtnOutil" href='index.php?page=formCategorie&mode=Ajouter'><?php echo texte('Ajouter') ?></a>
    </div>
    <div id="crudTableau">

        <div class="crudColonne"><?php echo texte('Libelle') ?></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>

        <?php foreach ($liste as $elt) {

            echo '<div class="crudColonne">' . $elt->getLibelleCategorie() . '</div>
                <div></div>
                <a class=" crudBtn crudBtnEditer" href="index.php?page=formCategorie&mode=Editer&id=' . $elt->getIdCategorie() . '">'. texte('Editer') .'</a>
                <a class=" crudBtn crudBtnModifier" href="index.php?page=formCategorie&mode=Modifier&id=' . $elt->getIdCategorie() . '">'. texte('Modifier') .'</a>
                <a class=" crudBtn crudBtnSupprimer" href="index.php?page=formCategorie&mode=Supprimer&id=' . $elt->getIdCategorie() . '">'. texte('Supprimer') .'</a>
             ';
        } ?>

    </div>

</div>