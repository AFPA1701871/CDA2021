<?php

class Personne
{
    //Attributs
    private $_nom;
    private $_prenom;
    private $_voiture;

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
    public function getVoiture()
    {
        return $this->_voiture;
    }

    public function setVoiture(Voiture $v)
    {
        $this->_voiture = $v;
    }

    //constructeur
    public function __construct(String $n,String $p,Voiture $v)
    {
        $this->setNom($n);
        $this->setPrenom($p);
        $this->setVoiture($v);
    }
    //Autres méthodes
    public function toString()
    {
        return "La personne est $this->getNom()  $this->getPrenom()";
    }

    public function equalsTo(Personne $obj) //on précise la classe Personne pour préciser le type de la variable attendue
    {
        return ($this->getNom()==$obj->getNom() && $this->getPrenom()==$obj->getPrenom());
    }

    public function compareTo(Personne $obj)
    {
        if ($this->getNom()>$obj->getNom())
        {
            return 1;
        }
        else if ($this->getNom()<$obj->getNom())
        {
            return -1;
        }
        else    // égalité sur les noms
        {
            if ($this->getPrenom()>$obj->getPrenom())
            {
                return 1;
            }
            else if ($this->getPrenom()<$obj->getPrenom())
            {
                return -1;
            }
            else
            {   // égalité sur les personnes
                return 0;
            }
        } 
    }

    
}