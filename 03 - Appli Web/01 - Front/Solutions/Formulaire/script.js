var infos=document.querySelectorAll(".iconeInfo");
var mdp=document.getElementById("mdp");
var infoMDP=document.getElementById("infoMDP");
var listeInputs=document.querySelectorAll("input[type=text]");
var valide = {} // contient false si l'input ne respecte pas la regex, true sinon
var boutonValider=document.querySelector("input[type=submit]")
var eye=document.getElementById("eye");

var DDN=document.querySelector("input[type=date]")

//Initialisation des regex du MDP
var RegexMDP=mdp.pattern.split(')'); // On récupère toute les conditions du regex du mdp
for(i=0;i<RegexMDP.length-1;i++){ //On ajoute la fermeture de parenthèse enlever avec le split au élément qui en ont besoin (pas la dernière qui est le nombre de caractères) et on les transforme en Regex
    RegexMDP[i]=RegExp(RegexMDP[i]+")");
}
RegexMDP[RegexMDP.length-1]=RegExp(RegexMDP[RegexMDP.length-1]);//On transforme la dernière condition en Regex

//Validation des Inputs
listeInputs.forEach(element => {
    element.addEventListener("input",check);
    // on ajoute un attribut à l'objet valide pour chaque input
    if (element.required)
        valide[element.name] = false;
    else {
        valide[element.name] = true;
    }
});


//Affichage des informations au survol des icones ?
infos.forEach(element => {
    element.addEventListener("mouseover",function(e){
        e.target.parentNode.nextElementSibling.classList.remove("cacher");
    })
    element.addEventListener("mouseout",function(e){
        e.target.parentNode.nextElementSibling.classList.add("cacher");
    })
});

//Affichage des informations sur le champs MDP
mdp.addEventListener("focus",function(e){
    infoMDP.classList.remove("cacher");
});
mdp.addEventListener("focusout",function(e){
    infoMDP.classList.add("cacher");
});
//Event qui check les different regex du MDP et le valide si ils sont bon
mdp.addEventListener('input',checkMDP);
valide["password"]=false; //ajout du password dans la liste des validations

//Oeil qui affiche le mdp
eye.addEventListener("mouseover",function(){
    mdp.type="text";
});
eye.addEventListener("mouseout",function(){
    mdp.type="password";
});

//date
DDN.addEventListener("input",function(e){
    var dateAuj=new Date();
    var date=new Date(e.target.value);
    if(dateAuj.getTime()<date.getTime()){
        e.target.nextElementSibling.querySelector(".iconeErreur").setAttribute("class","fas fa-cannabis multicolor iconeErreur");
        valide["DDN"] = false;
    }else{
        e.target.nextElementSibling.querySelector(".iconeErreur").setAttribute("class","fas fa-check-circle green iconeErreur");
        valide["DDN"] = true;
    }
    checkForm();
});
valide["DDN"]=true;

/**
 * Check la validé de l'input (text) et affiche l'icone d'erreur ou validation
 * @param {*} e 
 */
function check(e){
    input = e.target;

    //récupération de l'icone erreur
    if(input.type=="password"){//Le password à une architecture differente des autres input (ajout de l'oeil)
        icone=e.target.parentNode.nextElementSibling.querySelector(".iconeErreur");
    }else{
        icone=e.target.nextElementSibling.querySelector(".iconeErreur");
    }

    if (input.checkValidity()) {
        icone.setAttribute("class","fas fa-check-circle green iconeErreur") //icone correcte
        valide[input.name] = true;
    } else {
        icone.setAttribute("class","fas fa-times-circle red iconeErreur")//icone erreur
        valide[input.name] = false;
    }
    checkForm();
}

/**
 * Check si le formulaire est bien remplis et active ou desactive le bouton en conséquence
 */
function checkForm(){
    boutonValider.disabled = false;
    boutonValider.nextElementSibling.children[0].classList.remove("cacher") // affiche le petit bonhomme
    // Object.values(valide) : transforme l'objet en tableau
    //.indexOf(false) : cherche la position de false dans le tableau
    // si Object.values(valide).indexOf(false) est different de -1, ca veut dire qu'il a trouvé un false dans le tableau
    // donc l'un des input ne respecte pas la regex
    if (Object.values(valide).indexOf(false) != -1) {
        boutonValider.disabled = true;
        boutonValider.nextElementSibling.children[0].classList.add("cacher") // enlever le petit bonhomme
    }
}

/**
 * check les different regex du mdp, et change sa valeur dans le tableau valideMDP et affiche l'icone en conséquence 
 */
function checkMDP(e){

    // Si un caractère est un chiffre
   if(RegexMDP[0].test(mdp.value)){ 
        infoMDP.children[1].children[2].children[0].setAttribute("class","fas fa-check-circle green");
   }else{
        infoMDP.children[1].children[2].children[0].setAttribute("class","fas fa-times-circle red");
   }
   // Si un caractère est une majuscule
    if(RegexMDP[1].test(mdp.value)){ 
        infoMDP.children[1].children[0].children[0].setAttribute("class","fas fa-check-circle green");
    }else{
        infoMDP.children[1].children[0].children[0].setAttribute("class","fas fa-times-circle red");
    }
    // Si un caractère est une minuscule
    if(RegexMDP[2].test(mdp.value)){ 
        infoMDP.children[1].children[1].children[0].setAttribute("class","fas fa-check-circle green");
    }else{
        infoMDP.children[1].children[1].children[0].setAttribute("class","fas fa-times-circle red");
    }
    // Si un caractère est un caractère spécial
    if(RegexMDP[3].test(mdp.value)){ 
        infoMDP.children[1].children[3].children[0].setAttribute("class","fas fa-check-circle green");
    }else{
        infoMDP.children[1].children[3].children[0].setAttribute("class","fas fa-times-circle red");
    }
    // Si il y a 8 caractère
    if(RegexMDP[4].test(mdp.value)){ 
        infoMDP.children[1].children[4].children[0].setAttribute("class","fas fa-check-circle green");
    }else{
        infoMDP.children[1].children[4].children[0].setAttribute("class","fas fa-times-circle red");
    }
    check(e);
}




//bouton up
var up=document.getElementById("up");

window.addEventListener("scroll",function(){
    if(window.scrollY==0){
        up.classList.add("cacher");
    }else{
        up.classList.remove("cacher");
    }
});

up.addEventListener("click",function(){
    window.scrollTo(0,0);
});