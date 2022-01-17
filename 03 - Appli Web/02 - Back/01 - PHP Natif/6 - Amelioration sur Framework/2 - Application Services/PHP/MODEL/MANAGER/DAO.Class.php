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
			$requ .= $colonnes[$i] . ",";
			$values .= ":" . $colonnes[$i] . ",";
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
		$injection = false; // sera égale à vrai si une des composantes contient un  ;
		$cpt = 0;  // compte les colonnes dans les while

		// on initialise les variables a chaine vide.
		$condi = "";
		$ordrBy = "";
		$lim = "";

		if (!empty($nomColonnes)) { // On test si le tableau de colonnes est pas vide
			/* On boucle sur le nom des colonnes de la requête en vérifiant que les valeurs ne contiennent pas de ";" */
			do {
				if (strpos($nomColonnes[$cpt], ";")) {
					$injection = true;
				}
				$cpt++;
			} while (!$injection && $cpt < count($nomColonnes));
			/*** Fin de la boucle ***/

			if (!$injection) { // Si Pas d'injection on execute la fonction qui récup les colonnes.
				$cols = self::elementSelect($nomColonnes);
			}
		} else { //  Dans ce cas il est vide MAIS POUR AUTANT Ce n'est pas une injection mais on arrête le processus si la requête est incomplète.
			$injection = true;
		}
		if (strpos($table, ";") || $injection) { // on revérifie qu'injection = false && pas de ";" Si c'est le cas on execute le reste du programme.
			$injection = true;
		} else {
			$t = self::tableSelect($table);
		}

		if ($conditions != null) { // on vérifie s'il y a des conditions sinon on fait rien
			if (!$injection) { // Si Pas d'injection

				// recherche d'injection dans le tableau des conditions
				foreach ($conditions as $uneCondition) {
					if (is_array($uneCondition)) { // Si la variable $uneCondition est un tableau
						$cpt = 0;
						/*** On boucle sur le tableau $uneCondition en vérifiant que les valeurs ne contiennent pas de ";" ***/
						do {
							if (strpos($uneCondition[$cpt], ";")) {
								$injection = true;
							}
							$cpt++;
						} while (!$injection && $cpt < count($uneCondition));
						/*** Fin de la boucle While ***/
					} else { // si $uneCondition est une chaine
						if (strpos($uneCondition, ";")) {
							$injection = true;
						}
					}
				}
				/*** Fin de boucle foreach ***/

				if (!$injection) // On revérifie s'il n'y a pas eu d'injection entre temps et on execute la fonction qui récupère les conditions.
				{
					$condi = self::conditionSelect($conditions);
				}
			}
		}

		if ($orderBy != null) { // On vérifie que le select contient un ORDER BY
			if (strpos($orderBy, ";") || $injection) { // on revérifie qu'injection = false && pas de ";" Si c'est le cas on execute le reste du programme.
				$injection = true;
			} else {
				$ordrBy = self::orderBySelect($orderBy);
			}
		}

		if ($limit != null) { // On vérifie que le select contient un LIMIT
			if (strpos($limit, ";") || $injection) { // on revérifie qu'injection = false && pasde ";" Si c'est le cas on execute le reste du programme.
				$injection = true;
			} else {
				$limit = self::limitSelect($limit);
			}
		}

		// On vérifie qu'il n'y a pas d'injection OU que les paramètres donnés sont corrects et on lance la requête.
		if (!$injection) {
			$q = $db->query($cols . $t . $condi . $ordrBy . $limit);

			if ($debug) // Si le debug est a true on affiche la requete qui est envoyée en base de données
			{
				var_dump($cols . $t . $condi . $ordrBy . $limit);
			}
			while ($donnees = $q->fetch(PDO::FETCH_ASSOC)) { // on récupère les enregistrements de la BDD
				if ($donnees != false) {
					if ($api) { // On vérifie si api est a true, on renvoie un string sinon des objets liés a à la table donnée en paramètres.
						$liste[] = $donnees;
					} else {
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
	 * @param string $nomTable => nom de la table sur laquelle la requête sera effectuée pour plus de détail allez voir la doc sur select..
	 * @return string => compose la partie FROM de la méthode select
	 *
	 */
	private static function tableSelect($nomTable)
	{
		return " FROM " . $nomTable;
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
				$req .= $nomColonne . " IN (" . $valeur[0] . "," . $valeur[1] . ") AND ";
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

	/**
	 * Méthode privée qui sera appelée par la méthode select
	 *
	 * @param string $ordre => contient les colonnes de tri et l'ordre pour plus de détail allez voir la doc sur select.
	 * @return string => compose la partie ORDER BY de la méthode select
	 *
	 */
	private static function orderBySelect($ordre)
	{
		return " ORDER BY " . $ordre;
	}

	/**
	 * Méthode privée qui sera appelée par la méthode select
	 *
	 * @param string $limit => contient la délimitation des enregistrements de la BDD pour plus de détail allez voir la doc sur select.
	 * @return string => compose la partie LIMIT de la méthode select
	 *
	 */
	private static function limitSelect($limit)
	{
		return " LIMIT " . $limit;
	}
}
