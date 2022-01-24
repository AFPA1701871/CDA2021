<?php

class Categories 
{

	/*****************Attributs***************** */

	private $_idCategorie;
	private $_LibelleCategorie;
	private static $_attributes=["idCategorie","LibelleCategorie"];
	/***************** Accesseurs ***************** */


	public function getIdCategorie()
	{
		return $this->_idCategorie;
	}

	public function setIdCategorie(int $idCategorie)
	{
		$this->_idCategorie=$idCategorie;
	}

	public function getLibelleCategorie()
	{
		return $this->_LibelleCategorie;
	}

	public function setLibelleCategorie(string $LibelleCategorie)
	{
		$this->_LibelleCategorie=$LibelleCategorie;
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
				$this->$methode($value===""?null:$value);
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
		return "IdCategorie : ".$this->getIdCategorie()."LibelleCategorie : ".$this->getLibelleCategorie()."\n";
	}
}