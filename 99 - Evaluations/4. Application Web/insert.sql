
use ECF_PHP;

INSERT INTO `typesarticles` (`IdTypeArticle`, `LibelleTypeArticle`) VALUES
(1, 'Alimentaire'),
(2, 'Bureautique');

INSERT INTO `articles` (`IdArticle`, `LibelleArticle`, `DescriptionArticle`, `PrixArticle`, `Photos`, `IdTypeArticle`) VALUES
(1, 'gomme', 'gomme', 3, 'jpg_61f26b02c735c.jpg', 2),
(2, 'eau', 'bouteille eau 1l', 2, 'jpg_61f01bbb44d73.jpg', 1),
(3, 'coca', 'Coca 50cl', 2, 'jpg_61f01bc85f949.jpg', 1),
(4, 'papier', 'rame de papier imprimante', 2, 'jpg_61f01bb34ef8b.jpg', 2);

INSERT INTO `utilisateurs` (`idUtilisateur`, `nom`, `prenom`, `adresseMail`, `motDePasse`, `role`) VALUES
(1, 'admin', 'admin', 'admin1@gmail.com', 'c91e2fb9a6b5c4544966351789a17129', 2),
(2, 'client1', 'client1', 'client1@gmail.com', '7ae62dab0a99e070fb2af11a0387339a', 1),
(3, 'client2', 'Client2', 'client2@gmail.com', 'd7cb3e747bd9684419b92bade7c34759', 1);