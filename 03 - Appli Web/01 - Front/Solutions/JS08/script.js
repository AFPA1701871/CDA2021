function deplace(dleft, dtop) {
    // permet de deplacer le carre selon 2 directions left et top
    //on recupere son style (tout le CSS)
    var styleCarre = window.getComputedStyle(carre, null);
    //on recupere les positions left et top actuelles
    var topActuel = styleCarre.top;
    var leftActuel = styleCarre.left;
    //on modifie les positions left et top actuelles
    carre.style.top = parseInt(topActuel) + dtop + 'px';
    carre.style.left = parseInt(leftActuel) + dleft + 'px';
}
//on recupere le carré 
var carre = document.getElementById('carre');
var left = document.getElementById("left");
var right = document.getElementById("right");
var up = document.getElementById("up");
var down = document.getElementById("down");

// avec les boutons de l'interface
left.addEventListener("click", function () {
    deplace(-5, 0);
});
right.addEventListener("click", function () {
    deplace(5, 0);
});
up.addEventListener("click", function () {
    deplace(0, -5);
});
down.addEventListener("click", function () {
    deplace(0, 5);
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

},);

//avec la souris
function deplaceSouris(e)
{
	//on deplace le carré en fonction de la position de la souris et de l'ecart du départ
    carre.style.top = parseInt(e.clientY) + ecartY + "px";
    carre.style.left = parseInt(e.clientX) + ecartX + "px";
};

var ecartY, ecartX;	// repère le décalage entre le coin suprieur du carré et la souris
var carre = document.getElementById('carre');
var flagMouv = false;

carre.addEventListener("mousedown", (e)=>
{
	// on repere l'ecart entre la souris et le haut du carré, pourgarder cet ecart pendant le déplacement
    ecartY = parseInt(window.getComputedStyle(carre).top) - parseInt(e.clientY);
    ecartX = parseInt(window.getComputedStyle(carre).left) - parseInt(e.clientX);
	// on autorise le déplacement
    flagMouv = true;
});

document.addEventListener("mousemove", (e) =>
{
	// on déplace si le mouvement est autorisé
    if(flagMouv == true)
    {
        deplaceSouris(e);
    }
});

carre.addEventListener("mouseup", (e) =>
{
	//on interdit le deplacement
    flagMouv = false;
});


