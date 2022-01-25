const requ = new XMLHttpRequest();

tab={"un":1,
"deux":2,
"three":3};
requ.open('POST', 'index.php?page=API', true);
        requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        var args = "toto="+JSON.stringify(tab)+"&categ=1";
        requ.send(args);

requ.onreadystatechange = function(event) {
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            console.log("Réponse reçue: %s", this.responseText);;
            reponse=JSON.parse(this.responseText); 
            console.log(reponse);
            document.getElementById("select").innerHTML=reponse;
        } else {
            console.log("Status de la réponse: %d (%s)", this.status, this.statusText);
        }
    }
};
