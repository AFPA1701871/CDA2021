DROP DATABASE IF EXISTS toto;

CREATE DATABASE IF NOT EXISTS toto;

USE toto;

DROP TABLE IF EXISTS produits;

CREATE TABLE IF NOT EXISTS produits (
    idProduit int not null auto_increment PRIMARY KEY,
    libelleProduit varchar(50) not null,
    prix int
);

CREATE TABLE IF NOT EXISTS couleurs (
    idCouleur int not null auto_increment PRIMARY KEY,
    libelleCouleur varchar(50)
);

ALTER TABLE
    produits
ADD
    column idCouleur int;

ALTER TABLE
    produits
ADD
    CONSTRAINT fk_produits_couleurs FOREIGN KEY (idCouleur) REFERENCES couleurs(idCouleur);

CREATE TABLE toto.test (
    `idtest` INT NOT NULL AUTO_INCREMENT,
    `libelletest` VARCHAR(50) NULL,
    PRIMARY KEY (`idtest`)
) ENGINE = InnoDB;

CREATE TABLE `toto`.`marque` (
    `idMarque` INT NOT NULL AUTO_INCREMENT,
    `libelleMarque` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`idMarque`)
) ENGINE = InnoDB CHARSET = utf8 COLLATE utf8_general_ci;