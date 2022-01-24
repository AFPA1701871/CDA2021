/*****************VARIABLES ******************/

const requ = new XMLHttpRequest();
var listeDep = document.getElementsByClassName("listeDep")[0];
var select = document.getElementsByTagName("select")[0];

select.addEventListener("change", changeRegion);

/*****************LISTENER ******************/
requ.onreadystatechange = function (event) {
    // XMLHttpRequest.DONE === 4
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            console.log("Réponse reçue: %s", this.responseText);
            reponse = JSON.parse(this.responseText);
            //on enleve les departements deja presents
            listeDep.innerHTML = "";
            for (let i = 0; i < reponse.length; i++) { //on traite les éléments de la liste ....
                ajoutDepartement(reponse[i].libelleDepartement, reponse[i].idDepartement);
            }
        } else {
            console.log("Status de la réponse: %d (%s)", this.status, this.statusText);
        }
    }
};




/**************************FUNCTIONS **********/
function changeRegion(e) {
    if (select.value != "defaut") // si c'est pas le choix par defaut
    {
        // je lance une requete Ajax
        requ.open('POST', 'index.php?codePage=listeAPI', true);
        requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        var id = select.value; // id de la région choisie
        var args = "idRegion=" + id;
        requ.send(args);
    }

}

function ajoutDepartement(libDepart, idDepart) {

    let dept = document.createElement("div");
    dept.setAttribute("class", "unDept");
    dept.setAttribute("id", idDepart);
    dept.innerHTML = libDepart;
    listeDep.appendChild(dept);
}