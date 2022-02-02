<?php

class Paniers
{

	/*****************Attributs***************** */

	private $_IdPanier;
	private $_IdClient;
	private $_DatePanier;
	private $_AdresseLivraison;
	private static $_attributes = ["IdPanier", "IdClient", "DatePanier", "AdresseLivraison"];
	/***************** Accesseurs ***************** */


	public function getIdPanier()
	{
		return $this->_IdPanier;
	}

	public function setIdPanier(?int $IdPanier)
	{
		$this->_IdPanier = $IdPanier;
	}

	public function getIdClient()
	{
		return $this->_IdClient;
	}

	public function setIdClient(int $IdClient)
	{
		$this->_IdClient = $IdClient;
	}

	public function getDatePanier()
	{
		return is_null($this->_DatePanier) ? null : $this->_DatePanier->format('Y-n-j');
	}

	public function setDatePanier(?string $DatePanier)
	{
		$this->_DatePanier = is_null($DatePanier) ? null : DateTime::createFromFormat("Y-n-j", $DatePanier);
	}

	public function getAdresseLivraison()
	{
		return $this->_AdresseLivraison;
	}

	public function setAdresseLivraison(?string $AdresseLivraison)
	{
		$this->_AdresseLivraison = $AdresseLivraison;
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
		foreach ($data as $key => $value) {
			$methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
			if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
			{
				$this->$methode($value === "" ? null : $value);
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
		return "IdPanier : " . $this->getIdPanier() . "DatePanier : " . $this->getDatePanier() . "AdresseLivraison : " . $this->getAdresseLivraison() . "\n";
	}
}
