<?php

class Regions 
{

	/*****************Attributs***************** */

	private $_reg_id;
	private $_reg_v_nom;
	private $_reg_nb_dep;
	private static $_attributes=["reg_id","reg_v_nom","reg_nb_dep"];
	/***************** Accesseurs ***************** */


	public function getReg_id()
	{
		return $this->_reg_id;
	}

	public function setReg_id(int $reg_id)
	{
		$this->_reg_id=$reg_id;
	}

	public function getReg_v_nom()
	{
		return $this->_reg_v_nom;
	}

	public function setReg_v_nom(string $reg_v_nom)
	{
		$this->_reg_v_nom=$reg_v_nom;
	}

	public function getReg_nb_dep()
	{
		return $this->_reg_nb_dep;
	}

	public function setReg_nb_dep(int $reg_nb_dep)
	{
		$this->_reg_nb_dep=$reg_nb_dep;
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
		return "Reg_id : ".$this->getReg_id()."Reg_v_nom : ".$this->getReg_v_nom()."Reg_nb_dep : ".$this->getReg_nb_dep()."\n";
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