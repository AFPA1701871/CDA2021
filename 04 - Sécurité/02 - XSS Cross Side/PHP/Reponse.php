<!DOCTYPE HTML>
<HTML>
<head>
    <meta charset="UTF-8" />
    <title>structureSite</title>
    <link rel="stylesheet" href="CSS/style.css" />
</head>
<body>
    <div class="colonne">
        <div><h1>Formulaire de recherche</h1></div>
        
        <div><h1>Réponse</h1></div>
    </div>
  
   <?php if (isset($_POST["nom"]))
    {
        echo '<div class="resultat"> Le résultat de votre recherche pour : '.$_POST["nom"].'</div>';
      // pour pallier, utiliser htmlspecialchars
      /* var_dump(htmlspecialchars($_POST["nom"]));
        echo '<div class="resultat"> Le résultat de votre recherche pour : '.htmlspecialchars($_POST["nom"]).'</div>';
        */
    }
    // ecrire le php classique de recherche
    ?>
    <a href="?page=Formulaire" ><button>Retour</button></a>
</body>

</html>