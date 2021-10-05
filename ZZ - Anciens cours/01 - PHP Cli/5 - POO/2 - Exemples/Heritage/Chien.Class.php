<?php

class Chien extends Animal
{

    /*****************Attributs***************** */
    private $_puce;

    /*****************Accesseurs***************** */
    public function getPuce()
    {
        return $this->_puce;
    }

    public function setPuce($puce)
    {
        $this->_puce = $puce;
    }

    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        parent::__construct($options);  // on appelle le construct de la mère pour "ranger" les attributs correspondants
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
        return "\n Chien  : ".$this->getNom(). " ".$this->getRace(). " " . $this->getPuce();
    }

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] $obj
     * @return bool
     */
    public function equalsTo($obj)
    {
        return true;
    }
    /**
     * Compare 2 objets
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareTo($obj1, $obj2)
    {
        return 0;
    }

    public function Crier() //surcharge
    {
        echo "il aboie";
    }

}
