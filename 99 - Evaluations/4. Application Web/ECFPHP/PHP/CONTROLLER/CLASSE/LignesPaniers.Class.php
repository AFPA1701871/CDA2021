<?php

class LignesPaniers
{

	/*****************Attributs***************** */

	private $_IdLignePanier;
	private $_IdArticle;
	private $_IdPanier;
	private $_Quantite;
	private static $_attributes = ["IdLignePanier", "IdArticle", "IdPanier", "Quantite"];
	/***************** Accesseurs ***************** */


	public function getIdLignePanier()
	{
		return $this->_IdLignePanier;
	}

	public function setIdLignePanier(?int $IdLignePanier)
	{
		$this->_IdLignePanier = $IdLignePanier;
	}

	public function getIdArticle()
	{
		return $this->_IdArticle;
	}

	public function setIdArticle(?int $IdArticle)
	{
		$this->_IdArticle = $IdArticle;
	}

	public function getIdPanier()
	{
		return $this->_IdPanier;
	}

	public function setIdPanier(?int $IdPanier)
	{
		$this->_IdPanier = $IdPanier;
	}

	public function getQuantite()
	{
		return $this->_Quantite;
	}

	public function setQuantite(?int $Quantite)
	{
		$this->_Quantite = $Quantite;
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
		return "IdLignePanier : " . $this->getIdLignePanier() . "IdClient : " . $this->getIdClient() . "IdArticle : " . $this->getIdArticle() . "IdPanier : " . $this->getIdPanier() . "Quantite : " . $this->getQuantite() . "\n";
	}
}
