<?php
/************************Fonction ******************************************/
function demandeEntier(){ // Demande un entier à l'utilisateur
    do
    {
        do
        {
            $nombre = readline("Donnez le nombre d'attributs de la classe : ");
        } while (!is_numeric($nombre)); // on verifie que la chaine de caracterer ne contient que des chiffres
    } while (!is_int($nombre * 1)); // on vérifie que le nombre est entier (pas réel)
    return $nombre; //renvoi le nombre saisi
}

function affichageAttributs(Array $attributs){
    $att="";
    foreach($attributs as $elt){
        $att.="\n\t".'private $_'.$elt." ;";
    }
    return $att;
}

function creationSettersGetters(Array $attributs){
    $getSet="";
    foreach($attributs as $elt){
        $getSet.="\n\tpublic function get".ucfirst($elt).'()'
                    ."\n\t{"
                    ."\n\t\t".'return $this->_'.$elt.';'
                    ."\n\t}"
                    ."\n\n\tpublic function set".ucfirst($elt).'($'.$elt.')'
                    ."\n\t{"
                    ."\n\t\t".'$this->_'.$elt.' = $'.$elt.';'
                    ."\n\t}";
    }
    return $getSet;
}

function creationToString(Array $attributs){
    $toString='';
    foreach($attributs as $elt){
        $toString.='" '.$elt.' : ".$this->get'.ucfirst($elt).'()'."\t.";
    }
    $toString=substr($toString,0,strlen($toString)-1); //pour retirer le dernier point
    return $toString;
}

/************************Fin fonction ******************************************/

//Saisie utilisateur

$nomClasse=ucfirst(readline("Donnez le nom de la classe :"));
$nbAttributs=demandeEntier();
$attributs=[];
for($i=0;$i<$nbAttributs;$i++){
    $attribut=readline("Donnez le nom de l'attribut ");
    while(!ctype_alpha($attribut) || in_array($attribut,$attributs)){
        echo "Erreur de saisie\n";
        $attribut=readline("Donnez le nom de l'attribut ");
    }
    $attributs[]=$attribut;
}

//Création du fichier
$fp = fopen('./'.$nomClasse.'.Class.php', "w");

//Haut de page
$hautDePage='<?php'."\n\n".
            ' Class '.$nomClasse.' {';
fputs($fp,$hautDePage);

//Attributs
$pageAttributs="\n\t".'/***************************************** Attributs **********************************************/'.
                "\n".affichageAttributs($attributs)."\n";

fputs($fp,$pageAttributs);

//Getter Setters
$pageSettersGetters="\n\t".'/***************************************** Accesseurs **********************************************/'.
                    "\n\t".creationSettersGetters($attributs)
                    ."\n";

fputs($fp,$pageSettersGetters);

//Constructeur
$pageConstructeur="\n\t".'/***************************************** Constructeur **********************************************/'
                    ."\n\n\t".'public function __construct(array $options = [])'
                    ."\n\t{"
                    ."\n\t\t".'if (!empty($options)) // empty : renvoi vrai si le tableau est vide'
                    ."\n\t\t{"
                    ."\n\t\t\t".'$this->hydrate($options);'
                    ."\n\t\t}"
                    ."\n\t}"
                    ."\n\t".'public function hydrate($data)'
                    ."\n\t{"
                    ."\n\t\t".'foreach ($data as $key => $value)'
                    ."\n\t\t{"
                    ."\n\t\t\t".'$methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule'
                    ."\n\t\t\t".'if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe'
                    ."\n\t\t\t{"
                    ."\n\t\t\t\t".'$this->$methode($value);'
                    ."\n\t\t\t}"
                    ."\n\t\t}"
                    ."\n\t}"
                    ."\n";   

fputs($fp,$pageConstructeur);

//Methodes
//toString
$pageToString="\n\t".'/***************************************** Methode **********************************************/'
                ."\n\n\t".'/**'
                ."\n\t".'* Transforme l\'objet en chaine de caractères'
                ."\n\t".'*'
                ."\n\t".'* @return String'
                ."\n\t".'*/'
                ."\n\t".'public function toString(){'
                ."\n\t\t".'return '.creationToString($attributs).';'
                ."\n\t}"
                ."\n";


fputs($fp,$pageToString);

//equalsTo
$pageEqualsTo=   "\n\t".'/**'
                ."\n\t".'* Renvoi vrai si l\'objet en paramètre est égal à l\'objet appelant'
                ."\n\t".'*'
                ."\n\t".'* @param [type] obj'
                ."\n\t".'* @return bool'
                ."\n\t".'*/'
                ."\n\t".'public function equalsTo(){'
                ."\n\t\t".'return  "";'
                ."\n\t".'}'
                ."\n";

fputs($fp,$pageEqualsTo);

//compareTo
$pageCompareTo=  "\n\t".'/**'
                ."\n\t".'* Compare 2 objets'
                ."\n\t".'* Renvoi 1 si le 1er est >'
                ."\n\t".'*        0 si ils sont égaux'
                ."\n\t".'*        -1 si le 1er est <'
                ."\n\t".'*'
                ."\n\t".'* @param [type] obj1'
                ."\n\t".'* @param [type] obj2'
                ."\n\t".'* @return void'
                ."\n\t".'*/'
                ."\n\t".'public function compareTo(){'
                ."\n\t\t".'return "";'
                ."\n\t".'}'
                ."\n";
fputs($fp,$pageCompareTo);

//fin de classe
fputs($fp,"\n".'}');