-- 1 Afficher toutes les informations concernant les employés. 

SELECT * FROM `employe`

-- 2 Afficher toutes les informations concernant les départements. 

SELECT * FROM `dept`

-- 3 Afficher le nom, la date d'embauche, le numéro du supérieur, le numéro de département et le salaire de tous les employés.

SELECT `nom` , `dateemb`, `nosup`, `nodep`, `salaire` FROM `employe`

-- 4 Afficher le titre de tous les employés.

SELECT  `titre` FROM `employe`

-- 5 Afficher les différentes valeurs des titres des employés. 

SELECT DISTINCT `titre` FROM `employe`

-- 6 Afficher les différentes valeurs des titres des employés. 

SELECT `nom` , `noemp` , `nodep` FROM `employe` WHERE `titre` = 'secretaire'

-- 7 Afficher le nom et le numéro de département dont le numéro de département est supérieur à 40

SELECT `nom` , `nodept` FROM `dept` WHERE `nodept` > 40

-- 8 Afficher le nom et le prénom des employés dont le nom est alphabétiquement antérieur au prénom. 

SELECT `nom` , `prenom` FROM `employe` WHERE `nom` < `prenom`

-- 9 Afficher le nom, le salaire et le numéro du départementdes employés  dont le titre est « Représentant », le numéro de département est 35 et le salaire est supérieur à 20000.

SELECT `nom`, `salaire`, `nodep` FROM `employe` WHERE `titre` = 'Représentant' AND `nodep` = 35 AND `salaire` > 20000

-- 10 Afficher le nom, le titre et le salaire des employés dont le titre est «Représentant» ou dont le titre est «Président».

SELECT `nom`, `titre`, `salaire` FROM `employe` WHERE `titre` = "Représentant" OR `titre` = "Président";

-- 11 Afficher le nom, le titre, le numéro de département, le salaire des employés du département 34, dont le titre est « Représentant » ou « Secrétaire ».

SELECT `nom`, `titre`, `nodep`, `salaire` FROM `employe` WHERE `nodep` = 34 AND `titre` IN ("Représentant","Secrétaire")

-- 12 Afficher le nom, le titre, le numéro de département, le salaire des employés dont le titre est Représentant, ou dont le titre est Secrétaire dans le département numéro 34.

SELECT `nom`, `titre`, `nodep`, `salaire` FROM `employe` WHERE ( `nodep` = 34 AND `titre` = 'secretaire' ) OR `titre` = 'representant'

-- 13 Afficher le nom, et le salaire des employés dont le salaire est compris entre 20000 et 30000. 

SELECT `nom` , `salaire` FROM `employe` WHERE `salaire` BETWEEN 20000 AND 30000

------------------
WHERE IS 14 ????? 
------------------

-- 15 Afficher le nom des employés commençant par la lettre « H ». 

SELECT `nom` FROM `employe` WHERE `nom` LIKE 'H%'

-- 16 Afficher le nom des employés se terminant par la lettre « n ». 

SELECT `nom` FROM `employe` WHERE `nom` LIKE '%n'

-- 17 Afficher le nom des employés contenant la lettre « u » en 3ème position.

SELECT `nom` FROM `employe` WHERE SUBSTRING(`nom`,3,1) = "u"
------------
SELECT `nom` FROM `employe` WHERE `nom` LIKE "__u%"

-- 18 Afficher le salaire et le nom des employés du service 41 classés par salaire croissant. 

SELECT `salaire`, `nom` FROM `employe` WHERE `nodep` = 41 ORDER BY `salaire`

-- 19 Afficher le salaire et le nom des employés du service 41 classés par salaire décroissant.

SELECT `salaire`, `nom` FROM `employe` WHERE `nodep` = 41 ORDER BY `salaire` DESC

-- 20 Afficher le titre, le salaire et le nom des employés classés par titre croissant et par salaire décroissant

SELECT `titre`, `salaire`, `nom` FROM `employe` ORDER BY `titre` , `salaire` DESC

-- 21 Afficher le taux de commission, le salaire et le nom des employés classés par taux de commission croissante. 

SELECT `tauxcom` , `salaire` , `nom` FROM `employe` ORDER BY `tauxcom`

-- 22 Afficher le nom, le salaire, le taux de commission et le titre des employés dont le taux de commission n est pas renseigné. 

