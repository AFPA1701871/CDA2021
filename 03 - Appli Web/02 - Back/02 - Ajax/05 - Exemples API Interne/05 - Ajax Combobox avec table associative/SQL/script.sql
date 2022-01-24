#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------
CREATE DATABASE essaiAPI;
USE essaiAPI;
#------------------------------------------------------------
# Table: Oeuvres
#------------------------------------------------------------
CREATE TABLE Oeuvres(
    idOeuvre Int Auto_increment NOT NULL PRIMARY KEY,
    titreOeuvre Varchar (250) NOT NULL,
    typeOeuvre Varchar (250) NOT NULL,
    dateOeuvre Date NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET=utf8;

#------------------------------------------------------------
# Table: Auteurs
#------------------------------------------------------------
CREATE TABLE Auteurs(
    idAuteur Int Auto_increment NOT NULL PRIMARY KEY,
    nomAuteur Varchar (250) NOT NULL,
    prenomAuteur Varchar (250) NOT NULL,
    dateNaissanceAuteur Date NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET=utf8;

#------------------------------------------------------------
# Table: Creations
#------------------------------------------------------------
CREATE TABLE Creations(
    idCreation INT Auto_increment PRIMARY KEY NOT NULL,
    idAuteur Int NOT NULL,
    idOeuvre Int NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE
    Creations
ADD
    CONSTRAINT Creations_Auteurs_FK FOREIGN KEY (idAuteur) REFERENCES Auteurs(idAuteur),
ADD
    CONSTRAINT Creations_Oeuvres_FK FOREIGN KEY (idOeuvre) REFERENCES Oeuvres(idOeuvre);

INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES ('Célestine du Bac','Livre','2021/05/12');
INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES ('Le serpent majuscule','Livre','2021/05/12');
INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES ('Bartleby mon frère','Livre','2021/05/06');
INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES ('Cette nuit-là','Livre','2021/05/06');
INSERT INTO Oeuvres(titreOeuvre,typeOeuvre,dateOeuvre) VALUES ('Toto','Film','2021/05/12');

INSERT INTO Auteurs(nomAuteur,prenomAuteur,dateNaissanceAuteur) VALUES ('de Rosnay','Tatiana','2005/05/05');
INSERT INTO Auteurs(nomAuteur,prenomAuteur,dateNaissanceAuteur) VALUES ('Lemaitre','Pierre','2005/05/05');
INSERT INTO Auteurs(nomAuteur,prenomAuteur,dateNaissanceAuteur) VALUES ('Pennac','Danniel','2005/05/05');
INSERT INTO Auteurs(nomAuteur,prenomAuteur,dateNaissanceAuteur) VALUES ('Hislop','Victoria','2005/05/05');

INSERT INTO Creations(idAuteur,idOeuvre) VALUES (1,1);
INSERT INTO Creations(idAuteur,idOeuvre) VALUES (2,2);
INSERT INTO Creations(idAuteur,idOeuvre) VALUES (3,3);
INSERT INTO Creations(idAuteur,idOeuvre) VALUES (4,4);
INSERT INTO Creations(idAuteur,idOeuvre) VALUES (4,5);

CREATE VIEW Auteurs_Oeuvres as
SELECT Auteurs.`idAuteur`,`nomAuteur`,`prenomAuteur`,`dateNaissanceAuteur`,Oeuvres.`idOeuvre`,`titreOeuvre`,`typeOeuvre`,`dateOeuvre`
FROM `Creations`
INNER JOIN Oeuvres
ON Creations.idOeuvre = Oeuvres.idOeuvre
INNER JOIN Auteurs
ON Creations.idAuteur = Auteurs.idAuteur
