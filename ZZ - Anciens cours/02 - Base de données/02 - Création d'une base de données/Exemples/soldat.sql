#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------
DROP DATABASE IF EXISTS exo5soldats;

CREATE DATABASE IF NOT EXISTS exo5soldats;

USE exo5soldats;

#------------------------------------------------------------
# Table: Soldats
#------------------------------------------------------------
CREATE TABLE Soldats(
    idSoldat Int Auto_increment NOT NULL PRIMARY KEY,
    nomSoldat Varchar (250),
    prenomSoldat Varchar (250),
    dateNaissanceSoldat Date,
    dateDecesSoldat Date
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Grades
#------------------------------------------------------------
CREATE TABLE Grades(
    idGrade Int Auto_increment NOT NULL PRIMARY KEY,
    intituleGrade Varchar (250) NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Unites
#------------------------------------------------------------
CREATE TABLE Unites(
    idUnite Int Auto_increment NOT NULL PRIMARY KEY ,
    nomUnite Varchar (250) NOT NULL,
    infoUnite Varchar (250)
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Batailles
#------------------------------------------------------------
CREATE TABLE Batailles(
    idBataille Int Auto_increment NOT NULL PRIMARY KEY,
    lieuBataille Varchar (250) NOT NULL,
    dateDebutBataille Date NOT NULL,
    dateFinBataille Date NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Blessures
#------------------------------------------------------------
CREATE TABLE Blessures(
    idBlessure Int Auto_increment NOT NULL PRIMARY KEY,
    typeBlessure Varchar (250),
    idBataille Int NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Promotions
#------------------------------------------------------------
CREATE TABLE Promotions(
    idPromotion Int Auto_increment NOT NULL PRIMARY KEY,
    idSoldat Int NOT NULL,
    idGrade Int NOT NULL,
    datePromotion Date NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Affectations
#------------------------------------------------------------
CREATE TABLE Affectations(
    idAffectation Int Auto_increment NOT NULL PRIMARY KEY,
    idUnite Int NOT NULL,
    idSoldat Int NOT NULL,
    dateAffectation Date NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Subits
#------------------------------------------------------------
CREATE TABLE Subits(
    idSubit Int Auto_increment NOT NULL PRIMARY KEY,
    idSoldat Int NOT NULL,
    idBlessure Int NOT NULL,
    dateSubitBlessure Date NOT NULL
) ENGINE = InnoDB;

ALTER TABLE Blessures ADD CONSTRAINT FK_Blessures_Batailles FOREIGN KEY (idBataille) REFERENCES Batailles(idBataille);

ALTER TABLE Promotions  
    ADD CONSTRAINT FK_Promotions_Soldats FOREIGN KEY (idSoldat) REFERENCES Soldats(idSoldat),
    ADD CONSTRAINT FK_Promotions_Grades FOREIGN KEY (idGrade) REFERENCES Grades(idGrade);
	
ALTER TABLE Affectations  
	ADD CONSTRAINT FK_Affectations_Unites FOREIGN KEY (idUnite) REFERENCES Unites(idUnite),
    ADD CONSTRAINT FK_Affectations_Soldats FOREIGN KEY (idSoldat) REFERENCES Soldats(idSoldat);
	
ALTER TABLE Subits 
	ADD CONSTRAINT FK_Subits_Soldats FOREIGN KEY (idSoldat) REFERENCES Soldats(idSoldat),
    ADD CONSTRAINT FK_Subits_Blessures FOREIGN KEY (idBlessure) REFERENCES Blessures(idBlessure);