
-- Base de données : `gestionstocks`
--
DROP DATABASE IF EXISTS GestionStocks;
CREATE DATABASE GestionStocks;
USE GestionStocks;
-- --------------------------------------------------------

--
-- Structure de la table `articles`
--

DROP TABLE IF EXISTS `articles`;
CREATE TABLE IF NOT EXISTS `articles` (
  `IdArticle` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleArticle` varchar(100) NOT NULL,
  `QuantiteStockee` int(11) NOT NULL,
  `IdCategorie` int(11) NOT NULL,
  PRIMARY KEY (`IdArticle`),
  KEY `IdCategorie` (`IdCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `articles`
--

INSERT INTO `articles` (`IdArticle`, `LibelleArticle`, `QuantiteStockee`, `IdCategorie`) VALUES
(1, 'Gomme', 10, 1),
(2, 'Crayon', 12, 1),
(3, 'Couette', 20, 2),
(4, 'Oreiller', 30, 2),
(5, 'Pates', 60, 4),
(6, 'Sel', 300, 4),
(7, 'Pomme', 3, 3),
(8, 'Poire', 50, 3);

-- --------------------------------------------------------

--
-- Structure de la table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `IdCategorie` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleCategorie` varchar(100) NOT NULL,
  `IdTypeProduit` int(11) NOT NULL,
  PRIMARY KEY (`IdCategorie`),
  KEY `IdTypeProduit` (`IdTypeProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `categories`
--

INSERT INTO `categories` (`IdCategorie`, `LibelleCategorie`, `IdTypeProduit`) VALUES
(1, 'Fourniture', 2),
(2, 'Literie', 2),
(3, 'Périssable', 1),
(4, 'Non périssable', 1);

-- --------------------------------------------------------

--
-- Structure de la table `typesproduits`
--

DROP TABLE IF EXISTS `typesproduits`;
CREATE TABLE IF NOT EXISTS `typesproduits` (
  `IdTypeProduit` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleTypeProduit` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdTypeProduit`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typesproduits`
--

INSERT INTO `typesproduits` (`IdTypeProduit`, `LibelleTypeProduit`) VALUES
(1, 'Alimentaire'),
(2, 'Non Alimentaire');


--
-- Contraintes pour la table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `FK_articles_Categories` FOREIGN KEY (`IdCategorie`) REFERENCES `categories` (`IdCategorie`);

--
-- Contraintes pour la table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `categories_TypesProduits` FOREIGN KEY (`IdTypeProduit`) REFERENCES `typesproduits` (`IdTypeProduit`);

