
--
-- Base de données :  `baseproduits`
--
CREATE DATABASE IF NOT EXISTS `baseproduits` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `baseproduits`;

-- --------------------------------------------------------

--
-- Structure de la table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `idCategorie` int(11) NOT NULL AUTO_INCREMENT,
  `LibelleCategorie` varchar(50) NOT NULL,
  PRIMARY KEY (`idCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `categories`
--

INSERT INTO `categories` (`idCategorie`, `LibelleCategorie`) VALUES
(1, 'périssable'),
(2, 'éternel');

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `mavue`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `mavue`;
CREATE TABLE IF NOT EXISTS `mavue` (
`idProduit` int(11)
,`libelleProduit` varchar(50)
,`prix` int(11)
,`dateDePeremption` date
,`idCategorie` int(11)
,`image` varchar(50)
,`libelleCategorie` varchar(50)
);

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

DROP TABLE IF EXISTS `produits`;
CREATE TABLE IF NOT EXISTS `produits` (
  `idProduit` int(11) NOT NULL AUTO_INCREMENT,
  `libelleProduit` varchar(50) NOT NULL,
  `prix` int(11) NOT NULL,
  `dateDePeremption` date NOT NULL,
  `idCategorie` int(11) NOT NULL,
  `image` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idProduit`),
  KEY `FK_Produit_Categorie` (`idCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `produits`
--

INSERT INTO `produits` (`idProduit`, `libelleProduit`, `prix`, `dateDePeremption`, `idCategorie`, `image`) VALUES
(1, 'gomme', 2, '2020-11-30', 1, NULL),
(2, 'crayon', 1, '2020-11-30', 2, NULL),
(3, 'zet', 12, '2021-04-21', 2, 'IMG/prod_608193848b2b8.png'),
(6, 'm', 1, '2021-04-29', 1, 'IMG/prod_6081972f86d49.png'),
(7, 'ty', 12, '2021-04-27', 1, 'IMG/prod_608664feb15c3.jpeg');

-- --------------------------------------------------------

--
-- Structure de la table `textes`
--

DROP TABLE IF EXISTS `textes`;
CREATE TABLE IF NOT EXISTS `textes` (
  `idTexte` int(11) NOT NULL AUTO_INCREMENT,
  `codeTexte` varchar(50) NOT NULL,
  `fr` longtext NOT NULL,
  `en` longtext NOT NULL,
  PRIMARY KEY (`idTexte`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `textes`
--

INSERT INTO `textes` (`idTexte`, `codeTexte`, `fr`, `en`) VALUES
(1, 'Bonjour', 'Bonjour', 'Hello'),
(2, 'Connexion', 'Connexion', 'Log in'),
(3, 'Deconnexion', 'Deconnexion', 'Log out'),
(4, 'Accueil', 'Accueil', 'Home'),
(5, 'AdresseEmail', 'Adresse email', 'Email address'),
(6, 'Mdp', 'Mot de passe', 'Password'),
(7, 'Inscription', 'Inscription', 'Registration'),
(8, 'Nom', 'Nom', 'Surname'),
(9, 'Prenom', 'Prenom', 'Name'),
(10, 'InfoMdpLegend', 'Veuillez saisir au moins', 'Please enter at least'),
(11, 'UneMajuscule', '1 majuscule', '1 uppercase'),
(12, 'UneMinuscule', '1 minuscule', '1 lowercase'),
(13, 'UnChiffre', '1 chiffre', '1 number'),
(14, 'UnCaractereSpecial', '1 caractère spécial ( ! @ & # * ^ $ % +)', '1 special character ( ! @ & # * ^ $ % +)'),
(15, 'MinimumCaractere', '8 caractères', '8 character'),
(16, 'Confirmation', 'Confirmation', 'Confirmation'),
(17, 'Reset', 'Réinitialisation', 'Reset'),
(18, 'Envoyer', 'Envoyer', 'Send'),
(19, 'Bonjour', 'Bonjour', 'Hello'),
(20, 'Connexion', 'Connexion', 'Log in'),
(21, 'Deconnexion', 'Deconnexion', 'Log out'),
(22, 'Accueil', 'Accueil', 'Home'),
(23, 'AdresseEmail', 'Adresse email', 'Email address'),
(24, 'Mdp', 'Mot de passe', 'Password'),
(25, 'Inscription', 'Inscription', 'Registration'),
(26, 'Nom', 'Nom', 'Surname'),
(27, 'Prenom', 'Prenom', 'Name'),
(28, 'InfoMdpLegend', 'Veuillez saisir au moins', 'Please enter at least'),
(29, 'UneMajuscule', '1 majuscule', '1 uppercase'),
(30, 'UneMinuscule', '1 minuscule', '1 lowercase'),
(31, 'UnChiffre', '1 chiffre', '1 number'),
(32, 'UnCaractereSpecial', '1 caractère spécial ( ! @ & # * ^ $ % +)', '1 special character ( ! @ & # * ^ $ % +)'),
(33, 'MinimumCaractere', '8 caractères', '8 character'),
(34, 'Confirmation', 'Confirmation', 'Confirmation'),
(35, 'Reset', 'Réinitialisation', 'Reset'),
(36, 'Envoyer', 'Envoyer', 'Send');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
CREATE TABLE IF NOT EXISTS `utilisateurs` (
  `idUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `motDePasse` varchar(50) NOT NULL,
  `adresseMail` varchar(50) NOT NULL,
  `role` int(11) NOT NULL COMMENT '1 Admin 2 User',
  `pseudo` varchar(50) NOT NULL,
  PRIMARY KEY (`idUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`idUtilisateur`, `nom`, `prenom`, `motDePasse`, `adresseMail`, `role`, `pseudo`) VALUES
(7, 'ad', 'ad', '11d437a3e6695447bd1bf2331651049e', 'ad', 1, 'ad'),
(8, 'u', 'u', '1d0a5a28d53430e7f2293a1f36682f23', 'u', 2, 'u');

-- --------------------------------------------------------

--
-- Structure de la vue `mavue`
--
DROP TABLE IF EXISTS `mavue`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `mavue`  AS  select `produits`.`idProduit` AS `idProduit`,`produits`.`libelleProduit` AS `libelleProduit`,`produits`.`prix` AS `prix`,`produits`.`dateDePeremption` AS `dateDePeremption`,`produits`.`idCategorie` AS `idCategorie`,`produits`.`image` AS `image`,`categories`.`LibelleCategorie` AS `libelleCategorie` from (`produits` join `categories` on((`produits`.`idCategorie` = `categories`.`idCategorie`))) ;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `produits`
--
ALTER TABLE `produits`
  ADD CONSTRAINT `FK_Produit_Categorie` FOREIGN KEY (`idCategorie`) REFERENCES `categories` (`idCategorie`);
