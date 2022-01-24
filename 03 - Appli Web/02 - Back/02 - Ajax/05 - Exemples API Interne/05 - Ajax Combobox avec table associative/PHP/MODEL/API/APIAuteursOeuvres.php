<?php
$id = $_POST['idAuteur'];

// La vue permet de récupérer les oeuvres d'un auteur
echo json_encode( AuteursOeuvresManager::getListByAuteur($id,true));
// var_dump($listeDepartement);

// sans vue on aurait du faire

//on recupere la liste des creations 
// $listeCreations = CreationsManager::getListByAuteur($id, false);
// //on transforme les objets en une liste d'idOeuvre
// $listeIdOeuvres = "(";
// foreach ($listeCreations as $value) {
//     $listeIdOeuvres .= $value->getIdOeuvre().",";
// }
// //on enleve la derniere , et on ajoute )
// $listeIdOeuvres = substr($listeIdOeuvres,0,strlen($listeIdOeuvres)-1);
// $listeIdOeuvres .=")";
// //on recupere les oeuvre pour envoyer à l'API
// $listeOeuvres = OeuvresManager::getListbyId($listeIdOeuvres,true);
// echo json_encode($listeOeuvres);
?>