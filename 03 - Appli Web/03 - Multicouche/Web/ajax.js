
var contenu = document.querySelector(".contenu");
const requ = new XMLHttpRequest();
requ.open('POST', 'https://localhost:44398/api/Villes', true);
requ.setRequestHeader("Content-Type", "application/json; charset=utf-8");
requ.setRequestHeader("Accept","*/*");
requ.send();

requ.onreadystatechange = function(event) {
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            console.log("Réponse reçue: %s", this.responseText);;
            console.log(this.responseText);
            reponse=JSON.parse(this.responseText);
            
            
        } else {
            console.log("Status de la réponse: %d (%s)", this.status, this.statusText);
        }
    }
};
