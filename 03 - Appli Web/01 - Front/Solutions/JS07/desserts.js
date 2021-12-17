function modifieDessert(e)
{
    // e correspond à l'evenement declenché
    // e.target correspond à l'element qui a déclenché l'évenement
    e.target.textContent = prompt("quel dessert",e.target.textContent);
}
function ajoutDessert (){
    var nouvLi = document.createElement("li");
    nouvLi.textContent = prompt("quel dessert");
    nouvLi.className="jaune gras";
    nouvLi.addEventListener("click",  modifieDessert );
    document.getElementById("desserts").appendChild(nouvLi);
}
var ajoutBtnElt = document.querySelector("button");
// Ajout d'un gestionnaire pour l'événement click
ajoutBtnElt.addEventListener("click", ajoutDessert);


