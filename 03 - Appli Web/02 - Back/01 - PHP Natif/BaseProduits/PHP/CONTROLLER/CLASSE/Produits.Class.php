<?php

class Produits 
{

	/*****************Attributs***************** */

	private $_idProduit;
	private $_libelleProduit;
	private $_prix;
	private $_dateDePeremption;
	private $_idCategorie;
	private static $_attributes=["idProduit","libelleProduit","prix","dateDePeremption","idCategorie"];
	/***************** Accesseurs ***************** */


	public function getIdProduit()
	{
		return $this->_idProduit;
	}

	public function setIdProduit(int $idProduit)
	{
		$this->_idProduit=$idProduit;
	}

	public function getLibelleProduit()
	{
		return $this->_libelleProduit;
	}

	public function setLibelleProduit(string $libelleProduit)
	{
		$this->_libelleProduit=$libelleProduit;
	}

	public function getPrix()
	{
		return $this->_prix;
	}

	public function setPrix(int $prix)
	{
		$this->_prix=$prix;
	}

	public function getDateDePeremption()
	{
		return $this->_dateDePeremption->format('Y-n-j');
	}

	public function setDateDePeremption(string $dateDePeremption)
	{
		$this->_dateDePeremption=DateTime::createFromFormat("Y-n-j",$dateDePeremption);
	}

	public function getIdCategorie()
	{
		return $this->_idCategorie;
	}

	public function setIdCategorie(int $idCategorie)
	{
		$this->_idCategorie=$idCategorie;
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
		return "IdProduit : ".$this->getIdProduit()."LibelleProduit : ".$this->getLibelleProduit()."Prix : ".$this->getPrix()."DateDePeremption : ".$this->getDateDePeremption()."IdCategorie : ".$this->getIdCategorie()."\n";
	}
}