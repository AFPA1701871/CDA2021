// Utilisation de l'Ajax pour appeler l'API et récuperer les enregistrements
var contenu = document.getElementById("contenu");
var enregs; // contient la reponse de l'API
// on définit une requete
const req = new XMLHttpRequest();

//on envoi la requête
req.open('GET', 'https://opendata.lillemetropole.fr/api/records/1.0/search/?dataset=vlille-realtime&q=&rows=50&facet=libelle&facet=nom&facet=commune&facet=etat&facet=type&facet=etatconnexion', true);
req.send(null);

//on vérifie les changements d'états de la requête
req.onreadystatechange = function (event) {
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            // la requete a abouti et a fournit une reponse
            //on décode la réponse, pour obtenir un objet
            reponse = JSON.parse(this.responseText);
            console.log(this.responseText);
            console.log(reponse);
            enregs = reponse.records;
            for (let i = 0; i < enregs.length; i++) {
                // on crée la ligne et les div internes
                // je recupere le template
                var templLigne = document.getElementById("ligne");
                // on clone le template pour avoir une nouvelle structure
                nouvElt = templLigne.content.cloneNode(true);
                //ajoute à la stucture
                contenu.appendChild(nouvElt);
                ligne = contenu.querySelectorAll(".ligne")[i];
                ligne.id = i;
                enfant1 = ligne.querySelector(".ville");
                espace = document.getElementById("espace");
                contenu.appendChild(espace.content.cloneNode(true));
                //on met à jour le contenu
                enfant1.innerHTML = enregs[i].fields.commune;
                enfant1.nextElementSibling.innerHTML = enregs[i].fields.nom;
                enfant1.nextElementSibling.nextElementSibling.innerHTML = enregs[i].fields.etat;
            }
            console.log("Réponse reçue: %s", this.responseText);
        } else {
            console.log("Status de la réponse: %d (%s)", this.status, this.statusText);
        }
    }
};

var actu=document.getElementById("actu");

actu.addEventListener("click",function(){
    req.open('GET', 'https://opendata.lillemetropole.fr/api/records/1.0/search/?dataset=vlille-realtime&q=&rows=50&facet=libelle&facet=nom&facet=commune&facet=etat&facet=type&facet=etatconnexion', true);
    req.send(null);
});

