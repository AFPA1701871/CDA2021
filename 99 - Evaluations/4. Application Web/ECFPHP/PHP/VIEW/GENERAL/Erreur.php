<div class=" center colonne">
    <h2 class="">
        <?php 
        if (isset($_GET['codeErreur'])) {
            echo texte($_GET['codeErreur']);
        }else{
            echo texte($titre);
        }
        ?>
    </h2>
    <div class="espaceHorizon"></div>
    <div>
        <div></div>
        <div>
            <?php 
            if (isset($_GET['cible'])) {//si on a une page où retourner, on y va
                echo '<a href="index.php?page='.$_GET["cible"].'"><i class="fas fa-sign-out-alt fa-rotate-180"></i></a>';
            }else{//sinon, go connexion
                echo '<a href="index.php?page=Connexion"><i class="fas fa-sign-out-alt fa-rotate-180"></i></a>';
            }
            ?>
        </div>
        <div></div>
    </div>
    
</div>