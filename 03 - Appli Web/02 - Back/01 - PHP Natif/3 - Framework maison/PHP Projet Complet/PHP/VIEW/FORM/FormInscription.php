<div class="demiPage colonne">
    <form action="index.php?page=actionInscription" method="POST">
        <div>
            <label for="nom"><?php echo texte('Nom') ?></label>
            <input type="text" name="nom" required />
        </div>
        <div>
            <label for="prenom"><?php echo texte('Prenom') ?></label>
            <input type="text" name="prenom" required />
        </div>
        <div>
            <label for="motDePasse"><?php echo texte('MotDePasse') ?></label>
            <input type="password" name="motDePasse" required />
        </div>
        <div>
            <label for="confirmation"><?php echo texte('ConfirmationMotDePasse') ?></label>
            <input type="password" name="confirmation" required />
        </div>
        <div>
            <label for="adresseMail"><?php echo texte('AdresseEmail') ?></label>
            <input type="text" name="adresseMail" required />
        </div>
        <div>
            <label for="role"><?php echo texte('Role') ?></label>
            <input type="text" name="role" required />
        </div>
        <div>
            <label for="pseudo"><?php echo texte('Pseudo') ?></label>
            <input type="text" name="pseudo" required />
        </div>
        <div>
            <div></div>
            <button type="submit"><?php echo texte('Envoyer') ?></button>
            <div></div>
        </div>

    </form>