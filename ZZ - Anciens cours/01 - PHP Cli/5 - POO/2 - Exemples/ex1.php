<?php

Class Voiture
{
    //Attributs
    private $_marque;
    private $_modele;
    private $_km;

    //Constructeur
    public function __construct()
    {

    }

    //Assesseurs

    //GETTER
    public function getMarque()
    {
        return $this->_marque;
    }
    public function getModele()
    {
        return $this->_modele;
    }
    public function getKm()
    {
        return $this->_km;
    }

    // SETTER
    public function setMarque($m)
    {
        $this->_marque = $m;
    }
    public function setModele($m)
    {
        $this->_modele = $m;
    }
    public function setKm($km)
    {
        $this->_km = $km;
    }
}
$a="toto";
var_dump($a);
$v1=new Voiture();
var_dump($v1);
$v1->setMarque("Audi");
var_dump($v1);
echo $v1->getMarque();

