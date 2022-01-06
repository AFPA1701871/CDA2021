<?php
$liste = ProduitsManager::getList();
?>
<div class="demiPage colonne">
    <div id="crudBarreOutil">
        <a class=" crudBtn crudBtnOutil" href='index.php?page=formProduit&mode=Ajouter'><?php echo texte('Ajouter') ?></a>
    </div>
    <div id="crudTableau2Col">

    <div class="crudColonne"><?php echo texte('Libelle') ?></div>
    <div class="crudColonne"><?php echo texte('Prix') ?></div>
       <div></div>
        <div></div>
        <div></div>
        <div></div>
        <?php foreach ($liste as $elt) {
            echo '<div class="crudColonne">' . $elt->getLibelleProduit() . '</div>
            <div class="crudColonne">' . $elt->getPrix() . '</div>
            <div></div>    
            <a class=" crudBtn crudBtnEditer" href="index.php?page=formProduit&mode=Editer&id='. $elt->getIdProduit().'">'. texte('Editer') .'</a>
                <a class=" crudBtn crudBtnModifier" href="index.php?page=formProduit&mode=Modifier&id='.$elt->getIdProduit().'">'. texte('Modifier') .'</a>
                <a class=" crudBtn crudBtnSupprimer" href="index.php?page=formProduit&mode=Supprimer&id='. $elt->getIdProduit().'">'. texte('Supprimer') .'</a>
            ';
        } ?>

    </div>
</div>