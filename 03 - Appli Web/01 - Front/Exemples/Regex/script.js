/*var nom = document.getElementById("nom");
nom.addEventListener("input",checkNom);
var boutonValider = document.querySelector("button[type=submit]");
//var regexNom = new RegExp('[\\w]{3,}');


function checkNom()
{
    //if (regexNom.test(nom.value))
    if (nom.checkValidity())
    {
        nom.classList.remove("rouge");
        nom.classList.add("vert");
        boutonValider.disabled=false;
    }
    else{
        nom.classList.remove("vert");
        nom.classList.add("rouge");
        boutonValider.disabled=true;
    }
}*/
// var valide = {
//     nom: false,
//     prenom: false
// }
var valide = {} // contient false si l'input ne respecte pas la regex, true sinon
var lesInputs = document.getElementsByTagName("input");
for (let i = 0; i < lesInputs.length; i++) {
    lesInputs[i].addEventListener("input", check);
    // on ajoute un attribut à l'objet valide pour chaque input
    if (lesInputs[i].required)
        valide[lesInputs[i].name] = false;
    else {
        valide[lesInputs[i].name] = true;
    }
}
var boutonValider = document.querySelector("button[type=submit]");


console.log(valide);

function check(event) {
    input = event.target;
    if (input.checkValidity()) {
        input.classList.remove("rouge");
        input.classList.add("vert");
        valide[input.name] = true;
    } else {
        input.classList.remove("vert");
        input.classList.add("rouge");
        valide[input.name] = false;
    }
console.log(valide);
    checkForm();
}

function checkForm() {
    boutonValider.disabled = false;
    // Object.values(valide) : transforme l'objet en tableau
    //.indexOf(false) : cherche la position de false dans le tableau
    // si Object.values(valide).indexOf(false) est different de -1, ca veut dire qu'il a trouvé un false dans le tableau
    // donc l'un des input ne respecte pas la regex
    if (Object.values(valide).indexOf(false) != -1) {
        boutonValider.disabled = true;
    }
}