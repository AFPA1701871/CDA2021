<?php

class Pave extends Rectangle
{

    /*****************Attributs***************** */
    private $_hauteur;

    /*****************Accesseurs***************** */

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
        parent::__construct($options);
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
        return parent::toString()." - Hauteur : ".$this->getHauteur()." - Volume : ".$this->volumePave()." - Perimetre : ".$this->perimetrePave()."\n";
    }

    /**
     * Renvoi le perimetre du pave
     *
     * @param Void
     * @return Float
     */
    public function perimetrePave()
    {
        return ((parent::perimetre()*2)+($this->getHauteur()*4));
    }

    /**
     * Renvoi l'aire du pave
     *
     * @param Void
     * @return Float
     */
    public function volumePave()
    {
        return parent::aire()*$this->getHauteur();
    }

    
}