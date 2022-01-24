
--
-- Base de données :  `personne`
--
CREATE DATABASE personne;
USE Personne;
-- --------------------------------------------------------

--
-- Structure de la table `personnes`
--

DROP TABLE IF EXISTS `personnes`;
CREATE TABLE IF NOT EXISTS `personnes` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) DEFAULT NULL,
  `prenom` varchar(20) DEFAULT NULL,
  `codePostal` int(11) DEFAULT NULL,
  `adresse` varchar(50) NOT NULL,
  `ville` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `prenom_id` (`prenom`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personnes`
--

INSERT INTO `personnes` (`id`, `nom`, `prenom`, `codePostal`, `adresse`, `ville`) VALUES
(1, 'Doe', 'John', 59556, 'djsfghjsgdfhg', 'jsdkhjh'),
(2, 'heller', 'Paul', 59559, '', ''),
(3, 'White ', 'Jack', NULL, '', ''),
(4, 'Square', 'Chris', NULL, '', '');
