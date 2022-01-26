-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 26 jan. 2022 à 14:57
-- Version du serveur :  5.7.21
-- Version de PHP :  7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `multicouche`
--
CREATE DATABASE IF NOT EXISTS `multicouche` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `multicouche`;

-- --------------------------------------------------------

--
-- Structure de la table `departements`
--

DROP TABLE IF EXISTS `departements`;
CREATE TABLE IF NOT EXISTS `departements` (
  `IdDepartement` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(50) NOT NULL,
  PRIMARY KEY (`IdDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `departements`
--

INSERT INTO `departements` (`IdDepartement`, `Libelle`) VALUES
(1, 'dep1'),
(2, 'dep2'),
(3, 'dep4');

-- --------------------------------------------------------

--
-- Structure de la table `villes`
--

DROP TABLE IF EXISTS `villes`;
CREATE TABLE IF NOT EXISTS `villes` (
  `IdVille` int(11) NOT NULL AUTO_INCREMENT,
  `NomVille` varchar(50) NOT NULL,
  `IdDepartement` int(11) NOT NULL,
  PRIMARY KEY (`IdVille`),
  KEY `fk` (`IdDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `villes`
--

INSERT INTO `villes` (`IdVille`, `NomVille`, `IdDepartement`) VALUES
(1, 'vil1', 1),
(2, 'vil2', 2),
(3, 'vil3', 1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `villes`
--
ALTER TABLE `villes`
  ADD CONSTRAINT `fk` FOREIGN KEY (`IdDepartement`) REFERENCES `departements` (`IdDepartement`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
