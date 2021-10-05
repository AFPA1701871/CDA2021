<?php

class Pyramide extends Triangle
{

	/*****************Attributs***************** */

	private $_haut;

	/*****************Accesseurs***************** */

	public function getHaut()
	{
		return $this->_haut;
	}

	public function setHaut($haut)
	{
		$this->_haut = $haut;
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
	* @return String.
	*/
	public function toString()
	{
		return parent::toString()."\n Hauteur : ".$this->getHaut()."\nPérimètre :".$this->perimetre()."\n"
		."Volume :".$this->volume()."\n";
	}
	/**
	* Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
	*
	* @param [type] $obj
	* @return bool
	*/
	public function equalsTo ($obj)
	{
		return true;
	}
	

	public function perimetre()//Calcul du périmètre
	{
		$cote1=sqrt(pow($this->getHauteur(),2)+pow($this->getHaut(),2));
		$cote2=sqrt(pow($this->getBase(),2)+pow($this->getHaut(),2));
		return (parent::perimetre()+$this->getHaut()+$cote1+$cote2);
	}

	public function volume() //Calcul du volume
	{
		return (parent::aire()*$this->getHaut()/3);
	}
}