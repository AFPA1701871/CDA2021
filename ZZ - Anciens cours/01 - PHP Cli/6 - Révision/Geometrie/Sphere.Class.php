<?php

class Sphere extends Cercle
{

    /*****************Attributs***************** */
    

    /*****************Accesseurs***************** */

    
    /*****************Constructeur***************** */


    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return parent::toString()." - Volume de la sphère : ".$this->volumeSphere();
    }

    /**
     * Retourne le volume de la sphere
     *
     * @param Void
     * @return Float
     */
    public function volumeSphere()
    {       // 4/3 PI R3
        return number_format(((pow(parent::getDiametre()/2,3)*pi()*4)/3),2);
    }


    
}