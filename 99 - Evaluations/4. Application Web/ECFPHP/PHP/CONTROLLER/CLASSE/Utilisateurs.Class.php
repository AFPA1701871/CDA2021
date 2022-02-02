<?php

class Utilisateurs 
{

	/*****************Attributs***************** */

	private $_idUtilisateur;
	private $_nom;
	private $_prenom;
	private $_adresseMail;
	private $_motDePasse;
	private $_role;
	private static $_attributes=["idUtilisateur","nom","prenom","adresseMail","motDePasse","role"];
	/***************** Accesseurs ***************** */


	public function getIdUtilisateur()
	{
		return $this->_idUtilisateur;
	}

	public function setIdUtilisateur(?int $idUtilisateur)
	{
		$this->_idUtilisateur=$idUtilisateur;
	}

	public function getNom()
	{
		return $this->_nom;
	}

	public function setNom(string $nom)
	{
		$this->_nom=$nom;
	}

	public function getPrenom()
	{
		return $this->_prenom;
	}

	public function setPrenom(string $prenom)
	{
		$this->_prenom=$prenom;
	}

	public function getAdresseMail()
	{
		return $this->_adresseMail;
	}

	public function setAdresseMail(string $adresseMail)
	{
		$this->_adresseMail=$adresseMail;
	}

	public function getMotDePasse()
	{
		return $this->_motDePasse;
	}

	public function setMotDePasse(string $motDePasse)
	{
		$this->_motDePasse=$motDePasse;
	}

	public function getRole()
	{
		return $this->_role;
	}

	public function setRole(int $role)
	{
		$this->_role=$role;
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
		return $this->getNom()." ".$this->getPrenom();
	}
}