<?php
class Triangle
{

    /*****************Attributs***************** */
    private $_base;
    private $_hauteur;

    /*****************Accesseurs***************** */
    public function getBase()
    {
        return $this->_base;
    }

    public function setBase($base)
    {
        $this->_base = $base;
    }
    public function getHauteur()
    {
        return $this->_hauteur;
    }

    public function setHauteur($hauteur)
    {
        $this->_hauteur = $hauteur;
    }    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return "Base : ".$this->getBase().", Hauteur : ".$this->getHauteur().", Perimetre : ".$this->perimetre(). " Aire : ".$this->aire();
    }

    public function perimetre()
    {
        $hypothenuse = sqrt(pow($this->getBase(), 2) + pow($this->getHauteur(), 2)); //3eme coté du triangle rectangle : Pythagore
        $perimetre = $this->getBase() +$this->getHauteur() + $hypothenuse;
        return $perimetre;
    }
    public function aire()
    {
        return $this->getBase() * $this->getHauteur() /2; 
    }
    
}