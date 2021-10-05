<?php
class Enfant
{

    /*****************Attributs***************** */
    private $_nomEnfant;
    private $_prenomEnfant;
    private $_dateNaissance;

    /*****************Accesseurs***************** */

    public function getNomEnfant()
    {
        return $this->_nomEnfant;
    }

    public function setNomEnfant($nomEnfant)
    {
        $this->_nomEnfant = $nomEnfant;
    }

    public function getPrenomEnfant()
    {
        return $this->_prenomEnfant;
    }

    public function setPrenomEnfant($prenomEnfant)
    {
        $this->_prenomEnfant = $prenomEnfant;
    }

    public function getDateNaissance()
    {
        return $this->_dateNaissance;
    }

    public function setDateNaissance(DateTime $dateNaissance)
    {
        $this->_dateNaissance = $dateNaissance;
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
        return "\n\t Nom de l'enfant : " . $this->getNomEnfant() . "\n\t prénom : " . $this->getPrenomEnfant() . "\n\t Date de Naissance  : " . $this->getDateNaissance()->format("d-m-Y") . "\n\t age : " . $this->age();
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
    /**
     * retourne l'age de l'enfant
     *
     * @return int age en année
     */
    public function age()
    {
        $age = date_diff(new DateTime("NOW"), $this->getDateNaissance());
        return $age->format("%y");
    }
/**
 * renvoi la valeur du cheque noel lié à l'enfant
 *
 * @return int  valeur du cheque Noel , 0 sinon
 */
    public function chequeNoel()
    {
        $ageEnfant = $this->age();
        if ( $ageEnfant < 0 || $ageEnfant>18 )
        {
            return 0;
        }
        else if ($ageEnfant<11)
        {
            return 20;
        }
        else if ($ageEnfant<16)
        {
            return 30;
        }
        return 50;
        
    }
}
