inputFile = document.querySelector("input[type=file]");
img = inputFile.parentNode.parentNode.querySelector("img")
if (inputFile!=undefined)
{
    inputFile.addEventListener("change", choixImage);
}

function choixImage(e) {
    if (inputFile.value.length > 0) {
        imageType = /^image\//;
        fichier = e.target.files[0];
        if (!imageType.test(fichier.type)) {
            alert("veuillez sélectionner une image");
            e.target.value = "";
        } else {
            img.file = fichier;
            reader = new FileReader();
            reader.addEventListener("load", chargeImage);
            reader.readAsDataURL(img.file);
            // on crée un nouvel input pour dire qu'il y a modification
            modif = document.createElement("input");
            modif.name = "modifImage";
            modif.type = "hidden";
            inputFile.parentNode.appendChild(modif);
        }
    }
}

function chargeImage(e) {
    img.src = e.target.result;
}
