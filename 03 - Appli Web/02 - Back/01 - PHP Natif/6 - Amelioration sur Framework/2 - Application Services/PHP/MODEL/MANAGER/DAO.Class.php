<?php

class DAO
{
	/**
	 * Méthode qui permet d'insérer des données dans une table
	 *
	 * @param [type] $obj : objet à insérer (contient les valeurs mais apporte aussi le type d'objet)
	 * @return bool renvoi true si l'insert s'est bien passé, false sinon
	 */
	public static function add($obj)
	{
		$db = DbConnect::getDb();
		// on récupère le type de l'objet => ça correspond au nom de la table
		$class = get_class($obj);
		// chaque classe contient une liste de ses attributs, on en déduit la liste des colonnes de la table
		$colonnes = $class::getAttributes();
		// on commence à construire la requête
		$requ = "INSERT INTO " . $class . "(";
		$values = "";
		// on rempli 2 variables :
		//	- requ : pour la liste des colonnes
		//  - values : pour les valeurs à insérer sous forme de variable SQL ex: :nom
		for ($i = 1; $i < count($colonnes); $i++) {
			// on construit la méthode pour connaitre la valeur associée
			$methode = "get" . ucfirst($colonnes[$i]);
			// si la valeur n'est pas renseignée, on ne met pas la colonne dans l'insert
            if ($obj->$methode() != null)
        	{
				$requ .= $colonnes[$i] . ",";
				$values .= ":" . $colonnes[$i] . ",";
			}
		}
		// on enlève les , mises à la fin de chaque variable
		$requ = substr($requ, 0, strlen($requ) - 1);
		$values = substr($values, 0, strlen($values) - 1);
		// on fini d'écrire la requête
		$requ .= ") VALUES (" . $values . ")";

		$q = $db->prepare($requ);
		// On bind les variables de la requête
		for ($i = 1; $i < count($colonnes); $i++) {
			// on construit la méthode get qui permet de récupérer la valeur
			$methode = "get" . ucfirst($colonnes[$i]);
			if ($obj->$methode() != null) // s'il y a une valeur à binder
			// on exécute $obj->$methode pour avoir la valeur 
			$q->bindValue(":" . $colonnes[$i], $obj->$methode());
		}
		// on exécute la requête
		return $q->execute();
	}
	/**
	 * Méthode qui permet de modifier un enregistrement en base de données
	 *
	 * @param [type] $obj : objet qui contient les données à mettre à jour 
	 * @return bool : renvoi true si l'update s'est bien passé, false sinon
	 */
	public static function update($obj)
	{
		$db = DbConnect::getDb();
		// on récupère le type de l'objet => ça correspond au nom de la table
		$class = get_class($obj);
		// chaque classe contient une liste de ses attributs, on en déduit la liste des colonnes de la table
		$colonnes = $class::getAttributes();
		// on commence à construire la requête
		$requ = "UPDATE " . $class . " SET ";
		// pour chaque colonne, on met le nom de la colonne et la variable SQl
		// on commence à 1 pour ne pas prendre en compte l'id
		for ($i = 1; $i < count($colonnes); $i++) {
			$requ .= $colonnes[$i] . "=:" . $colonnes[$i] . ",";
		}
		// on enlève la dernière virgule
		$requ = substr($requ, 0, strlen($requ) - 1);
		// on crée la partie Where avec l'id
		$requ .= " WHERE " . $colonnes[0] . "=:" . $colonnes[0];

		$q = $db->prepare($requ);
		// on bind les variables
		for ($i = 0; $i < count($colonnes); $i++) {
			// on construit la méthode get qui permet de récupérer la valeur
			$methode = "get" . ucfirst($colonnes[$i]);
			// on exécute $obj->$methode pour avoir la valeur 
			$q->bindValue(":" . $colonnes[$i], $obj->$methode());
		}
		// on exécute la requête
		return $q->execute();
	}
	/**
	 * Méthode qui permet de supprimer un enregistrement.
	 *
	 * @param [type] $obj : Objet qui contient l'id nécessaire à la suppression
	 * @return bool  : renvoi true si l'update s'est bien passé, false sinon
	 */
	public static function delete($obj)
	{
		$db = DbConnect::getDb();
		// on récupère le type de l'objet pour avoir le nom de la classe et de son id
		$class = get_class($obj);
		$colonnes = $class::getAttributes();
		// on construit le get pour récupérer l'id
		$methode = "get" . ucfirst($colonnes[0]);
		return $db->query("DELETE FROM " . $class . " WHERE " . $colonnes[0] . " = " . $obj->$methode());
	}

