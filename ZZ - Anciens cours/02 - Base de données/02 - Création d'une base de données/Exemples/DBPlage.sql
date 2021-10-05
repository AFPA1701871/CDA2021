DROP DATABASE IF EXISTS GestionPlage;
CREATE DATABASE GestionPlage;
USE GestionPlage;

CREATE TABLE NatureDeTerrain(
	idNatureDeTerrain int(11) not NULL auto_increment PRIMARY KEY,
	typeDeTerrain varchar(50)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE Plage(
	idPlage int(11) not NULL auto_increment PRIMARY KEY,
	kilomettres int(11),
	idVille int(11)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE Detient(
	idDetient int(11) not NULL auto_increment PRIMARY KEY,
	idPlage int(11),
	idNatureDeTerrain int(11)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE Ville(
	idVille int(11) not NULL auto_increment PRIMARY KEY,
	nomVille varchar(50),
	codePostal varchar(5),
	nbTouristeAn int(11),
	idDepartement int(11)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE Departement(
	idDepartement int(11) not NULL auto_increment PRIMARY KEY,
	nomDepartement varchar(50),
	idRegion int(11)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE Region(
	idRegion int(11) not NULL auto_increment PRIMARY KEY,
	nomRegion varchar(50),
	nomResponsable varchar(50),
	prenomResponsable varchar(50)
)ENGINE = InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Detient ADD CONSTRAINT FK_detient_Plage FOREIGN KEY (idPlage) REFERENCES Plage(idPlage);
ALTER TABLE Detient ADD CONSTRAINT FK_detient_NatureDeTerrain FOREIGN KEY (idNatureDeTerrain) REFERENCES NatureDeTerrain(idNatureDeTerrain);
ALTER TABLE Plage ADD CONSTRAINT FK_Plage_Ville FOREIGN KEY (idVille) REFERENCES Ville(idVille);
ALTER TABLE Ville ADD CONSTRAINT FK_Ville_Departement FOREIGN KEY (idDepartement) REFERENCES Departement(idDepartement);
ALTER TABLE Departement ADD CONSTRAINT FK_Departement_Region FOREIGN KEY (idRegion) REFERENCES Region(idRegion);