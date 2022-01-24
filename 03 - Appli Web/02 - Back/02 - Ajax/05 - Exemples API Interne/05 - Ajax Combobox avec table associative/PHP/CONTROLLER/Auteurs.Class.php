<?php

class Auteurs
{

	/**Attributs**/

	private $_idAuteur;
	private $_nomAuteur;
	private $_prenomAuteur;
	private $_dateNaissanceAuteur;

	/**Accesseurs**/

	public function getIdAuteur()
	{
		return $this->_idAuteur;
	}

	public function setIdAuteur($idAuteur)
	{
		$this->_idAuteur = $idAuteur;
	}

	public function getNomAuteur()
	{
		return $this->_nomAuteur;
	}

	public function setNomAuteur($nomAuteur)
	{
		$this->_nomAuteur = $nomAuteur;
	}

	public function getPrenomAuteur()
	{
		return $this->_prenomAuteur;
	}

	public function setPrenomAuteur($prenomAuteur)
	{
		$this->_prenomAuteur = $prenomAuteur;
	}

	public function getDateNaissanceAuteur()
	{
		return $this->_dateNaissanceAuteur;
	}

	public function setDateNaissanceAuteur($dateNaissanceAuteur)
	{
		$this->_dateNaissanceAuteur = $dateNaissanceAuteur;
	}

	/**Constructeur**/

	public function __construct(array $options = [])
	{
		if (!empty($options)) {
			$this->hydrate($options);
		}
	}
	public function hydrate($data)
	{
		foreach ($data as $key => $value) {
			$methode = "set" . ucfirst($key);
			if (is_callable(([$this, $methode]))) {
				$this->$methode($value);
			}
		}
	}

	/**Autres méthodes**/

	/**
	 * Transforme l'objet en chaine de caractères
	 *
	 * @return String
	 */
	public function toString()
	{
		$affichage = "\n**Auteurs**\n";
		$affichage .= "IdAuteur : " . $this->getIdAuteur() . "\n" . "NomAuteur : " . $this->getNomAuteur() . "\n" . "PrenomAuteur : " . $this->getPrenomAuteur() . "\n" . "DateNaissanceAuteur : " . $this->getDateNaissanceAuteur() . "\n";
		return $affichage;
	}

	/**
	 * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
	 *
	 * @param [type] $obj
	 * @return bool 	
	 */
	public function equalsTo($obj)
	{
		return true;
	}

	/**
	 * Compare 2 objets
	 * Renvoi 1 si le 1er est >
	 * 0 si ils sont égaux
	 * -1 si le 1er est <
	 *
	 * @param [type] $obj1
	 * @param [type] $obj2
	 * @return int	 
	 */
	public static function compareTo($obj1, $obj2)
	{
		return 0;
	}

}