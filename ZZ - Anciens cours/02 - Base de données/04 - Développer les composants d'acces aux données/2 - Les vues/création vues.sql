CREATE VIEW Etudiants_Matieres as
SELECT etudiants.`idEtudiant`,`nomEtudiant`,`prenomEtudiant`,`adresseEtudiant`,`villeEtudiant`,`codePostalEtudiant`,`telephoneEtudiant`,`dateEntreeEtudiant`,`anneeEtudiant`,`remarqueEtudiant`,`sexeEtudiant`,`dateNaissanceEtudiant`,`HOBBY`, note, idAvoirNote ,epreuves.idEpreuve,`libelleEpreuve`,`idEnseignantEpreuve`,`dateEpreuve`,`CoefficientEpreuve`,`anneeEpreuve`,`nomMatiere`,`idMatiere`,`idModule`,`coefficientMatiere`
FROM `etudiants` 
Inner join avoir_note
ON etudiants.idEtudiant = avoir_note.idEtudiant
INNER JOIN epreuves
on avoir_note.idEpreuve=epreuves.idEpreuve
INNER join matieres
on epreuves.idMatiereEpreuve=matieres.idMatiere