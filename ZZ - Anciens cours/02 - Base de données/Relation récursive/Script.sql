drop database if exists gestion_conversions;
create database if not exists gestion_conversions;
use gestion_conversions;

--
-- table `unite`
--
DROP TABLE IF EXISTS `unite`;
CREATE TABLE IF NOT EXISTS `unite` (
  `idUnite` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleUnite` varchar(50) NOT NULL,
  PRIMARY KEY (`idUnite`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;



INSERT INTO `unite` (`idUnite`, `LibelleUnite`) VALUES
(1, 'litre'),
(2, 'millilitre'),
(3, 'centilitre'),
(4, 'hectolitre');

--
-- table `conversion`
--

DROP TABLE IF EXISTS `conversion`;
CREATE TABLE IF NOT EXISTS `conversion` (
  `idConversion` int(11) NOT NULL AUTO_INCREMENT,
  `idUniteBase` int(11) NOT NULL,
  `idUniteConverti` int(11) NOT NULL,
  `ratio` float NOT NULL,
  PRIMARY KEY (`idConversion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;



INSERT INTO `conversion` (`idConversion`, `idUniteBase`, `idUniteConverti`, `ratio`) VALUES
(1, 1, 2, 0.001),
(2, 1, 3, 0.01),
(3, 2, 1, 1000),
(4, 3, 1, 100);

ALTER TABLE `conversion` ADD  CONSTRAINT `fk_uniteBase` FOREIGN KEY (`idUniteBase`) REFERENCES `unite`(`idUnite`) ON DELETE RESTRICT ON UPDATE RESTRICT;
ALTER TABLE `conversion` ADD  CONSTRAINT `fk_uniteConverti` FOREIGN KEY (`idUniteConverti`) REFERENCES `unite`(`idUnite`) ON DELETE RESTRICT ON UPDATE RESTRICT;
