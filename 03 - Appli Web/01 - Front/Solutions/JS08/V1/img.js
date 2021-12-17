photo=document.getElementById("image");
photo.addEventListener("click",ajoutPHoto)

//option1

// function ajoutPHoto()
// {
//        if (photo.alt=="feu") {
//            photo.src="uu.jpg";
//            photo.alt="uu";   
//        }
//        else{
//            photo.src="1.jpg";
//            photo.alt="feu";  
//        }
        
    
//  }

//option2


function ajoutPHoto()

{
    if (photo.alt=="feu") {
        photo.setAttribute("src","uu.jpg");
        photo.alt="recto"  
      }
      else if (photo.alt=="recto") {
        photo.setAttribute("src","1.jpg");
        photo.alt="feu"
      }
}

