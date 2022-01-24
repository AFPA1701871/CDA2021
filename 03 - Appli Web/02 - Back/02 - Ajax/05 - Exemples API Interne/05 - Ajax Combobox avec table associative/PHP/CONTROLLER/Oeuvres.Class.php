<?php

class Oeuvres
{

	/**Attributs**/

	private $_idOeuvre;
	private $_titreOeuvre;
	private $_typeOeuvre;
	private $_dateOeuvre;

	/**Accesseurs**/

	public function getIdOeuvre()
	{
		return $this->_idOeuvre;
	}

	public function setIdOeuvre($idOeuvre)
	{
		$this->_idOeuvre = $idOeuvre;
	}

	public function getTitreOeuvre()
	{
		return $this->_titreOeuvre;
	}

	public function setTitreOeuvre($titreOeuvre)
	{
		$this->_titreOeuvre = $titreOeuvre;
	}

	public function getTypeOeuvre()
	{
		return $this->_typeOeuvre;
	}

	public function setTypeOeuvre($typeOeuvre)
	{
		$this->_typeOeuvre = $typeOeuvre;
	}

	public function getDateOeuvre()
	{
		return $this->_dateOeuvre;
	}

	public function setDateOeuvre($dateOeuvre)
	{
		$this->_dateOeuvre = $dateOeuvre;
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
		$affichage = "\n**Oeuvres**\n";
		$affichage .= "IdOeuvre : " . $this->getIdOeuvre() . "\n" . "TitreOeuvre : " . $this->getTitreOeuvre() . "\n" . "TypeOeuvre : " . $this->getTypeOeuvre() . "\n" . "DateOeuvre : " . $this->getDateOeuvre() . "\n";
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