SELECT `nom`, `salaire` ,`tauxcom`, `titre` FROM `employe` WHERE `tauxcom` IS null

-- 23 Afficher le nom, le salaire, le taux de commission et le titre des employés dont le taux de commission est renseigné.

SELECT `nom` , `salaire` , `tauxcom` , `titre` FROM `employe` WHERE `tauxcom` IS NOT null

-- 24 Afficher le nom, le salaire, le taux de commission, le titre des employés dont le taux de commission est inférieur à 15.

SELECT `nom`, `salaire`, `tauxcom`, `titre` FROM `employe` WHERE `tauxcom` < 15

-- 25 Afficher le nom, le salaire, le taux de commission, le titre des employés dont le taux de commission est supérieur à 15

SELECT `nom`, `salaire`, `tauxcom`, `titre` FROM `employe` WHERE `tauxcom` > 15

-- 26 Afficher le nom, le salaire, le taux de commission et la commission des employés dont le taux de commission nest pas nul. (la commission est calculée en multipliant le salaire par le taux de commission)

SELECT `nom`, `salaire`, `tauxcom`, ((`salaire`*`tauxcom`)/100) AS `commission` FROM `employe` WHERE `tauxcom` IS NOT NULL

-- 27 Afficher le nom, le salaire, le taux de commission, la commission des employés dont le taux de commission n est pas nul, classé par taux de commission croissant. 

SELECT `nom`, `salaire`, `tauxcom`, ((`salaire`*`tauxcom`)/100) AS `commission` FROM `employe` WHERE `tauxcom` IS NOT NULL ORDER BY `tauxcom`

-- 28 Afficher le nom et le prénom (concaténés) des employés. Renommer les colonnes

SELECT CONCAT(`nom`," ", `prenom`) AS `Employé`  FROM `employe`

-- 29 Afficher les 5 premières lettres du nom des employés

SELECT SUBSTRING(`nom`,1,5) AS `nomEmployes` FROM `employe`

-- 30 Afficher le nom et le rang de la lettre « r » dans le nom des employés.

SELECT `nom`, LOCATE("r", `nom`) as "Rang de la lettre r" FROM `employe`
---------------------------
SELECT `nom`, INSTR(`nom`,"r") AS "Rang de la lettres r" FROM  `employe`

-- 31 Afficher le nom, le nom en majuscule et le nom en minuscule de l employé dont le nom est Vrante. 

SELECT `nom`, UPPER(`nom`), LOWER(`nom`) FROM `employe` where `nom` = "Vrante"

-- 32 Afficher le nom et le nombre de caractères du nom des employés. 

SELECT `nom`, LENGTH(`nom`) as longeurNom FROM `employe`

---------------
|   FICHE 2   |
---------------

-- 1 Rechercher le prénom des employés et le numéro de la région de leur département.

SELECT e.nom, e.prenom, noregion  FROM employe AS e INNER JOIN dept AS d ON  e.nodep=d.nodept; 

-- 2 Rechercher le numéro du département, le nom du département, le nom des employés classés par numéro de département (renommer les tables utilisées).

SELECT e.nodep, d.nom AS 'nom departement', e.nom AS 'nom employe' FROM employe AS e INNER JOIN dept AS d ON e.nodep = d.nodeptorder BY e.nodep

-- 3 Rechercher le nom des employés du département Distribution.

SELECT E.nomFROM employe AS E INNER JOIN dept AS D ON E.nodep = D.nodept WHERE D.nom = 'Distribution'

-- 4 Rechercher le nom et le salaire des employés qui gagnent plus que leur patron, et le nom et le salaire de leur patron. 

SELECT nom, salaire,(SELECT nom FROM employe WHERE noemp=e.nosup) AS "nom supérieur", (SELECT salaire FROM employe WHERE noemp=e.nosup) AS "salaire supérieur" FROM employe AS e WHERE salaire>(SELECT salaire FROM employe WHERE noemp=e.nosup);
_________________________

/!\ NE JAMAIS FAIRE ! /!\
_________________________
SELECT employe.nom, employe.salaire, boss.nom, boss.salaire
FROM employe INNER JOIN employe AS boss ON employe.nosup = boss.noemp
WHERE employe.salaire>boss.salaire

