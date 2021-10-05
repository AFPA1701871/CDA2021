<div></div>
<section>

    <?php

    $mode = $_GET['mode'];
    if (isset($_GET['id'])) {
        $id = $_GET['id'];
        $obj = MenusManager::findById($id);
    } else {
        $obj = new Menus();
    }
    $idHidden = '<input name= "idMenu" value="' . $obj->getIdMenu() . '" type= "hidden">';

    switch ($mode) {
        case "ajouter": {
                $idHidden = '';
                $disabled = '';
                $submit = '<button id="submit" class="bouton" type="submit"><i class="fas fa-paper-plane"></i>&nbsp Ajouter</button><div class="mini"></div>';
                break;
            }
        case "modifier": {
                $disabled = '';
                $submit = '<button id="submit" class="bouton"><i class="fas fa-edit"></i> &nbsp Modifier</button><div class="mini"></div>';
                break;
            }
        case "details": {
                $disabled = 'disabled';
                $submit = '';
                break;
            }
        case "supprimer": {
                $disabled = 'disabled';
                $submit = '<button class="bouton"><i class="fas fa-trash-alt"></i>&nbsp Supprimer</button>
            <div class="mini"></div>';
                break;
            }
    }
    echo '<form action="index.php?page=ActionMenus&mode=' . $mode . '" method="POST">';
    echo $idHidden;

    ?>
    <div>

        <div class="info colonne ">
            <label class="titre centre" for="libelleMenu">Menu :</label>
            <input type="text" id="libelleMenu" <?= $disabled; ?> name="libelleMenu" value="<?= $obj->getLibelleMenu(); ?>" required >
        </div>       
    </div>
    <h3>Mettre test'); drop table test;</h3>
    <div class="espaceHor"></div>
    <div>

            <?php
            echo $submit;
            echo '<a href="index.php?page=ListeMenus"><div class="bouton"><i class="far fa-arrow-alt-circle-left"></i>&nbsp Retour</div></a>';
            ?>

    </div>

    </form>

</section>