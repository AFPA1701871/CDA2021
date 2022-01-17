//Initialise 3 constante afin d'initialisé les couleurs ( la valeur entre "" correspond a la classe css qui sera ajouter ).
const green = "inputCorrect";
const white = "inputVide";
const red = "inputIncorrect";

var listForms = document.querySelectorAll('form');

//Récupère tous les inputs du formulaire et effectue une première vérification & ajoute les eventListener sur chacun d'entre eux.
listForms.forEach(formulaire => {
    // pour chaque formulaire, on récupère les inputs
    let listInputs = formulaire.querySelectorAll("input:not([type='submit']):not([type='reset']:not([type='button']),select,textarea");
    let submit = formulaire.querySelector("input[type='submit'], button[type='submit']");
    let reset = formulaire.querySelector("input[type='reset']");
    let listInputsValidity = {}; // tableau qui contient pour chaque input : vrai si l'input est valide, faux sinon

    // on lance la vérification sur tous les champs du formulaire
    InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire);

    if (reset != undefined) {
        // Initialise le bouton reset
        reset.addEventListener('click', function () {
            resetInputs(listInputs, listInputsValidity, submit, formulaire)
        });
    }

    listInputs.forEach(element => {
        element.addEventListener('input', function () {
            // on déclenche la vérification sur tous les champs du formulaire à chaque changement d'input
            InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire)
        });
    });
});

/***********************************Function************************************/

/**
 * Vérifie que le pattern de l'input est respecté et que l'input n'est pas vide si il est required.
 * Change l'aspect des inputs en fonction de leur état
 * Active ou pas le bouton submit
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 * @param {object} formulaire 
 */
function InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire) {
    console.log(listInputs);
    // Pour chaque input, on vérifie sa validité
    listInputs.forEach(element => {
        if (element.checkValidity()) {
            listInputsValidity[element.name] = true;
        } else {
            listInputsValidity[element.name] = false;
        }
    });
    // Vérification spéciale pour le mot de passe
    verifPassword(listInputsValidity, formulaire);
    // Change l'aspect des inputs en fonction de leur état
    changeColor(listInputs, listInputsValidity);
    // Active ou pas le bouton submit
    revealSubmitButton(listInputsValidity, submit);
};

/**
 * Vérification du mot de passe et de la confirmation de mot de passe.
 * @param {[]} listInputsValidity 
 * @param {object} formulaire 
 */
function verifPassword(listInputsValidity, formulaire) {
    let listePassword = formulaire.querySelectorAll("input[type=password]");

    if (count(listePassword)==2 && listePassword[0].value != listePassword[1].value) {
        listInputsValidity[listePassword[1].name] = false;
    }
};

/**
 * Change la couleur des inputs en fonction de la validité de l'input.
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 */
function changeColor(listInputs, listInputsValidity) {
    listInputs.forEach(element => {
        // on enlève les classes déja affectée
        element.classList.remove(green, red, white);
        // en fonction des coditions, on ajoute les bonnes classes
        if (listInputsValidity[element.name] == true && element.value != "") {
            element.classList.add(green);
        } else if (listInputsValidity[element.name] == false && (element.type == "number" || element.value != "")) {
            element.classList.add(red);
        } else {
            element.classList.add(white);
        }
    });
};

/**
 * Reset tous les inputs du formulaire en m'étant la valeur par default.
 * @param {[object]} listInputs 
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 */
function resetInputs(listInputs, listInputsValidity, submit, formulaire) {
    listInputs.forEach(element => {
        element.value = element.defaultValue;
    });
    // on relance la vérification sur tous les champs
    InputsCheckValidity(listInputs, listInputsValidity, submit, formulaire);
};

/**
 * Affiche le button submit si tous les inputs sont correctement remplis.
 * @param {[]} listInputsValidity 
 * @param {object} submit 
 */
function revealSubmitButton(listInputsValidity, submit) {
    console.log(listInputsValidity);
    // on active le bouton
    submit.disabled = false;
    // si un input est mal rempli on désactive le bouton
    if (Object.values(listInputsValidity).indexOf(false) != -1) {
        submit.disabled = true;
    }
};