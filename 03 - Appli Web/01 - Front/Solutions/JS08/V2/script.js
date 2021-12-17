var img = document.getElementById("Image")

img.addEventListener("click",retournerImage)

function retournerImage(){
    if(img.src=='http://127.0.0.1:5502/IMG/photo1.jpg'){
        img.src = 'http://127.0.0.1:5502/IMG/photo2.jpg';
        timer = setTimeout(retourner,3000)
    }else{
        img.src= 'http://127.0.0.1:5502/IMG/photo1.jpg';
        clearTimeout(timer)
    }
}

function retourner(){
    img.src = 'http://127.0.0.1:5502/IMG/photo1.jpg';
}