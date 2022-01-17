const RightArrow = "fa-chevron-right";
const DownArrow = "fa-chevron-down";
var childMenuOuvert; // variable qui stockera le sous menu ouvert
var nav = document.querySelector("nav");

var listMenu = document.querySelectorAll(".menu");

listMenu.forEach(element => {
    element.addEventListener('click', function () {
        showChildMenu(element, listMenu)
    });
});

/*** Gère l'ouverture du menu. ***/
document.querySelector(".fa-bars").addEventListener("click", function () {
    nav.style.display = "flex";
});

/*** Gère la fermeture du menu et du sous menu déjà ouvert. ***/
document.querySelector("#fermetureMenu").addEventListener("click", function () {
    nav.style.display = "none";
    if (childMenuOuvert != undefined) {
        childMenuOuvert.classList.add("noDisplay");
        changeArrowDirection(childMenuOuvert.parentNode);
        childMenuOuvert = undefined;
    }
});
/**
 * gestion des sous menus
 * @param {} menu : menu sur lequel on a cliqué
 */
function showChildMenu(menu) {
    var childMenu = menu.querySelector(".noDisplay")

    /*** Ferme le menu qui est déjà ouvert. ***/
    if (childMenuOuvert != undefined && childMenu != childMenuOuvert) {
        childMenuOuvert.classList.add("noDisplay");
        /*** Change la flèches du menu a fermer. ***/
        changeArrowDirection(childMenuOuvert.parentNode);
    }

    //s'il y a un sous menu
    if (childMenu != undefined) {
        /*** Gère l'apparition des sous menus. ***/
        if (childMenu.classList.contains("noDisplay")) {
            childMenu.classList.remove("noDisplay");
        } else {
            childMenu.classList.add("noDisplay");
        }

        /*** Change la flèches du menu actuel. ***/
        changeArrowDirection(menu);

        listChildMenuItems = childMenu.querySelectorAll(".childMenuItem");
        /*** Gère les bordures des sous menus. ***/
        listChildMenuItems[0].classList.add("borderRadiusTop");
        listChildMenuItems[listChildMenuItems.length - 1].classList.add("borderRadiusBottom");
    }

    /*** Change la valeur de childMenuOuvert et donne le childMenu actuel. si les deux sont égaux c'est a dire que le menu se ferme donc change la valeur de childMenuOuvert a undefined. ***/
    if (childMenuOuvert == childMenu) {
        childMenuOuvert = undefined;
    } else {
        childMenuOuvert = childMenu;
    }
}

/**
 * Function qui change la direction de la flèche FontAwesome.
 * @param {*} menu 
 */
function changeArrowDirection(menu) {

    var baliseArrow = menu.querySelector(".fas");

    if (baliseArrow.classList.contains(RightArrow)) {
        baliseArrow.classList.remove(RightArrow);
        baliseArrow.classList.add(DownArrow);
    } else {
        baliseArrow.classList.remove(DownArrow);
        baliseArrow.classList.add(RightArrow);
    }
}