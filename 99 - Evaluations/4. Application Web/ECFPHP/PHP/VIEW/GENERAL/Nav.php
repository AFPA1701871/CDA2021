<nav>
    <?php
    if (isset($_SESSION['utilisateur']) && $_SESSION['utilisateur']->getRole() == 2)
        echo "
<div><a href='?page=ListeArticles'>Articles</a></div>
<div><a href='?page=ListeTypesArticles'>Types d'articles</a></div>
<div><a href='?page=ListePaniers'>Paniers</a></div>
<div><a href='?page=ListeUtilisateurs'>Clients</a></div>
<div><a href='?page=Catalogue'>Catalogue</a></div>";
    else {
        echo "<div><a href='?page=ListeLignesPaniers'>Panier</a></div>
<div><a href='?page=Catalogue'>Catalogue</a></div>";
    }
    echo '</nav>
<div class="bigEspace"></div>        
';
