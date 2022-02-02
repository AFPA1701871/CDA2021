<?php

class TypesArticles 
{

	/*****************Attributs***************** */

	private $_IdTypeArticle;
	private $_LibelleTypeArticle;
	private static $_attributes=["IdTypeArticle","LibelleTypeArticle"];
	/***************** Accesseurs ***************** */


	public function getIdTypeArticle()
	{
		return $this->_IdTypeArticle;
	}

	public function setIdTypeArticle(?int $IdTypeArticle)
	{
		$this->_IdTypeArticle=$IdTypeArticle;
	}

	public function getLibelleTypeArticle()
	{
		return $this->_LibelleTypeArticle;
	}

	public function setLibelleTypeArticle(?string $LibelleTypeArticle)
	{
		$this->_LibelleTypeArticle=$LibelleTypeArticle;
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
		return $this->getLibelleTypeArticle();
	}
}