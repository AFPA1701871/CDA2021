<?php

class Regions
{
	/*****************Attributs***************** */
	private $_idRegion;
	private $_libelleRegion;
	/*****************Accesseurs***************** */
	public function getIdRegion()
	{
		return $this->_idRegion;
	}

	public function setIdRegion($idRegion)
	{
		return $this->_idRegion = $idRegion;
	}

	public function getLibelleRegion()
	{
		return $this->_libelleRegion;
	}

	public function setLibelleRegion($libelleRegion)
	{
		return $this->_libelleRegion = $libelleRegion;
	}

	/*****************Constructeur***************** */

	 public function __construct(array $options = [])
	{		if (!empty($options)) // empty : renvoi vrai si le tableau est vide
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
	* Transforme l objet en chaine de caractères
	*
	* @return String
	*/
	public function toString()
	{
		return "IdRegion : ".$this->getIdRegion()."LibelleRegion : ".$this->getLibelleRegion();	
}

}