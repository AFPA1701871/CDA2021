<?php
echo "*********************************************\n";
echo "*****           JSON                *********\n";
echo "*********************************************\n";

/**** tableau simple */
echo "\n\n ***** tableau simple   *****\n";
$tabSimple = array( 1,  2,  3,  4, 5);
echo json_encode($tabSimple);

/**** tableau associatif */
echo "\n\n ***** tableau associatif   *****\n";
$tabAssoc = array('a' => 1, 'b' => 2, 'c' => 3, 'd' => 4, 'e' => 5);
echo json_encode($tabAssoc);

/**** Objet public */

echo "\n\n ***** objet public   *****\n";
require "Personne.Class.php";

$p1 = new Personne("Dupond","Toto");

var_dump($p1);
var_dump (json_encode($p1));


/**** Objet privé */

echo "\n\n ***** objet privé   *****\n";

require "Voiture.Class.php";

$v1 = new Voiture(["marque"=>"Audi","modele"=>"A3","immatriculation"=>"12df12f","couleur"=>"noire","kilometres"=>20000]);
var_dump($v1);
var_dump (json_encode($v1));

echo "\n\n\n\n";
echo "*********************************************\n";
echo "*****           XML                 *********\n";
echo "*********************************************\n";

/**** tableau simple */
echo "\n\n ***** tableau simple   *****\n";
echo xmlrpc_encode($tabSimple);

/**** tableau associatif */
echo "\n\n ***** tableau associatif   *****\n";
echo xmlrpc_encode($tabAssoc);

/**** Objet public */

echo "\n\n ***** objet public   *****\n";
var_dump (xmlrpc_encode($p1));


/**** Objet privé */
echo "\n\n ***** objet privé   *****\n";
require "Voiture2.Class.php";

$v2 = new Voiture2(["marque"=>"Audi","modele"=>"A3","immatriculation"=>"12df12f","couleur"=>"noire","kilometres"=>20000]);
var_dump($v2);
var_dump(Voiture2::XMLEncode($v2));
var_dump(xmlrpc_encode(Voiture2::XMLEncode($v2)));
