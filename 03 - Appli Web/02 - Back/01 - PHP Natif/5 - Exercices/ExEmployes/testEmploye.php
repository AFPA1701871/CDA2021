<?php
include "employes.php";
include "agences.php";


$a1 = new Agences(["Nom" => "tutu", "adresse" => "12 rue toto","modeRestauration" => "restaurant d'entreprise" ,"codePostal" => "59520" , "ville" => "Lille"]);
$a2 = new Agences(["Nom" => "toto", "adresse" => "154 rue tata","modeRestauration" =>"ticket restaurant" ,"codePostal" => "62102", "ville" => "Lens"]);
$a3 = new Agences(["Nom" => "tata", "adresse" => "132 rue tutu","modeRestauration" =>"restaurant d'entreprise" ,"codePostal" => "52013", "ville" => "Marseille"]);

$e[] = new Employes(["Nom" => "Aarouss", "Prenom" => "Sofiane", "dateEmbauche" => new DateTime("01-12-2000"), "fonction" => "Eleveur de punaise", "salaireAnnuel" => "14", "Service" => "Nettoyage","agence"=>$a1]);
$e[] = new Employes(["Nom" => "Courquin", "Prenom" => "Pierre", "dateEmbauche" => new DateTime("12-03-2006"), "fonction" => "Gynecologue", "salaireAnnuel" => "40", "Service" => "Medecine","agence"=>$a2]);
$e[] = new Employes(["Nom" => "Rjeb", "Prenom" => "Zied", "dateEmbauche" => new DateTime("15-09-2015"), "fonction" => "Kebabiste", "salaireAnnuel" => "30", "Service" => "Restauration","agence"=>$a2]);
$e[] = new Employes(["Nom" => "Balair", "Prenom" => "Quentin", "dateEmbauche" => new DateTime("03-03-2003"), "fonction" => "Plaquiste", "salaireAnnuel" => "20", "Service" => "batiment","agence"=>$a1]);
$e[] = new Employes(["Nom" => "Cugny", "Prenom" => "Maxime", "dateEmbauche" => new DateTime("27-08-2007"), "fonction" => "Homme de menage", "salaireAnnuel" => "50", "Service" => "Nettoyage","agence"=>$a1]);

echo 'Il y a ' . count($e) . ' employés dans l\'entreprise';

echo '<div>Avant Tri</div>';
foreach ($e as $key => $value) {
    echo '<div>' . $value->toString();
    echo '  prime : ' . $value->primeAnnuelle() . '</div>';
}
usort($e, array("Employes", "compareToServiceNomPrenom"));

echo '<div>Apres Tri</div>';
$masseSalarialeTotale = 0;
foreach ($e as $key => $value) {
    echo '<div>' . $value->toString();
    echo '  prime : ' . $value->primeAnnuelle() . '</div>';
    $masseSalarialeTotale += $value->masseSalariale();
}

echo '<div>La masse salariale est de ' . $masseSalarialeTotale . 'K€ </div>';
