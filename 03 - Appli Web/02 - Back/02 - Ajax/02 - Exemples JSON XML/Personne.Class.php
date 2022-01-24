<?php

class Personne
{
    //Attributs
    public $_nom;
    public $_prenom;

    // assesseurs
    public function getNom()
    {
        return $this->_nom;
    }
    public function setNom($n)
    {
        $this->_nom=strtoupper($n);
    }
    public function getPrenom()
    {
        return $this->_prenom;
    }
    public function setPrenom($p)
    {
        $this->_prenom=ucfirst($p);
    }
   
    //constructeur
    public function __construct(String $n,String $p)
    {
        $this->setNom($n);
        $this->setPrenom($p);
    }
    //Autres méthodes
    public function toString()
    {
        return "La personne est $this->getNom()  $this->getPrenom()";
    }
}