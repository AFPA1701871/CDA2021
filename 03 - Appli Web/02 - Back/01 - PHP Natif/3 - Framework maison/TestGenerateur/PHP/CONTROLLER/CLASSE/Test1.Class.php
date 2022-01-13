<?php

class Test1 
{

	/*****************Attributs***************** */

	private $_idTest1;
	private $_libtest1;
	private $_idTest2;
	private static $_attributes=["idTest1","libtest1","idTest2"];
	/***************** Accesseurs ***************** */


	public function getIdTest1()
	{
		return $this->_idTest1;
	}

	public function setIdTest1(int $idTest1)
	{
		$this->_idTest1=$idTest1;
	}

	public function getLibtest1()
	{
		return $this->_libtest1;
	}

	public function setLibtest1(string $libtest1)
	{
		$this->_libtest1=$libtest1;
	}

	public function getIdTest2()
	{
		return $this->_idTest2;
	}

	public function setIdTest2(int $idTest2)
	{
		$this->_idTest2=$idTest2;
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
		return "IdTest1 : ".$this->getIdTest1()."Libtest1 : ".$this->getLibtest1()."IdTest2 : ".$this->getIdTest2()."\n";
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