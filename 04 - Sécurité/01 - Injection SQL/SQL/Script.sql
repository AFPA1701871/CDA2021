CREATE DATABASE Injection_SQL;

USE Injection_SQL;

CREATE TABLE Test(
    idTest Int
);

CREATE TABLE Menus(
    idMenu Int Auto_increment NOT NULL PRIMARY KEY,
    libelleMenu Varchar (50) NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Plats(
    idPlat Int Auto_increment NOT NULL PRIMARY KEY,
    libellePlat Varchar (50) NOT NULL,
    nbCalories Int NOT NULL,
    idMenu Int NOT NULL
) ENGINE = InnoDB;

ALTER TABLE
    Plats
ADD
    CONSTRAINT Plats_Menus_FK FOREIGN KEY (idMenu) REFERENCES Menus(idMenu);


INSERT INTO `menus` (`idMenu`, `libelleMenu`) VALUES(1, 'lundi');
INSERT INTO `menus` (`idMenu`, `libelleMenu`) VALUES(2, 'mardi');

INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(1, 'pates Carbo', 120, 1);
INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(2, 'pates bolo', 100, 2);
INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(3, 'terrine de campagne', 50, 1);
INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(4, 'soupe de poissons', 40, 2);
INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(5, 'gateau au chocolat', 150, 1);
INSERT INTO `plats` (`idPlat`, `libellePlat`, `nbCalories`, `idMenu`) VALUES(6, 'pomme', 40, 2);