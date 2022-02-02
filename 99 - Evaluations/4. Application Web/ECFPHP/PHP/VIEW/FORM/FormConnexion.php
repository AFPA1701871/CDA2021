<?php
global $regex;
?>

<main class="colonne">
    <section class="center colonne">
        <form action="index.php?page=ActionConnexion" method="POST">
            <div class="colSpan2 center"><h1><?php echo texte('Connexion') ?></h1></div>

            <label for="adresseMail"><?php echo texte('AdresseEmail') ?> : </label>
            <input type="text" name="adresseMail" required>

            <label for="motDePasse"><?php echo texte('Mdp') ?> : </label>
            <div class="relative">
                <input type="Password" name="motDePasse" required>
                <i class="oeil fas fa-eye"></i>
            </div>

            <div></div>
            <div></div>

            <div></div>
            <input type="submit" value="<?php echo texte('Envoyer') ?>">
        </form>
    </section>
    <h5><a href="?page=Inscription">Cliquer ici pour vous inscrire</a></h5>
</main>