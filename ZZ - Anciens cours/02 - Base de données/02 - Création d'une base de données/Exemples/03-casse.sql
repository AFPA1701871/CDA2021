#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------
DROP DATABASE IF EXISTS casse;

CREATE DATABASE casse;

USE casse;

#------------------------------------------------------------
# Table: Categories
#------------------------------------------------------------
CREATE TABLE casse.Categories(
    idCategorie Int Auto_increment NOT NULL PRIMARY KEY,
    libelleCategorie Varchar (50) NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Marques
#------------------------------------------------------------
CREATE TABLE casse.Marques(
    idMarque Int Auto_increment NOT NULL PRIMARY KEY,
    libelleMarque Varchar (50) NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Modele
#------------------------------------------------------------
CREATE TABLE casse.Modele(
    idModele Int Auto_increment NOT NULL PRIMARY KEY,
    libelleModele Varchar (50) NOT NULL,
    anneeModele Date NOT NULL,
    idMarque Int NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: TypePieces
#------------------------------------------------------------
CREATE TABLE casse.TypePieces(
    idTypePiece Int Auto_increment NOT NULL PRIMARY KEY,
    libelleType Varchar (50) NOT NULL,
    reference Varchar (50) NOT NULL,
    idCategorie Int NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: Pieces
#------------------------------------------------------------
CREATE TABLE casse.Pieces(
    idPiece Int Auto_increment NOT NULL PRIMARY KEY,
    libellePiece Varchar (50) NOT NULL,
    dateRecup Date NOT NULL,
    prixVente Double NOT NULL,
    idTypePiece Int NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Table: correspondance
#------------------------------------------------------------
CREATE TABLE casse.correspondance(
    idCorrespondance Int Auto_increment NOT NULL PRIMARY KEY,
    idTypePiece Int NOT NULL,
    idModele Int NOT NULL
) ENGINE = InnoDB;

#------------------------------------------------------------
# Clés Etrangères
#------------------------------------------------------------
ALTER TABLE
    casse.modele
ADD
    CONSTRAINT Modele_Marques_FK FOREIGN KEY (idMarque) REFERENCES Marques(idMarque);

ALTER TABLE
    casse.TypePieces
ADD
    CONSTRAINT TypePieces_Categories_FK FOREIGN KEY (idCategorie) REFERENCES Categories(idCategorie);

ALTER TABLE
    casse.Pieces
ADD
    CONSTRAINT Pieces_TypePieces_FK FOREIGN KEY (idTypePiece) REFERENCES TypePieces(idTypePiece);

ALTER TABLE
    casse.correspondance
ADD
    CONSTRAINT correspondance_TypePieces_FK FOREIGN KEY (idTypePiece) REFERENCES TypePieces(idTypePiece);

ALTER TABLE
    casse.correspondance
ADD
    CONSTRAINT correspondance_Modele0_FK FOREIGN KEY (idModele) REFERENCES Modele(idModele);