-- 5 Rechercher le nom et le titre des employés qui ont le même titre que Amartakaldire. 

SELECT nom, titre FROM employe WHERE titre = (SELECT titre FROM employe WHERE nom = "Amartakaldire")

-- 6 Rechercher le nom, le salaire et le numéro de département des employés qui gagnent plus qu un seul employé du département 31, classés par numéro de département et salaire.

SELECT nom, salaire, nodep FROM employe WHERE salaire > (SELECT MIN(salaire) FROM employe WHERE nodep = 31) ORDER BY nodep , salaire

-- 7 Rechercher le nom, le salaire et le numéro de département des employés qui gagnent plus que tous les employés du département 31, classés par numéro de département et salaire. 

SELECT nom, salaire, nodep FROM employe WHERE salaire > (SELECT MAX(salaire) FROM employe WHERE nodep = 31) ORDER BY nodep , salaire

-- 8 Rechercher le nom et le titre des employés du service 31 qui ont un titre que l on trouve dans le département 32. 

SELECT nom, titre  FROM employe WHERE titre IN (SELECT titre FROM employe WHERE nodep = 32) AND nodep = 31

-- 9 Rechercher le nom et le titre des employés du service 31 qui ont un titre l on ne trouve pas dans le département 32. 

SELECT nom, titre  FROM employe WHERE titre NOT IN (SELECT titre FROM employe WHERE nodep = 32) AND nodep = 31

-- 10 Rechercher le nom, le titre et le salaire des employés qui ont le même titre et le même salaire que Fairant. 

SELECT nom, titre, salaire FROM employe WHERE NOT nom = 'Fairent' AND (titre,salaire) = (SELECT titre,salaire FROM employe WHERE nom = 'Fairent')

-- 11 Rechercher le numéro de département, le nom du département, le nom des employés, en affichant aussi les départements dans lesquels il ny a personne, classés par numéro de département. 

SELECT e.nodep, d.nom AS 'nom departement', e.nom AS 'nom employe' FROM employe AS e RIGHT JOIN dept AS d ON e.nodep = d.nodept ORDER BY e.nodep

-- 1. Calculer le nombre d'employés de chaque titre.

SELECT titre, COUNT(*) AS NbEmploye FROM employe GROUP BY titre

-- 2. Calculer la moyenne des salaires et leur somme, par région.

SELECT D.noregion, sum(E.salaire) AS SalaireSomme, AVG(E.salaire) AS SalaireMoy FROM employe AS E INNER JOIN dept AS D GROUP BY D.noregion 

--3. Afficher les numéros des départements ayant au moins 3 employés.

SELECT nodep FROM employe GROUP BY nodep HAVING COUNT(nodep) >= 3

-- 4. Afficher les lettres qui sont l'initiale d'au moins trois employés

SELECT substring(nom,1,1) AS 'initial' FROM employe GROUP BY initial HAVING count(initial) > 2

-- 5. Rechercher le salaire maximum et le salaire minimum parmi tous les salariés et l'écart entre les deux. 
SELECT MIN(salaire) AS 'salaire min' , MAX(salaire) AS 'salaire max' , MAX(salaire)-MIN(salaire) AS 'difference' FROM employe

-- 6. Rechercher le nombre de titres différents.

SELECT COUNT(DISTINCT titre) as "Nombre de titres" FROM employe

-- 7. Pour chaque titre, compter le nombre d'employés possédant ce titre.

SELECT titre, COUNT(*) AS NbEmploye FROM employe GROUP BY titre

-- 8. Pour chaque nom de département, afficher le nom du département et le nombre d'employés.

SELECT d.nom, count(e.noemp) AS "Nb employes" FROM employe AS e INNER JOIN dept AS d ON d.nodept=e.nodep GROUP BY d.nom;

-- 9. Rechercher les titres et la moyenne des salaires par titre dont la moyenne est supérieure à la moyenne des salaires des Représentants.

SELECT titre, ROUND(AVG(salaire)) as "MoySalaire" FROM employe GROUP BY titre HAVING MoySalaire > (SELECT AVG(salaire) FROM employe WHERE titre="représentant")

-- 10.Rechercher le nombre de salaires renseignés et le nombre de taux de commission renseignés. 

SELECT COUNT (salaire) , COUNT (tauxcom) FROM Employe