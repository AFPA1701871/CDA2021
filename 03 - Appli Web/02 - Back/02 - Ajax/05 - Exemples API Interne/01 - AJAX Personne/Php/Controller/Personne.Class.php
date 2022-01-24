<?php

class Personne{
	private $_id;
	private $_nom;
	private $_prenom;
	private $_adresse;
	private $_codePostal;
	private $_ville;
	
	/**
     * @return mixed
     */
    public function getAdresse()
    {
        return $this->_adresse;
    }

    /**
     * @return mixed
     */
    public function getCodePostal()
    {
        return $this->_codePostal;
    }

    /**
     * @return mixed
     */
    public function getVille()
    {
        return $this->_ville;
    }

    /**
     * @param mixed $_adresse
     */
    public function setAdresse($_adresse)
    {
        $this->_adresse = $_adresse;
    }

    /**
     * @param mixed $_codepPostal
     */
    public function setCodePostal($_codePostal)
    {
        $this->_codePostal = $_codePostal;
    }

    /**
     * @param mixed $_ville
     */
    public function setVille($_ville)
    {
        $this->_ville = $_ville;
    }

    // Getter / Setter
	public function getId() {
		return $this->_id;
	}

	public function getNom() {
		return $this->_nom;
	}

	public function getPrenom() {
		return $this->_prenom;
	}

	public function setId($_id) {
		$this->_id = $_id;
	}

	public function setNom($_nom) {
		$this->_nom = $_nom;
	}

	public function setPrenom($_prenom) {
		$this->_prenom = $_prenom;
	}

	// Constructeur
	public function __construct(array $options = [])
	{ 
		if (!empty($options))
		{
			$this->hydrate($options);
		}
	}
	public function hydrate($data)
	{
		foreach ($data as $key => $value)
		{
			$method = 'set'.ucfirst($key);
			
			if (is_callable([$this, $method]))
			{
				$this->$method($value);
			}
		}
	}
}