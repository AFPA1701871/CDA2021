-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  jeu. 04 oct. 2018 à 13:31
-- Version du serveur :  5.7.21
-- Version de PHP :  5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `drdac_donnee`
--
CREATE DATABASE IF NOT EXISTS `drdac_donnee` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `drdac_donnee`;

-- --------------------------------------------------------

--
-- Structure de la table `couleurs`
--

DROP TABLE IF EXISTS `couleurs`;
CREATE TABLE IF NOT EXISTS `couleurs` (
  `id_couleur` int(3) NOT NULL AUTO_INCREMENT COMMENT 'n° d''identification des données concernant la couleur de la diode',
  `coul_date` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) COMMENT 'Date precise des données concernant la couleur de la diode',
  `num_rouge` int(3) NOT NULL COMMENT 'Enregistrement du numéros de la couleur Rouge concernant la couleur de la diode',
  `num_bleu` int(3) NOT NULL COMMENT 'Enregistrement du numéros de la couleur Bleu concernant la couleur de la diode',
  `num_vert` int(3) NOT NULL COMMENT 'Enregistrement du numéros de la couleur Vert concernant la couleur de la diode',
  PRIMARY KEY (`id_couleur`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COMMENT='Enregistrement des couleurs';

--
-- Déchargement des données de la table `couleurs`
--

INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(8, '2018-10-04 10:01:38.014795', 255, 55, 11);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(9, '2018-10-04 10:01:41.219186', 255, 186, 11);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(10, '2018-10-04 10:01:43.891421', 255, 186, 89);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(11, '2018-10-04 10:01:46.699442', 39, 186, 89);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(12, '2018-10-04 11:29:58.868139', 83, 52, 154);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(13, '2018-10-04 11:30:05.813553', 239, 75, 24);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(14, '2018-10-04 11:30:09.422025', 239, 255, 24);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(15, '2018-10-04 11:30:13.800064', 0, 255, 0);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(16, '2018-10-04 11:30:18.967521', 0, 0, 255);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(17, '2018-10-04 11:30:51.267313', 255, 0, 0);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(19, '2018-10-04 11:40:18.201913', 247, 209, 178);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(21, '2018-10-04 13:28:52.443896', 60, 200, 24);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(22, '2018-10-04 13:28:55.290974', 60, 0, 24);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(23, '2018-10-04 13:28:57.611215', 60, 0, 226);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(24, '2018-10-04 13:29:01.753133', 0, 186, 226);
INSERT INTO `couleurs` (`id_couleur`, `coul_date`, `num_rouge`, `num_bleu`, `num_vert`) VALUES(25, '2018-10-04 13:29:12.585897', 255, 0, 254);

-- --------------------------------------------------------

--
-- Structure de la table `luminosites`
--

DROP TABLE IF EXISTS `luminosites`;
CREATE TABLE IF NOT EXISTS `luminosites` (
  `id_luminosite` int(3) NOT NULL AUTO_INCREMENT COMMENT 'n° d''identification des données concernant la lumiosité',
  `lum_date` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) COMMENT 'Date precise des données concernant la lumiere',
  `lumi` int(3) NOT NULL COMMENT 'Valeur des données concernant la luminosité en %',
  PRIMARY KEY (`id_luminosite`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='Table des données concernant la luminosité';

--
-- Déchargement des données de la table `luminosites`
--

INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(1, '2018-10-03 08:01:43.903697', 87);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(2, '2018-10-03 08:01:47.830302', 80);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(4, '2018-10-04 11:34:07.964274', 32);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(6, '2018-10-04 11:53:48.887750', 83);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(7, '2018-10-04 11:54:35.153353', 97);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(8, '2018-10-04 11:55:34.131301', 81);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(9, '2018-10-04 12:39:34.897226', 57);
INSERT INTO `luminosites` (`id_luminosite`, `lum_date`, `lumi`) VALUES(10, '2018-10-04 13:29:26.364831', 65);

-- --------------------------------------------------------

--
-- Structure de la table `sons`
--

DROP TABLE IF EXISTS `sons`;
CREATE TABLE IF NOT EXISTS `sons` (
  `id_son` int(3) NOT NULL AUTO_INCREMENT COMMENT 'n° d''identification des données concernant le son',
  `date_son` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) COMMENT 'Date precise des données concernant leson',
  `niv_son` int(3) NOT NULL COMMENT 'Enregistrement du niveau sonnore dans la piece',
  PRIMARY KEY (`id_son`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='Enregistrement des donnée du bruit embiant';

--
-- Déchargement des données de la table `sons`
--

INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(1, '2018-10-03 10:07:58.014761', 73);
INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(2, '2018-10-04 11:39:06.228060', 73);
INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(3, '2018-10-04 11:39:08.160950', 81);
INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(4, '2018-10-04 11:39:10.610737', 73);
INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(5, '2018-10-04 11:39:12.771066', 73);
INSERT INTO `sons` (`id_son`, `date_son`, `niv_son`) VALUES(6, '2018-10-04 13:29:21.420308', 73);

-- --------------------------------------------------------

--
-- Structure de la table `temperatures`
--

DROP TABLE IF EXISTS `temperatures`;
CREATE TABLE IF NOT EXISTS `temperatures` (
  `id_temp` int(3) NOT NULL AUTO_INCREMENT COMMENT 'n° d''identification des données concernant la température',
  `date_temp` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) COMMENT 'Date precise des données concernant la température',
  `temp1` float NOT NULL COMMENT 'Enregistrement de la température dans la piece',
  PRIMARY KEY (`id_temp`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Enregistrement des donnée de la température';

--
-- Déchargement des données de la table `temperatures`
--

INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(1, '2018-10-03 10:08:02.707554', 28.3);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(2, '2018-10-04 11:53:55.289447', 27.6);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(3, '2018-10-04 11:54:01.207103', 30.8);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(4, '2018-10-04 11:54:02.808178', 29.3);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(5, '2018-10-04 11:54:07.876855', 28.2);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(6, '2018-10-04 11:54:18.660546', 27.7);
INSERT INTO `temperatures` (`id_temp`, `date_temp`, `temp1`) VALUES(7, '2018-10-04 13:29:17.389986', 28.2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
