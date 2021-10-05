<?php

 Class Categorie {
	/***************************************** Attributs **********************************************/

	private $_libelle ;
	private $_tva ;

	/***************************************** Accesseurs **********************************************/
	
	public function getLibelle()
	{
		return $this->_libelle;
	}

	public function setLibelle($libelle)
	{
		$this->_libelle = $libelle;
	}
	public function getTva()
	{
		return $this->_tva;
	}

	public function setTva($tva)
	{
		$this->_tva = $tva;
	}

	/***************************************** Constructeur **********************************************/

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
			$methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
			if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
			{
				$this->$methode($value);
			}
		}
	}

	/***************************************** Methode **********************************************/

	/**
	* Transforme l'objet en chaine de caractères
	*
	* @return String
	*/
	public function toString(){
		return "\n libelle : ".$this->getLibelle()	." tva : ".$this->getTva()."\n"	;
	}

	/**
	* Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
	*
	* @param [type] obj
	* @return bool
	*/
	public function equalsTo(){
		return  "";
	}

	/**
	* Compare 2 objets
	* Renvoi 1 si le 1er est >
	*        0 si ils sont égaux
	*        -1 si le 1er est <
	*
	* @param [type] obj1
	* @param [type] obj2
	* @return void
	*/
	public static function compareTo(Categorie $c1,Categorie $c2){
		if ($c1->getLibelle()>$c2->getLibelle())
		{
			return 1;
		}
		else if ($c1->getLibelle()<$c2->getLibelle())
		{
			return -1;
		}
		else{
			return 0;
		}
		return "";
	}

}