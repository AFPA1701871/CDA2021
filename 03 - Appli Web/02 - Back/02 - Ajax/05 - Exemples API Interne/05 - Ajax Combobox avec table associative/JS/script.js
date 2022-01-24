//Variables
const requ = new XMLHttpRequest();
var listeOeuvre = document.querySelector(".listeOeuvre");
var select = document.querySelector("select");

select.addEventListener("change",changeAuteur);

//Ajax
requ.onreadystatechange = function(event) {
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            console.log("Réponse reçue: %s", this.responseText);;
            reponse=JSON.parse(this.responseText);
            listeOeuvre.innerHTML="";
            for (let i = 0; i < reponse.length; i++) {
                ajoutOeuvres(reponse[i].typeOeuvre, reponse[i].titreOeuvre, reponse[i].idOeuvre);   
            }
            console.log(reponse);
        } else {
            console.log("Status de la réponse: %d (%s)", this.status, this.statusText);
        }
    }
};


//Functions

function changeAuteur(){
    if (select.value != "defaut"){
        // pour récupérer les oeuvres de l'auteur, on doit passer par la table associative => donc par la vue
        requ.open('POST', 'index.php?page=APIAuteursOeuvres', true);
        requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        var id = select.value;
        var args = "idAuteur=" + id;
        requ.send(args);
    }
}

function ajoutOeuvres(typeOeuvre,titreOeuvre,idOeuvre) {

    let oeuvre = document.createElement("div");
    oeuvre.setAttribute("class", "uneOeuvre");
    oeuvre.setAttribute("id", idOeuvre);
    oeuvre.innerHTML = typeOeuvre + ' : ' + titreOeuvre;
    listeOeuvre.appendChild(oeuvre);
}



