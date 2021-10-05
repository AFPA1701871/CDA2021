<?php
function ChargerClasse($classe)
{
    require "../Entities/".$classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

/**
 * Appel la fonction toString sur chaque élément du tableau
 *
 * @param [type] $tab tableau à afficher
 * @return void
 */
function afficheTableau($tab)
{
    for ($i=0; $i < count($tab); $i++) { 
            echo $tab[$i]->toString();
    }
}


$enf= new Enfant(["nomEnfant"=>"DUPONT", "prenomEnfant"=>"toto","dateNaissance"=>new DateTime("2006-01-02")]);
echo $enf->toString();
$enf1= new Enfant(["nomEnfant"=>"Austin", "prenomEnfant"=>"test","dateNaissance"=>new DateTime("2015-01-02")]);
echo $enf->toString();
$enf2= new Enfant(["nomEnfant"=>"Base", "prenomEnfant"=>"test","dateNaissance"=>new DateTime("1999-01-02")]);
echo $enf->toString();
$listeAgences[]=new Agence(["nomAgence"=>"Darty","adresse"=>"12 rue des champignons","modeRestauration"=>"restaurant d'entreprise"]);
$listeAgences[]=new Agence(["nomAgence"=>"Victor","adresse"=>"21 rue des Victor Hugo","modeRestauration"=>"ticket restauration"]);

$listeEmployes[] = new Employe(["nom"=>"Dupond","prenom"=>"toto", "dateEmbauche"=>new DateTime("2021-01-01"),"fonction"=>"employe","salaire"=>12, "service"=>"compta","agence"=>$listeAgences[0],"listeEnfants"=>[$enf]]);
$listeEmployes[] = new Employe(["nom"=>"Dupond","prenom"=>"tata", "dateEmbauche"=>new DateTime("2014-01-01"),"fonction"=>"employee","salaire"=>10, "service"=>"rh","agence"=>$listeAgences[0],"listeEnfants"=>[$enf,$enf1]]);
$listeEmployes[] = new Employe(["nom"=>"Austin","prenom"=>"truc", "dateEmbauche"=>new DateTime("2015-05-01"),"fonction"=>"employe","salaire"=>12, "service"=>"compta","agence"=>$listeAgences[1],"listeEnfants"=>[$enf1]]);
$listeEmployes[] = new Employe(["nom"=>"Zoro","prenom"=>"zoro", "dateEmbauche"=>new DateTime("2020-01-01"),"fonction"=>"chef","salaire"=>18, "service"=>"rh"]);
$listeEmployes[] = new Employe(["nom"=>"Base","prenom"=>"basil", "dateEmbauche"=>new DateTime("2015-01-01"),"fonction"=>"chef","salaire"=>17, "service"=>"compta","listeEnfants"=>[$enf2]]);

// Afficher le nombre d'employés
// echo "Le nombre d'employés est de ".count($listeEmployes)."\n";
/* ou en utilisant un compteur */
// echo Employe::getCompteur()."\n";
// echo "avant le tri \n";
// afficheTableau($listeEmployes);
/* On utilise la fonction Usort pour trier le tableau
    Le 1er parametre est le tableau à trier
    Le 2eme, la fonction qui permet le tri
    Pour la fonction, on précise la classe et le nom de la fonction */
// usort($listeEmployes,array("Employe","compareTo"));
// echo "après le tri \n";
// afficheTableau($listeEmployes);

/* Calcul de la masse salariale totale */
// $masseSalarialeTotale =0;
// foreach($listeEmployes as $employe)
// {
//     $masseSalarialeTotale += $employe->masseSalariale();
// }
// echo "la masse salariale totale est de $masseSalarialeTotale \n";

// /* Création d'agence et affectation après la création de l'employe*/
$a1 = new Agence(["nomAgence"=>"apres"]);
$listeEmployes[3]->setAgence($a1);
$listeEmployes[4]->setAgence($a1);
afficheTableau($listeEmployes);

