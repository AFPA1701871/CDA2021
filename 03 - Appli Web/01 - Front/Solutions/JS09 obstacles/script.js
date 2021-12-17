function deplace(dx, dy) {
    var deplacement_ok = true;
    var styleCarre = window.getComputedStyle(document.getElementById('carre'), null);
    var t = parseInt(styleCarre.top);
    var l = parseInt(styleCarre.left);
    var w = parseInt(styleCarre.width);
    var h = parseInt(styleCarre.height);
    var listeObs = document.querySelectorAll('.obstacle');
    listeObs.forEach(function (elt) {
        var styleObst = window.getComputedStyle(elt, null);
        var tob = parseInt(styleObst.top);
        var lob = parseInt(styleObst.left);
        var wob = parseInt(styleObst.width);
        var hob = parseInt(styleObst.height);
        if (!depl_ok(tob, lob, wob, hob, t + dy, l + dx, w, h)) {
            compteurCollision++;
            console.log("collision n°" + compteurCollision + "  " + elt.id);
        }
        deplacement_ok = deplacement_ok && depl_ok(tob, lob, wob, hob, t + dy, l + dx, w, h);

    });
    if (deplacement_ok) {
        document.getElementById('carre').style.top = t + dy + 'px';
        document.getElementById('carre').style.left = l + dx + 'px';
    }
}
/**
 * Détermine s'il y a collision
 * @param {*} tob top obstacle
 * @param {*} lob left  obstacle
 * @param {*} wob width obstacle
 * @param {*} hob height  obstacle
 * @param {*} t top carre
 * @param {*} l left carre
 * @param {*} w width carre
 * @param {*} h heigth carre
 * @returns 
 */
function depl_ok(tob, lob, wob, hob, t, l, w, h) {
    if (l < lob + wob && l + w > lob && t < tob + hob && t + h > tob) {
        return false
    }
    return true;
}

var ecartY, ecartX; // repère le décalage entre le coin suprieur du carré et la souris
var carre = document.getElementById('carre');
var flagMouv = false;
var compteurCollision = 0;

carre.addEventListener("mousedown", (e) => {
    // on repere l'ecart entre la souris et le haut du carré, pourgarder cet ecart pendant le déplacement
    ecartY = parseInt(window.getComputedStyle(carre).top) - parseInt(e.clientY);
    ecartX = parseInt(window.getComputedStyle(carre).left) - parseInt(e.clientX);
    // on autorise le déplacement
    flagMouv = true;
});

document.addEventListener("mousemove", (e) => {
    // on déplace si le mouvement est autorisé
    if (flagMouv == true) {
        deplaceSouris(e);
    }
});
document.addEventListener("click", (e) => {
    console.log("X " + e.clientX);
    console.log("Y " + e.clientY);
});


carre.addEventListener("mouseup", (e) => {
    //on interdit le deplacement
    flagMouv = false;
});

//avec les touches du clavier

window.addEventListener("keydown", function (event) {

    switch (event.key) {
        case "ArrowDown":
            deplace(0, 5);
            break;
        case "ArrowUp":
            deplace(0, -5);
            break;
        case "ArrowLeft":
            deplace(-5, 0);
            break;
        case "ArrowRight":
            deplace(5, 0);
    }

});


function deplaceSouris(e) {
    if (!collisionObstacles(parseInt(e.clientY) + ecartY, parseInt(e.clientX) + ecartX)) {
       // on deplace le carré en fonction de la position de la souris et de l'ecart du départ
        carre.style.top = parseInt(e.clientY) + ecartY + "px";
        carre.style.left = parseInt(e.clientX) + ecartX + "px";
    }
};
//Gestion des collisions
/**
 * Méthode qui renvoi vrai s'il y a une collision avec l'obstacle
 * @param {*} obstacle //obstacle fixe
 * @param {*} posX //position en x souhaité
 * @param {*} posY //position en y souhaité
 */
function collisionUnObstacle(obstacle, posX, posY) {
    var styleObjet = window.getComputedStyle(carre);
    var w = parseInt(styleObjet.width);
    var h = parseInt(styleObjet.height);
    var styleObstacle = window.getComputedStyle(obstacle);
    var tob = parseInt(styleObstacle.top);
    var lob = parseInt(styleObstacle.left);
    var wob = parseInt(styleObstacle.width);
    var hob = parseInt(styleObstacle.height);
    if (posY < lob + wob && posY + w > lob && posX < tob + hob && posX + h > tob) {
        console.log("collision n°" + compteurCollision + "  " + obstacle.id);
        flagMouv = false;
        compteurCollision++;
        return true;
    }
    return false;
}

/**
 * Méthode qui renvoi vrai s'il y a une collision avec l'un des obstacles
 * @param {*} posX //position en x souhaité
 * @param {*} posY //position en y souhaité
 */
function collisionObstacles(posX, posY) {
    var pasCollision = true;
    var listeObstacles = document.querySelectorAll('.obstacle');
    //on teste pour chacun des obstacles
    listeObstacles.forEach(function (obstacle) {
        pasCollision = pasCollision && !collisionUnObstacle(obstacle, posX, posY);
    });
    return !pasCollision;
}