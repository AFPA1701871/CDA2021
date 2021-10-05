<!DOCTYPE HTML>
<HTML>
<head>
    <meta charset="UTF-8" />
    <title>structureSite</title>
    <link rel="stylesheet" href="CSS/style.css" />
</head>
<body>
    <div id="header">
        <h1>Formulaire de recherche</h1>
    </div>
    <form action="?page=Reponse" method="POST">
       
        <div class="ligne">
            <label for="nom">Nom : </label>
            <input type="text" class="input" id="nom" name="nom" required >
        </div>
        
        <div class="bouton ">
            <button id="submit" type="submit">Valider</button>
            <button type="button">Annuler</button>
        </div>
    </form>
    <div>Essayez avec : <img src = "Images/test1.PNG">   </div>
    <div>Puis avec : <img src = "Images/test2.PNG">   </div>
    <div>Ou encore : <img src = "Images/test3.PNG">   </div>
    <div class="resultat"></div>
</body>

</html>