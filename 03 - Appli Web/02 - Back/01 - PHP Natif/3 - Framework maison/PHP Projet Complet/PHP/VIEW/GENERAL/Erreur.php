<div class="demiPage colonne">
    <h2 class="flex">
        <?php 
        if (isset($_GET['codeErreur'])) {
            // echo ErreurManager::findByCodes($_GET['codeErreur']);
            echo TexteManager::findByCodes($_SESSION['lang'],$_GET['codeErreur']);
        }else{
            // echo ErreurManager::findByCodes("inconnue");
            echo TexteManager::findByCodes($_SESSION['lang'],"inconnue");
        }
        ?>
    </h2>
    <div class="espaceHorizon"></div>
    <div>
        <div></div>
        <div>
            <?php 
            if (isset($_GET['source'])) {//si on a une page où retourner, on y va
                echo'<a class="crudBtn crudBtnRetour flex" href="index.php?page='.$_GET["source"].'">Ok.</a>';
            }else{//sinon, go acceuil
                echo'<a class="crudBtn crudBtnRetour flex" href="index.php?page=accueil">Ok.</a>';
            }
            ?>
        </div>
        <div></div>
    </div>
    
</div>