DROP DATABASE IF EXISTS baseproduits;

CREATE DATABASE IF NOT EXISTS baseproduits DEFAULT CHARACTER
SET latin1 COLLATE latin1_swedish_ci;

USE baseproduits;

DROP TABLE IF EXISTS categories;

CREATE TABLE IF NOT EXISTS categories (
  idCategorie int (11) NOT NULL AUTO_INCREMENT,
  LibelleCategorie varchar (50) NOT NULL,
  PRIMARY KEY (idCategorie)
) ENGINE = InnoDB DEFAULT CHARSET = latin1;

DROP TABLE IF EXISTS produits;

CREATE TABLE IF NOT EXISTS produits (
  idProduit int (11) NOT NULL AUTO_INCREMENT,
  libelleProduit varchar (50) NOT NULL,
  prix int (11) NOT NULL,
  dateDePeremption date NOT NULL,
  idCategorie int (11) NOT NULL,
  PRIMARY KEY (idProduit),
  KEY FK_Produit_Categorie (idCategorie)
) ENGINE = InnoDB DEFAULT CHARSET = latin1;

DROP TABLE IF EXISTS utilisateurs;

CREATE TABLE IF NOT EXISTS utilisateurs (
  idUtilisateur int(11) NOT NULL AUTO_INCREMENT,
  nom varchar(50) NOT NULL,
  prenom varchar(50) NOT NULL,
  motDePasse varchar(50) NOT NULL,
  adresseMail varchar(50) NOT NULL,
  role int(11) NOT NULL COMMENT '2 Admin 1 User',
  pseudo varchar(50) NOT NULL,
  PRIMARY KEY (idUtilisateur)
) ENGINE = InnoDB DEFAULT CHARSET = latin1;

ALTER TABLE produits
ADD   CONSTRAINT FK_Produit_Categorie FOREIGN KEY (idCategorie) REFERENCES categories (idCategorie);

INSERT INTO
  categories (idCategorie, LibelleCategorie)
VALUES   (1, 'périssable'),(2, 'éternel');

INSERT INTO   produits (idProduit, libelleProduit, prix, dateDePeremption, idCategorie  )
VALUES (1, 'gomme', 2, '2020-11-30', 1);

INSERT INTO   produits (idProduit, libelleProduit, prix, dateDePeremption, idCategorie  )
VALUES(2, 'crayon', 1, '2020-11-30', 2);

INSERT INTO `utilisateurs` (`idUtilisateur`, `nom`, `prenom`, `motDePasse`, `adresseMail`, `role`, `pseudo`) VALUES
(7, 'ad', 'ad', '11d437a3e6695447bd1bf2331651049e', 'ad', 2, 'ad'),
(8, 'u', 'u', '1d0a5a28d53430e7f2293a1f36682f23', 'u', 1, 'u');