
CREATE DATABASE IF NOT EXISTS `ecf` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ecf`;

--
-- Structure de la table `groupes`
--

DROP TABLE IF EXISTS `groupes`;
CREATE TABLE IF NOT EXISTS `groupes` (
  `IdGroupe` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY ,
  `NomDuGroupe` varchar(50) NOT NULL,
  `NombreDeFollowers` int(11) NOT NULL,
  `Logo` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Structure de la table `musiciens`
--

DROP TABLE IF EXISTS `musiciens`;
CREATE TABLE IF NOT EXISTS `musiciens` (
  `idMusicien` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `Instrument` varchar(50) NOT NULL,
  `IdGroupe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



  INSERT INTO `groupes` (`IdGroupe`, `NomDuGroupe`, `NombreDeFollowers`, `Logo`) VALUES
(1, 'TheGroup', 3, 'logo1.jpg'),
(2, 'Meilleur Groupe', 30, 'logo2.png');


INSERT INTO `musiciens` (`idMusicien`, `Nom`, `Prenom`, `Instrument`, `IdGroupe`) VALUES
(1, 'Dupond', 'Toto', 'guitare', 1),
(4, 'Durand', 'Titi', 'batterie', 2);
--
-- Contraintes pour la table `musiciens`
--
ALTER TABLE `musiciens`
  ADD CONSTRAINT `FK_Membres_Groupes` FOREIGN KEY (`IdGroupe`) REFERENCES `groupes` (`IdGroupe`);


