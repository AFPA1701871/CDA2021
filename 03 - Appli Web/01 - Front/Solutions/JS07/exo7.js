//Les variables
lesLi= document.querySelectorAll("li");
lesBoutons=document.querySelectorAll("button");

//Les listener
for (let i = 0; i < lesLi.length; i++) {
    lesLi[i].addEventListener("click",supprimer);  
}

for (let i = 0; i < lesBoutons.length; i++) {
    lesBoutons[i].addEventListener("click",ajout);
}


//Les Fonctions
function supprimer(event){
    event.target.remove();
}

function ajout(event){
    // div=event.target.parentNode;
    // input=div.querySelector("input");

    input = event.target.previousElementSibling;

    newLi= document.createElement("li");
    newLi.textContent = input.value;
    newLi.addEventListener("click",supprimer);

    ul=document.querySelector("ul");
    ul.appendChild(newLi);

}