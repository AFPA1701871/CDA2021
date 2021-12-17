var nbImageSelectionne = 0; //contient 0 si aucune image selectionnée, 1 sinon
var imageEnCours; //image en cours
var imagePrecedente; //image precedente
var nbPairTrouvee = 0; //nombre de pair trouvée
var nbClick = 0; //nombre de clic
var zoneMessage = document.getElementById("message");
var zoneNbClick = document.getElementById("nbClick");
var zoneNbPairTrouvee = document.getElementById("nbPair");
var btnInit = document.getElementById("Reinitialiser");
var btnSolution = document.getElementById("Solution");

init();
btnInit.addEventListener("click", init);
btnSolution.addEventListener("click", solution);


function init() {
    nbClick = 0;
    nbPairTrouvee = 0;
    nbImageSelectionne = 0;
    imageEnCours = null;
    imagePrecedente = null;
    zoneNbClick.innerHTML = nbClick;
    zoneNbPairTrouvee.innerHTML = nbPairTrouvee;
    zoneMessage.innerHTML = "";
    var images = [];
    index = 0;
    //on prepare un tableau avec les numéros des 16 images
    for (let i = 1; i <= 8; i++) {
        //la clé est un nombre aleatoire pour permettre le tri aleatoire
        images[index++] = i //numero de l'image
        images[index++] = i;
    }
    //on tri de manière aléatoire
    images.sort(function (a, b) {
        return 0.5 - Math.random()
    });
    //dans la methode sort (compareTo) si return est négatif b est placé avant a
    // sinon a est placé avant b

    // on va affecté les images aux img
    mesImages = document.getElementsByClassName("plage");
    for (let i = 0; i < mesImages.length; i++) {
        mesImages[i].setAttribute("dataImage", images[i] + ".jpg");
        mesImages[i].addEventListener("click", clickImage);
    }
    mesImages = document.getElementsByClassName("plage");
    for (let i = 0; i < mesImages.length; i++) {
        afficheImage( mesImages[i],false);
    }
}

function clickImage(e) {
    nbImageSelectionne++;
    nbClick++;
    if (nbImageSelectionne < 3) //evite de traiter le cas declic sur 3 images
    {
        imageCliquee = e.target;
        afficheImage(imageCliquee, true);
        if (nbImageSelectionne == 1)
            // une seule a été sélectionné
            imagePrecedente = imageCliquee;
        else { //2 images selectionnées
            if (verifPair(imageCliquee, imagePrecedente)) { //les images forment une pair
                nbPairTrouvee++;
                imageCliquee.removeEventListener("click", clickImage);
                imagePrecedente.removeEventListener("click", clickImage);
                nbImageSelectionne = 0;
                zoneNbPairTrouvee.innerHTML = nbPairTrouvee;
            } else { //les images sont différentes
                setTimeout(function () {
                    afficheImage(imageCliquee, false);
                    afficheImage(imagePrecedente, false);
                    nbImageSelectionne = 0;
                }, 2000);

            }
           
        }
    }
    zoneNbClick.innerHTML = nbClick;
}

function solution() {
    mesImages = document.getElementsByClassName("plage");
    for (let i = 0; i < mesImages.length; i++) {
        mesImages[i].src = "Images/" + mesImages[i].getAttribute("dataImage");
    }
}

function afficheImage(image, recto) {
    if (recto)
        image.src = "Images/" + image.getAttribute("dataImage");
    else
        image.src = "Images/plage.jpg";
}

function verifPair(image1, image2) { //si les 2 images ont la meme dataImage, on renvoi vrai
    return (image1.getAttribute("dataImage") == image2.getAttribute("dataImage"));
}
