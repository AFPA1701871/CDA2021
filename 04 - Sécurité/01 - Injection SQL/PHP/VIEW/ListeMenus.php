
<?php
$menus = MenusManager::getList();
echo '<section class="colonne">
        <div class="espaceHor"></div>
        <div>
            <div class="centre"><a href="index.php?page=FormMenus&mode=ajouter"><button class="bouton"><i
                            class="fas fa-plus-circle"></i> &nbsp Ajouter</button></a></div>

            <div class="centre"><a href="index.php?page=ListePlats"><button class="bouton"><i class="far fa-arrow-alt-circle-left"></i> &nbsp Gérer les plats</button></a></div></div>
        <div class="espaceHor"></div>';
echo '  <div class="info colonne">
            <div class=" titre centre" >Menus</div>
        </div>
        <div class="espaceHor"></div>';

foreach ($menus as $obj) {
     echo '<div class="info ">
                <div class="case ">
                <div class="double">' . $obj->getLibelleMenu() . '</div>
                </div>

                <div class="triple centerItem">
                    <div class="mini"></div>
                    <a href="index.php?page=FormMenus&mode=details&id=' . $obj->getIdMenu() . '"><button class="bouton"><i class="fas fa-info-circle"></i> Détail</button></a>
                    <div class="mini"></div>
                    <div class="mini"></div>
                    <a href="index.php?page=FormMenus&mode=modifier&id=' . $obj->getIdMenu() . '"><button class="bouton"><i class="fas fa-edit"></i> Modifier</button></a>
                    <div class="mini"></div>
                    <div class="mini"></div>
                    <a href="index.php?page=ActionMenus&mode=supprimer&id=' . $obj->getIdMenu() . '"><button class="bouton"><i class="fas fa-trash-alt"></i> Supprimer</button></a>
                    <div class="mini"></div>
                </div>';

    echo '</div>';
}

echo '</section>';
