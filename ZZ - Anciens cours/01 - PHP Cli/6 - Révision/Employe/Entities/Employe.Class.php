<?php

class Employe
{

    /*****************Attributs***************** */
    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_fonction;
    private $_salaire;
    private $_service;
    private static $_compteur = 0;
    private $_agence;
    private $_listeEnfants = [];

    /*****************Accesseurs***************** */

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getDateEmbauche()
    {
        return $this->_dateEmbauche;
    }

    public function setDateEmbauche($dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getFonction()
    {
        return $this->_fonction;
    }

    public function setFonction($fonction)
    {
        $this->_fonction = $fonction;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
    }
    public static function getCompteur()
    {
        return self::$_compteur;
    }
    public function getAgence()
    {
        return $this->_agence;
    }
    /* on force le paramètre $agence a être de type Agence*/
    public function setAgence(Agence $agence)
    {
        $this->_agence = $agence;
    }

    public function getListeEnfants()
    {
        return $this->_listeEnfants;
    }

    public function setListeEnfants(array $listeEnfants)
    {
        $this->_listeEnfants = $listeEnfants;
    }
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        self::$_compteur++;
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
        $aff = "\n\n*** SALARIE ***\n";
        $aff .= "Nom :" . $this->getNom() . "\nPrenom :" . $this->getPrenom() . "\nDateEmbauche :" . $this->getDateEmbauche()->format('Y-m-d') . "\nPosteEntreprise :" . $this->getFonction() . "\nSalaire annuel :" . $this->getSalaire() . "K€\nService :" . $this->getService() . "\n";

        $aff .= "Il reçoit une prime de " . $this->prime() . "K€\n";
        // if ($this->recoitChequeVacances())
        // {
        //     $aff .= "Il est éligible aux chèques vacances \n";
        // }
        $aff .= ($this->recoitChequeVacances()) ? "Il est éligible aux chèques vacances \n" : "";
        $aff .= "Il travaille dans l'agence : " . $this->getAgence()->toString() . "\n";
        switch (count($this->getListeEnfants()))
        {
            case '0':break;
            case '1':$aff .= "Son enfant est : \n";
                $aff .= $this->getListeEnfants()[0]->toString();
                break;

            default:
                $aff .= "Ses enfants sont : \n";
                foreach ($this->getListeEnfants() as $enf)
                {
                    $aff .= $enf->toString();
                }
                break;
        }
        $aff .= $this->chequeNoel();
        return $aff;
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
     * @return int
     */
    public static function compareTo($obj1, $obj2)
    {
        if ($obj1->getNom() > $obj2->getNom())
        {
            return 1;
        }
        else if ($obj1->getNom() < $obj2->getNom())
        {
            return -1;
        }
        else if ($obj1->getPrenom() > $obj2->getPrenom())
        {
            return 1;
        }
        else if ($obj1->getPrenom() < $obj2->getPrenom())
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    /* comparaison avec concaténation*/
    public static function compareTo2($obj1, $obj2)
    {
        $obja = $obj1->getNom() . $obj1->getPrenom();
        $objb = $obj2->getNom() . $obj2->getPrenom();
        if ($obja > $objb)
        {
            return 1;
        }
        if ($obja < $objb)
        {
            return -1;
        }
        return 0;

    }

    public static function compareToService($obj1, $obj2)
    {
        if ($obj1->getService() > $obj2->getService())
        {
            return 1;
        }
        else if ($obj1->getService() < $obj2->getService())
        {
            return -1;
        }
        else
        { // si les services sont les mêmes, on rappele la fonction de tri par Nom Prenom
            return self::compareTo($obj1, $obj2);
        }
    }

/**
 * calcul l'anciennete en année
 *
 * @return int  nb d'année d'ancienneté
 */
    private function anciennete()
    {
        $dateJour = new DateTime("NOW");
        $diff = $dateJour->diff($this->getDateEmbauche());
        return $diff->format("%y");
    }

    /**
     * fonction qui calcul la prime globale
     *
     * @return int renvoi le montant de la prime
     */
    public function prime()
    {
        /* calcul prime sur salaire */
        $primeS = $this->primeSalaire();
        /* calcul prime sur ancienneté */
        $primeA = $this->primeAnciennete();
        return $primeS + $primeA;
    }
/**
 * applique 5% du salaire
 *
 * @return int  montant de la prime
 */
    public function primeSalaire()
    {
        return $this->getSalaire() * 0.05;
    }
/**
 * prime de 2% du salaire par annee d'ancienneté
 *
 * @return int montant de la prime
 */
    public function primeAnciennete()
    {
        return $this->getSalaire() * 0.02 * $this->anciennete();
    }

/**
 * Calcul de la masse salariale de l'employe
 *
 * @return float salaire + prime
 */
    public function masseSalariale()
    {
        return $this->getSalaire() + $this->prime();
    }

    /**
     *
     * verifie si l'employé est eligible aux cheques vacances
     *
     * @return string true ou false selon si l'employé est eligible ou pas
     */
    public function recoitChequeVacances()
    {
        // if ($this->anciennete() >= 1)
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }

        return ($this->anciennete() >= 1); // on verifie par rapport a l'anciennete si l employé est dans l'entreprise depuis plus d'un an
    }

    public function chequeNoel()
    {
        $listeCheque = ["0" => 0, "20" => 0, "30" => 0, "50" => 0]; // tableau qui va contenir le nombre de cheque par montant
        if (count($this->getListeEnfants()) > 0)
        {
            foreach ($this->getListeEnfants() as $enf)
            {
                $valeurCheque = $enf->chequeNoel(); // valeur du cheque pour l'enfant
                $listeCheque[$valeurCheque]++; // on augmente le nombre de cheque de cette valeur
            }
        }
        $listeCheque[0] = 0; // pour eviter de demander des cheques de 0
        $nbCheque = array_sum($listeCheque); // nb de cheque a editer
        if ($nbCheque > 0)
        {
            $aff = "\nIl a droit à des chèques de Noel réparti comme suit : \n";
            foreach ($listeCheque as $key => $value)
            {
                $aff .= ($value > 0) ? "\t " . $value . " chèque(s) de " . $key . "\n" : "";
            }
        }
        else
        {
            $aff = "\nIl n'a pas le droit à des chèques de Noel \n";

        }
        return $aff;
    }
}
