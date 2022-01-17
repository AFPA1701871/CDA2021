<?php

class Departements 
{

	/*****************Attributs***************** */

	private $_dep_id;
	private $_dep_nom;
	private $_dep_reg_id;
	private static $_attributes=["dep_id","dep_nom","dep_reg_id"];
	/***************** Accesseurs ***************** */


	public function getDep_id()
	{
		return $this->_dep_id;
	}

	public function setDep_id(string $dep_id)
	{
		$this->_dep_id=$dep_id;
	}

	public function getDep_nom()
	{
		return $this->_dep_nom;
	}

	public function setDep_nom(string $dep_nom)
	{
		$this->_dep_nom=$dep_nom;
	}

	public function getDep_reg_id()
	{
		return $this->_dep_reg_id;
	}

	public function setDep_reg_id(int $dep_reg_id)
	{
		$this->_dep_reg_id=$dep_reg_id;
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
		return "Dep_id : ".$this->getDep_id()."Dep_nom : ".$this->getDep_nom()."Dep_reg_id : ".$this->getDep_reg_id()."\n";
	}


	
	/* Renvoit Vrai si lobjet en paramètre est égal 
	* à l'objet appelant
	*
	* @param [type] $obj
	* @return bool
	*/
	public function equalsTo($obj)
	{
		return;
	}


	/**
	* Compare l'objet à un autre
	* Renvoi 1 si le 1er est >
	*        0 si ils sont égaux
	*      - 1 si le 1er est <
	*
	* @param [type] $obj1
	* @param [type] $obj2
	* @return Integer
	*/
	public function compareTo($obj)
	{
		return;
	}
}