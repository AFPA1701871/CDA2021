<?php

class Creations
{

	/**Attributs**/

	private $_idCreation;
	private $_idAuteur;
	private $_idOeuvre;

	/**Accesseurs**/

	public function getIdCreation()
	{
		return $this->_idCreation;
	}

	public function setIdCreation($idCreation)
	{
		$this->_idCreation = $idCreation;
	}

	public function getIdAuteur()
	{
		return $this->_idAuteur;
	}

	public function setIdAuteur($idAuteur)
	{
		$this->_idAuteur = $idAuteur;
	}

	public function getIdOeuvre()
	{
		return $this->_idOeuvre;
	}

	public function setIdOeuvre($idOeuvre)
	{
		$this->_idOeuvre = $idOeuvre;
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
		$affichage = "\n**Creations**\n";
		$affichage .= "IdCreation : " . $this->getIdCreation() . "\n" . "IdAuteur : " . $this->getIdAuteur() . "\n" . "IdOeuvre : " . $this->getIdOeuvre() . "\n";
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