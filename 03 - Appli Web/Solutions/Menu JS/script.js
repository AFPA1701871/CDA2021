var listeMenus = document.getElementsByClassName("menu");
for (let i = 0; i < listeMenus.length; i++) {
    listeMenus[i].addEventListener("click", clickMenu);
}


function clickMenu(event) {
    /* Fermer les sousMenu ouvert */
    for (let i = 0; i < listeMenus.length; i++) {
        listeMenus[i].querySelector(".sousMenu").style.display = "none";

    }
    /* Ouvrir le sous menu*/
    // le clic est déclenché par MenuItem. On remonte à son parent pour obtenir le menu
    var menuClique = event.target.parentNode;
    var sousMenu = menuClique.querySelector(".sousMenu");
    sousMenu.style.display = "block";
}