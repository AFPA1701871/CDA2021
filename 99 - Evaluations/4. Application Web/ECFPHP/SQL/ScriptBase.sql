DROP DATABASE IF EXISTS ECF_PHP;

CREATE DATABASE ECF_PHP DEFAULT CHARACTER SET utf8;

Use ECF_PHP;

-- 
-- Table TypesArticles
--
CREATE TABLE TypesArticles(
   IdTypeArticle INT AUTO_INCREMENT,
   LibelleTypeArticle VARCHAR(100),
   PRIMARY KEY(IdTypeArticle)
) ENGINE = InnoDB;

-- 
-- Table Paniers
--
CREATE TABLE Paniers(
   IdPanier INT AUTO_INCREMENT,
   IdClient INT ,
   DatePanier DATE,
   AdresseLivraison VARCHAR(100),
   PRIMARY KEY(IdPanier)
) ENGINE = InnoDB;

-- 
-- Table Articles
--
CREATE TABLE Articles(
   IdArticle INT AUTO_INCREMENT,
   LibelleArticle VARCHAR(20),
   DescriptionArticle VARCHAR(200),
   PrixArticle DOUBLE,
   Photos VARCHAR(100),
   IdTypeArticle INT NOT NULL,
   PRIMARY KEY(IdArticle),
   FOREIGN KEY(IdTypeArticle) REFERENCES TypesArticles(IdTypeArticle)
) ENGINE = InnoDB;

-- 
-- Table LignesPaniers
--
CREATE TABLE LignesPaniers(
   IdLignePanier INT AUTO_INCREMENT PRIMARY KEY,
   IdArticle INT,
   IdPanier INT,
   Quantite INT,
   FOREIGN KEY(IdArticle) REFERENCES Articles(IdArticle),
   FOREIGN KEY(IdPanier) REFERENCES Paniers(IdPanier)
) ENGINE = InnoDB;