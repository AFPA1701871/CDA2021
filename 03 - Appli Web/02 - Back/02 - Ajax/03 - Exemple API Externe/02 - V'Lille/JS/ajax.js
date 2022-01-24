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
            enregs = trie(reponse.records);
            for (let i = 0; i < enregs.length; i++) {
                // on crée la ligne et les div internes
                ligne = document.createElement("div");
                ligne.setAttribute("class", "ligne");
                ligne.id = i;
                ville = document.createElement("div");
                ville.setAttribute("class", "commune");
                ligne.appendChild(ville);
                libelle = document.createElement("div");
                libelle.setAttribute("class", "nom");
                ligne.appendChild(libelle);
                etat = document.createElement("div");
                etat.setAttribute("class", "etat");
                ligne.appendChild(etat);
                contenu.appendChild(ligne);
                espace = document.createElement("div");
                espace.setAttribute("class","espaceHorizon");
                contenu.appendChild(espace);
                //on met à jour le contenu
                ville.innerHTML = enregs[i].fields.commune;
                libelle.innerHTML = enregs[i].fields.nom;
                etat.innerHTML = enregs[i].fields.etat;

                // on ajoute un evenement sur ligne pour afficher le detail
                ligne.addEventListener("click", afficheDetail);
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

function afficheDetail(e) {
    parkingClique = (e.target).parentNode;
    parkingClique.removeEventListener("click", afficheDetail);
    detail = document.createElement("div");
    detail.setAttribute("class", "detail");
    adresse = document.createElement("div");
    adresse.setAttribute("class", "adresse");
    detail.appendChild(adresse);
    dispo = document.createElement("div");
    dispo.setAttribute("class", "nbVeloDispo");
    detail.appendChild(dispo);
    nbMax = document.createElement("div");
    nbMax.setAttribute("class", "nbPlaces");
    detail.appendChild(nbMax);
    adresse.innerHTML = enregs[parkingClique.id].fields.adresse;
    dispo.innerHTML = "  nb velos dispo " + enregs[parkingClique.id].fields.nbvelosdispo;
    nbMax.innerHTML= "  nb places dispo " + enregs[parkingClique.id].fields.nbplacesdispo;
    contenu.insertBefore(detail, parkingClique.nextSibling);
}

function trie(tab){

    do{
        //on part du principe que le tableau est bien trié, et dès que l'on fait une permutation il ne l'est plus. Si on ne fait plus de permutation alors il est trié et on sort de la boucle
        flag=true;
        //on compare tout les éléments du tableau avec son voisin (sauf le dernier)
        for(let i=0;i<tab.length-1;i++){
            //si la valeur suivante est plus petite alors on permute les 2 valeurs dans le tableau
            if(tab[i+1].fields.commune<tab[i].fields.commune){
                temp=tab[i];
                tab[i]=tab[i+1];
                tab[i+1]=temp;
                flag=false;    
            }
        }
    }while(!flag);
    return tab;
}
