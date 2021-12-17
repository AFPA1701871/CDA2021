listeH1 = document.getElementsByTagName("h1")
listeH2 = document.getElementsByTagName("h2")
listeH3 = document.getElementsByTagName("h3")
listeP = document.getElementsByTagName("p")

ajoutListener(listeH1, ["pink", "orange", "yellow","green"], true);
ajoutListener(listeH2, ["green", "orange", "yellow"], true);
ajoutListener(listeH3, ["pink", "blue", "yellow"], true);
ajoutListener(listeP, ["tomato", "orange"], false);

function ajoutListener(tab, couleurs, flag) {
    for (let i = 0; i < tab.length; i++) {
        tab[i].addEventListener("click", function (event) {
            changerCouleur(tab, couleurs, flag,event)
        })
    }
}

function changerCouleur(tab, tabCouleur, flagTous, event) {
    //determine la nouvelle couleur du 1er element puisque c'est la meme pour tous
    if (tab[0].style.color == "") {
        nouvelleCouleur = tabCouleur[0];
    } else {
        nouvelleCouleur = "";
        j = 0;
        do {
            if (tabCouleur[j] == tab[0].style.color) {
                nouvelleCouleur = tabCouleur[(j + 1) % tabCouleur.length];
            }
            j++;
        }
        while (nouvelleCouleur == ""); // on s'arrete lorsque la nouvelle couleur est trouvée.
        // il n'y a pas de risque de dépasser la capacité du tableau
    }
    // j'applique la nouvelle couleur
    if (flagTous) // il faut changer tous les elements du tableau
    {
        for (let i = 0; i < tab.length; i++) {
            tab[i].style.color = nouvelleCouleur;
        }
    } else { // on change celui qui a déclenché l'evenement
        event.target.style.color = nouvelleCouleur;
    }
}