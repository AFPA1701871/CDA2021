<div class="demiPage colonne">
    <form action="index.php?page=actionInscription" method="POST">
        <div>
            <label for="nom">Nom</label>
            <input type="text" name="nom" required />
        </div>
        <div>
            <label for="prenom">Prenom</label>
            <input type="text" name="prenom" required />
        </div>
        <div>
            <label for="motDePasse">mot De Passe</label>
            <input type="password" name="motDePasse" required />
        </div>
        <div>
            <label for="confirmation">Confirmation du mot de passe</label>
            <input type="password" name="confirmation" required />
        </div>
        <div>
            <label for="adresseMail">Adresse mail</label>
            <input type="text" name="adresseMail" required />
        </div>
        <div>
            <label for="role">Role (1 : user - 2 : admin)</label>
            <input type="text" name="role" required />
        </div>
        <div>
            <label for="pseudo">Pseudo</label>
            <input type="text" name="pseudo" required />
        </div>
        <div>
            <div></div>
            <button type="submit">Valider</button>
            <div></div>
        </div>

    </form>