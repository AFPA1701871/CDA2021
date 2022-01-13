<?php

class Test2avecmaj 
{

	/*****************Attributs***************** */

	private $_idtest2;
	private $_libAvecMaj;
	private $_num;
	private $_dat;
	private $_tim;
	private static $_attributes=["idtest2","libAvecMaj","num","dat","tim"];
	/***************** Accesseurs ***************** */


	public function getIdtest2()
	{
		return $this->_idtest2;
	}

	public function setIdtest2(int $idtest2)
	{
		$this->_idtest2=$idtest2;
	}

	public function getLibAvecMaj()
	{
		return $this->_libAvecMaj;
	}

	public function setLibAvecMaj(string $libAvecMaj)
	{
		$this->_libAvecMaj=$libAvecMaj;
	}

	public function getNum()
	{
		return $this->_num;
	}

	public function setNum(int $num)
	{
		$this->_num=$num;
	}

	public function getDat()
	{
		return $this->_dat->format('d/m/Y');
	}

	public function setDat(string $dat)
	{
		$this->_dat=DateTime::createFromFormat("Y-n-j",$dat);
	}

	public function getTim()
	{
		return $this->_tim->format('H:i:s');
	}

	public function setTim(string $tim)
	{
		$this->_tim= DateTime::createFromFormat("H:i:s",$tim);
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
		return "Idtest2 : ".$this->getIdtest2()."LibAvecMaj : ".$this->getLibAvecMaj()."Num : ".$this->getNum()."Dat : ".$this->getDat()."Tim : ".$this->getTim()."\n";
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