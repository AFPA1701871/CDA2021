<?php
$listeRegion = RegionsManager::getList(false);
?>
<select>
    <option value="defaut" selected>--Choisissez votre region--</option>
<?php
        foreach($listeRegion as $elt)
        {
            echo '<option value="'.$elt->getIdRegion().'">'.$elt->getLibelleRegion().'</option>';
        }

?>
</select>

<div class="listeDep colonne">

<div class="unDept"></div>
</div>