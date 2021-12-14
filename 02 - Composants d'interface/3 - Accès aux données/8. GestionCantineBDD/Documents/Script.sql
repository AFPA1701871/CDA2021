#------------------------------------------------------------------------
#                             Script MySQL
#------------------------------------------------------------------------

DROP DATABASE IF EXISTS `GestionCantine`;
CREATE DATABASE  `GestionCantine` DEFAULT CHARACTER SET utf8;
USE `GestionCantine`;

-- 
-- Table structures for table `Roles`
--
CREATE TABLE Roles(
   IdRole INT AUTO_INCREMENT PRIMARY KEY,
   LibelleRole VARCHAR(50) 
)ENGINE=InnoDB;

-- 
-- Table structures for table `Eleves`
--
CREATE TABLE Eleves(
   IdEleve INT AUTO_INCREMENT PRIMARY KEY,
   NomEleve VARCHAR(150) ,
   PrenomEleve VARCHAR(150) ,
   DDNEleve DATE,
   SoldeEleve DOUBLE
)ENGINE=InnoDB;

-- 
-- Table structures for table `ModesDePaiement`
--
CREATE TABLE ModesDePaiement(
   IdModeDePaiement INT AUTO_INCREMENT PRIMARY KEY,
   LibelleModeDePaiement VARCHAR(50)
)ENGINE=InnoDB;

-- 
-- Table structures for table `Users`
--
CREATE TABLE Users(
   IdUser INT AUTO_INCREMENT PRIMARY KEY,
   NomUser VARCHAR(150) ,
   PrenomUser VARCHAR(150) ,
   EmailUser VARCHAR(200) ,
   MDPUser VARCHAR(50) ,
   IdRole INT NOT NULL
)ENGINE=InnoDB;

-- 
-- Table structures for table `Menus`
--
CREATE TABLE Menus(
   IdMenu INT AUTO_INCREMENT PRIMARY KEY,
   DateMenu DATE,
   LibelleMenu VARCHAR(50) ,
   PrixMenu DOUBLE,
   IdPlat INT NOT NULL,
   IdEntree INT NOT NULL,
   IdDessert INT NOT NULL
)ENGINE=InnoDB;

-- 
-- Table structures for table `Paiements`
--
CREATE TABLE Paiements(
   IdPaiement INT AUTO_INCREMENT PRIMARY KEY,
   MontantPaiement DOUBLE,
   DatePaiement DATE,
   IdEleve INT NOT NULL,
   IdModeDePaiement INT NOT NULL
)ENGINE=InnoDB;

-- 
-- Table structures for table `Reservation`
--
CREATE TABLE Reservations(
   IdReservation INT AUTO_INCREMENT PRIMARY KEY,
   IdEleve INT,
   IdMenu INT,
   DateReservation DATE
)ENGINE=InnoDB;




ALTER TABLE
    Reservations
ADD
    CONSTRAINT FK_Reservations_Eleves FOREIGN KEY(IdEleve) REFERENCES Eleves(IdEleve),
ADD
    CONSTRAINT FK_Reservations_Menus FOREIGN KEY(IdMenu) REFERENCES Menus(IdMenu);

ALTER TABLE
    Paiements
ADD
    CONSTRAINT FK_Paiements_Eleves FOREIGN KEY(IdEleve) REFERENCES Eleves(IdEleve),
ADD
    CONSTRAINT FK_Paiements_ModesDePaiement FOREIGN KEY(IdModeDePaiement) REFERENCES ModesDePaiement(IdModeDePaiement);

ALTER TABLE
    Users
ADD
    CONSTRAINT FK_Users_Roles FOREIGN KEY(IdRole) REFERENCES Roles(IdRole);