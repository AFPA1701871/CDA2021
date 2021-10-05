<?php

class Produit
{
    /***************************************** Attributs **********************************************/

    private $_numero;
    private $_designation;
    private $_couleur;
    private $_dateDeValidite;
    private $_categorie;
    private $_lieuxStockage = [];
    private static $_compteur = 0;
    private $_prixHt;

    /***************************************** Accesseurs **********************************************/

    public function getNumero()
    {
        return $this->_numero;
    }

    public function setNumero($numero)
    {
        $this->_numero = $numero;
    }

    public function getDesignation()
    {
        return $this->_designation;
    }

    public function setDesignation($designation)
    {
        $this->_designation = $designation;
    }

    public function getCouleur()
    {
        return $this->_couleur;
    }

    public function setCouleur($couleur)
    {
        $this->_couleur = $couleur;
    }

    public function getDateDeValidite()
    {
        return $this->_dateDeValidite;
    }

    public function setDateDeValidite(DateTime $dateDeValidite)
    {
        $this->_dateDeValidite = $dateDeValidite;
    }

    public function getCategorie()
    {
        return $this->_categorie;
    }

    public function setCategorie(Categorie $categorie)
    {
        $this->_categorie = $categorie;
    }

    public function getLieuxStockage()
    {
        return $this->_lieuxStockage;
    }

    public function setLieuxStockage(array $lieuxStockage)
    {
        $this->_lieuxStockage = $lieuxStockage;
    }

    public static function getCompteur()
    {
        return self::$_compteur;
    }

    public static function setCompteur($compteur)
    {
        self::$_compteur = $compteur;
    }

    public function getPrixHt()
    {
        return $this->_prixHt;
    }

    public function setPrixHt($prixHt)
    {
        $this->_prixHt = $prixHt;
    }

    /***************************************** Constructeur **********************************************/

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

    /***************************************** Methode **********************************************/

    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return "\n Numero : " . $this->getNumero() . " Designation : " . $this->getDesignation() . " Couleur : " . $this->getCouleur() . " DateDeValidite : " . $this->getDateDeValidite()->format('d m Y') . "\n Categorie : " . $this->getCategorie()->toString() . "\n LieuxStockage : " . $this->renvoiLieuxStockage() . " PrixHt : " . $this->getPrixHt() . "\n";
    }

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] obj
     * @return bool
     */
    public function equalsTo()
    {
        return "";
    }

    /**
     * Compare 2 objets
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] obj1
     * @param [type] obj2
     * @return void
     */
    public static function compareTo(Produit $p1, Produit $p2)
    {
        $comp = Categorie::compareTo($p1->getCategorie(), $p2->getCategorie());
        if ($comp == 0)
        {
            if ($p1->getDesignation() > $p2->getDesignation())
            {
                return 1;
            }
            else if ($p1->getDesignation() < $p2->getDesignation())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return $comp;
        }

    }

    private function renvoiLieuxStockage()
    {
        $aff = "";
        foreach ($this->getLieuxStockage() as $lieu)
        {
            $aff .= $lieu->toString();
        }
        return $aff;
    }
    public function estPerime() //Méthode qui calcule si oui ou non un produit est périmé
    {
        $date = new DateTime('now');
        if ($this->getDateDeValidite() > $date)
        {
            return false;
        }
        return true;

        // return !($this->getDateDeValidite() > new DateTime('now'));
    }
    /**
     * On ajoute un lieu de stockage
     *
     * @param LieuDeStockage $lieu
     * @return void
     */
    public function entreeEnStock(LieuDeStockage $lieu)
    {
        $lieux = $this->getLieuxStockage();
        $lieux[] = $lieu;
        $this->setLieuxStockage($lieux);
    }

    public function prixTTC()
    {
        return $this->getPrixHT() + ($this->getPrixHT() * ($this->getCategorie()->getTva() / 100));
    }
}
