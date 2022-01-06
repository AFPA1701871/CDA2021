<div class="demiPage colonne">
    <form action="index.php?page=actionConnection" method="post">
        <div>
            <label for="pseudo"><?php echo texte('Pseudo') ?></label>
            <input type="text" name="pseudo" required />
        </div>
        <div>
            <label for="motDePasse"><?php echo texte('MotDePasse') ?></label>
            <input type="password" name="motDePasse" required />
        </div>
        <div>
            <div></div>
            <button type="submit"><?php echo texte('Envoyer') ?></button>
            <div></div>
        </div>

    </form>
    <div>
        <div></div>

        <a href="index.php?page=inscription"><?php echo texte('Inscription') ?></a>
        <div></div>
    </div>
</div>