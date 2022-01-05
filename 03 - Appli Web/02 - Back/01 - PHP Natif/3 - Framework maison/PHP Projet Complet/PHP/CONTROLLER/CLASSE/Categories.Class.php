<?php

class Categories 
{

	/*****************Attributs***************** */

	private $_idCategorie;
	private $_LibelleCategorie;

	/***************** Accesseurs ***************** */


	public function getIdCategorie()
	{
		return $this->_idCategorie;
	}

	public function setIdCategorie($idCategorie)
	{
		$this->_idCategorie=$idCategorie;
	}

	public function getLibelleCategorie()
	{
		return $this->_LibelleCategorie;
	}

	public function setLibelleCategorie($LibelleCategorie)
	{
		$this->_LibelleCategorie=$LibelleCategorie;
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
}