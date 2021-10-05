<?php

class Cercle
{

    /*****************Attributs***************** */
    private $_diametre;

    /*****************Accesseurs***************** */
    public function getDiametre()
    {
        return $this->_diametre;
    }

    public function setDiametre($diametre)
    {
        $this->_diametre = $diametre;
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
        return "\nDiametre :".$this->getDiametre()."\tRayon :".($this->getDiametre()/2)."\tPerimetre :".$this->perimetre()."\tAire :".$this->aire();
    }

    public function perimetre()
    {   //pi D
        return pi()*$this->getDiametre();
    }

    public function aire()
    {   //pi R²
        return pi()*(pow($this->getDiametre()/2,2));
    }
    
}