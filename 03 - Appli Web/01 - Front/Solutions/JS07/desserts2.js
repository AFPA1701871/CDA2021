function suppDessert(e)
{
    // e correspond à l'evenement declenché
    // e.target correspond à l'element qui a déclenché l'évenement
    liClique = e.target;
    parent = liClique.parentNode; // on recupere l'element parent
    parent.removeChild(liClique);    // on supprime l'element enfant
}
function ajoutDessert (){
    var nouvLi = document.createElement("li");
    nouvLi.textContent = prompt("quel dessert");
    nouvLi.addEventListener("click",  suppDessert );
    document.getElementById("desserts").appendChild(nouvLi);
}
var ajoutBtnElt = document.querySelector("button");
// Ajout d'un gestionnaire pour l'événement click
ajoutBtnElt.addEventListener("click", ajoutDessert);


