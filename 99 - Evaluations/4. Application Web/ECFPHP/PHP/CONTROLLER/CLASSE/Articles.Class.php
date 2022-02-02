<?php

class Articles 
{

	/*****************Attributs***************** */

	private $_IdArticle;
	private $_LibelleArticle;
	private $_DescriptionArticle;
	private $_PrixArticle;
	private $_Photos;
	private $_IdTypeArticle;
	private static $_attributes=["IdArticle","LibelleArticle","DescriptionArticle","PrixArticle","Photos","IdTypeArticle"];
	/***************** Accesseurs ***************** */


	public function getIdArticle()
	{
		return $this->_IdArticle;
	}

	public function setIdArticle(?int $IdArticle)
	{
		$this->_IdArticle=$IdArticle;
	}

	public function getLibelleArticle()
	{
		return $this->_LibelleArticle;
	}

	public function setLibelleArticle(?string $LibelleArticle)
	{
		$this->_LibelleArticle=$LibelleArticle;
	}

	public function getDescriptionArticle()
	{
		return $this->_DescriptionArticle;
	}

	public function setDescriptionArticle(?string $DescriptionArticle)
	{
		$this->_DescriptionArticle=$DescriptionArticle;
	}

	public function getPrixArticle()
	{
		return $this->_PrixArticle;
	}

	public function setPrixArticle(?float $PrixArticle)
	{
		$this->_PrixArticle=$PrixArticle;
	}

	public function getPhotos()
	{
		return $this->_Photos;
	}

	public function setPhotos(?string $Photos)
	{
		$this->_Photos = $Photos;
	}

	public function getIdTypeArticle()
	{
		return $this->_IdTypeArticle;
	}

	public function setIdTypeArticle(int $IdTypeArticle)
	{
		$this->_IdTypeArticle=$IdTypeArticle;
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
		return $this->getLibelleArticle();
	}

}