	/**
	 * Méthode qui permet de faire les getAll et getBy.
	 * Elle est suffisamment générique pour permettre de choisir les colonnes à afficher, 
	 * la table dans laquelle faire la requête, les conditions where, le tri 
	 * et le nombre de lignes attendus.
	 * 
	 * 
	 * @param array $nomColonnes => contient le noms des champs désirés dans la requête.
	 * Exemple :  [nomColonne1,nomColonne2] => "SELECT nomColonne1, nomColonne2"
	 *
	 * @param string $table => contient Nom de la table sur laquelle la requête sera effectuée.
	 * Exemple : nomTable => "FROM nomTable"
	 *
	 * @param array $conditions => null par défaut, attendu un tableau associatif 
	 * qui peut prendre plusieurs formes en fonction de la complexité des conditions.
	 *
	 *  Exemples : tableau associatif
	 *  [nomColonne => '1'] => "WHERE nomColonne = 1"
	 *  [nomColonne => ['1','3']] => "WHERE nomColonne in (1,3)"
	 *  [nomColonne => '%abcd%'] => "WHERE nomColonne like "%abcd%"
	 *  [nomColonne => '1->5'] => "WHERE nomColonne BETWEEN 1 and 5 "
	 *  Si il y a plusieurs conditions alors :
	 *  [nomColonne1 => '1', nomColonne2 => '%abcd%' ] => "WHERE nomColonne1 = 1 AND nomColonne2 LIKE "%abcd%"
	 *
	 * @param string $orderBy => null par défaut, contient un string qui contient les noms de colonnes et le type de tri
	 * Exemple :"nomColonne1 , nomColonne2 DESC" => "Order By nomColonne1 , nomColonne2 DESC"
	 *
	 * @param string $limit  => null par défaut, contient un string pour donner la délimitations des enregistrements de la BDD
	 * Exemples :
	 * "1" => "LIMIT 1"
	 * "1,2"=> "LIMIT 1,2"
	 *
	 * @param boolean $api => false par défaut, mettre true si on souhaite recevoir la réponse sous forme de tableau de string sinon sous forme de tableau d'objets.
	 * 
	 * @param bool $debug => contient faux par défaut 
	 * mais si vrai, on affiche la requete qui est effectuée.
	 *
	 * @return [array ou object] $liste => résultat de la requête revoie false si la requête s'est mal passé sinon renvoie un tableau.
	 */

	public static function select(array $nomColonnes, string $table, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
    {
        $db = DbConnect::getDb();
		// On mets à plat tous les paramètres à l'aide de json_encode 
        $string = json_encode($nomColonnes) . $table . json_encode($conditions) . $orderBy . $limit . $api . $debug;
        // on cherche si l'un des paramètres contient un ; si c'est le cas, on arrête pour éviter les injections SQL
		if (strpos($string, ";"))
        {
            return false;
        }
		// on vérifie qu'il y a le minimum pour faire une requête C'est à dire des colonnes et une table
        else if (!empty($nomColonnes) && ($table != null && $table != ""))
        {
			// on crée le select avec les colonnes
            $cols = self::elementSelect($nomColonnes);
			// on crée le from
            $t = " FROM " . $table;
			// on génère la partie de la requête qui concerne les conditions
            if ($conditions != null)
            {
                $conditions = self::conditionSelect($conditions);
            }
			// on génère la partie de la requête qui concerne les tris
            if ($orderBy != null)
            {
                $orderBy = " ORDER BY " . $orderBy;
            }
			// on génère la partie de la requête qui concerne les limites
            if ($limit != null)
            {
                $limit = " LIMIT " . $limit;
            }
			// on construit la requete
            $q = $db->query($cols . $t . $conditions . $orderBy . $limit);
            if ($debug) // Si le debug est a true on affiche la requete qui est envoyée en base de données
            {
                var_dump($cols . $t . $conditions . $orderBy . $limit);
            }
            while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
            { // on récupère les enregistrements de la BDD
                if ($donnees != false)
            {
                    if ($api)
                { // On vérifie si api est a true, on renvoie un string sinon des objets liés a à la table donnée en paramètres.
                        $liste[] = $donnees;
                    }
                else
                {
                        $liste[] = new $table($donnees);
                    }
                }
            }
            return $liste;
        }
        return false;
    }

	/**
	 * Méthode privée qui sera appelée par la méthode select
	 *
	 * @param array $tab => Tableau de noms de colonnes ou agrégats de la BDD pour plus de détail allez voir la doc sur select.
	 * @return string => compose la partie SELECT de la méthode select
	 *
	 */
	private static function elementSelect($tab)
	{
		$temp = "SELECT ";
		foreach ($tab as $uneCol) {
			$temp .= $uneCol . ", ";
		}
		return substr($temp, 0, strlen($temp) - 2);
	}

	
	/**
	 * Méthode privée qui sera appelée par la méthode select
	 *
	 * @param array $conditions => tableaux qui contient les conditions pour plus de détail allez voir la doc sur select.
	 * @return string => compose la partie WHERE de la méthode select
	 *
	 */
	private static function conditionSelect($conditions)
	{
		$req = " WHERE ";
		foreach ($conditions as $nomColonne => $valeur) {
			// cas du in
			if (is_array($valeur)) {
				$req .= $nomColonne . " IN ("  . implode(",",$valeur)  . ") AND ";
			} else if (!(strpos($valeur, "%")===false)) { //cas like  si le % est en premier alors strpos retourne 0 qui correspond à la valeur de false, donc on fait un test avec le type ===
				$req .= $nomColonne . ' LIKE "' . $valeur . '" AND ';
			} else if (strpos($valeur, "->")) { //cas between
				$tab = explode("->", $valeur);
				$req .= $nomColonne . " BETWEEN " . $tab[0] . " AND " . $tab[1] . " AND ";
			} else { //cas valeur simple
				$req .= $nomColonne . " = \"" . $valeur . "\" AND ";
			}
		}
		//On retire le dernier AND
		$req = substr($req, 0, strlen($req) - 4);
		return $req;
	}
}
