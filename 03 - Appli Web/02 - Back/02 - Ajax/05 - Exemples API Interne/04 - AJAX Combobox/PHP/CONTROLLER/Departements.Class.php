<?php

class Departements
{
	/*****************Attributs***************** */
	private $_idDepartement;
	private $_libelleDepartement;
	private $_idRegion;
	/*****************Accesseurs***************** */
	public function getIdDepartement()
	{
		return $this->_idDepartement;
	}

	public function setIdDepartement($idDepartement)
	{
		return $this->_idDepartement = $idDepartement;
	}

	public function getLibelleDepartement()
	{
		return $this->_libelleDepartement;
	}

	public function setLibelleDepartement($libelleDepartement)
	{
		return $this->_libelleDepartement = $libelleDepartement;
	}

	public function getIdRegion()
	{
		return $this->_idRegion;
	}

	public function setIdRegion($idRegion)
	{
		return $this->_idRegion = $idRegion;
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
		return "IdDepartement : ".$this->getIdDepartement()."LibelleDepartement : ".$this->getLibelleDepartement()."IdRegion : ".$this->getIdRegion();	
}

}