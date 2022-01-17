<?php

class Regions 
{

	/*****************Attributs***************** */

	private $_idRegion;
	private $_libelleRegion;
	private $_numeroRegion;
	private $_nombreDepartement;
	private static $_attributes=["idRegion","libelleRegion","numeroRegion","nombreDepartement"];
	/***************** Accesseurs ***************** */


	public function getIdRegion()
	{
		return $this->_idRegion;
	}

	public function setIdRegion(int $idRegion)
	{
		$this->_idRegion=$idRegion;
	}

	public function getLibelleRegion()
	{
		return $this->_libelleRegion;
	}

	public function setLibelleRegion(string $libelleRegion)
	{
		$this->_libelleRegion=$libelleRegion;
	}

	public function getNumeroRegion()
	{
		return $this->_numeroRegion;
	}

	public function setNumeroRegion(int $numeroRegion)
	{
		$this->_numeroRegion=$numeroRegion;
	}

	public function getNombreDepartement()
	{
		return $this->_nombreDepartement;
	}

	public function setNombreDepartement(int $nombreDepartement)
	{
		$this->_nombreDepartement=$nombreDepartement;
	}

	public static function getAttributes()
	{
		return self::$_attributes;
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
 			$methode = "set".ucfirst($key); //ucfirst met la 1ere lettre en majuscule
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
		return "IdRegion : ".$this->getIdRegion()."LibelleRegion : ".$this->getLibelleRegion()."NumeroRegion : ".$this->getNumeroRegion()."NombreDepartement : ".$this->getNombreDepartement()."\n";
	}
}