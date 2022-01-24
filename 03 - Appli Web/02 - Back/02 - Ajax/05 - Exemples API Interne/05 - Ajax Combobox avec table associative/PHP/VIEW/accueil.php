<?php
$listeAuteurs = AuteursManager::getList(false);
?>
<div class="padd1"></div>
<div>
    <div class="flex06"></div>
    <div class="column">
        <select>
            <option value="defaut" selected>--Choisissez votre Auteur--</option>
            <?php
                foreach ($listeAuteurs as $elt) {
                    echo '<option value="' . $elt->getIdAuteur() . '">' . $elt->getNomAuteur() . " " . $elt->getPrenomAuteur() . '</option>';
                }   
            ?>
        </select>
        <div class="listeOeuvre column"></div>
    </div>
    <div class="flex06"></div>
   
</div>

