CREATE DATABASE region_departement;

USE region_departement;

CREATE TABLE `region_departement`.`regions` (
    `idRegion` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `libelleRegion` VARCHAR(50) NOT NULL,
    `numeroRegion` INT NOT NULL,
    `nombreDepartement` INT NOT NULL
) ENGINE = InnoDB;

CREATE TABLE `region_departement`.`departements` (
    `idDepartement` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `numeroDepartement` VARCHAR(3) NOT NULL,
    `libelleDepartement` VARCHAR(50) NOT NULL,
    `idRegion` INT NULL
) ENGINE = InnoDB;

ALTER TABLE
    `departements`
ADD CONSTRAINT `FK_Departement_region` 
    FOREIGN KEY (`idRegion`) REFERENCES `regions`(`idRegion`);


/* Remplissage Région*/
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Auvergne-Rhône-Alpes",1,12);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Bourgogne-Franche-Comté",2,8);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Bretagne",3,4);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Centre-Val de Loire",4,6);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Corse",5,2);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Grand-Est",6,10);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Hauts-de-France",7,5);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Ile-de-France",8,8);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Normandie",9,5);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Nouvelle-Aquitaine",10,12);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Occitanie",11,13);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Pays de la Loire",12,5);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("Provence-Alpes-Côte d'Azur",13,6);
INSERT INTO `regions`( `libelleRegion`, `numeroRegion`, `nombreDepartement`) VALUES ("DOM-TOM",14,12);


/* Remplissage Departement */

INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("1","Ain",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("2","Aisne",7);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("3","Allier",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("4","Alpes-de-Haute-Provence",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("5","Hautes-Alpes",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("6","Alpes-Maritimes",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("7","Ardèche",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("8","Ardennes",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("9","Ariège",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("10","Aube",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("11","Aude",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("12","Aveyron",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("13","Bouches-du-Rhône",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("14","Calvados",9);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("15","Cantal",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("16","Charente",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("17","Charente-Maritime",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("18","Cher",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("19","Correze",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("21","Côte-d'Or",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("22","Côtes-d'Armor",3);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("23","Creuse",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("24","Dordogne",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("25","Doubs",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("26","Drôme",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("27","Eure",9);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("28","Eure-et-Loir",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("29","Finistère",3);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("2A","Corse-du-Sud",5);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("2B","Haute-Corse ",5);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("30","Gard",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("31","Haute-Garonne",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("32","Gers",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("33","Gironde",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("34","Hérault",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("35","Ille-et-Vilaine",3);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("36","Indre",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("37","Indre-et-Loire",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("38","Isère",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("39","Jura",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("40","Landes",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("41","Loir-et-Cher",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("42","Loire",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("43","Haute-Loire",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("44","Loire-Atlantique",12);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("45","Loiret",4);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("46","Lot",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("47","Lot-et-Garonne",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("48","Lozère",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("49","Maine-et-Loire",12);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("50","Manche",9);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("51","Marne",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("52","Haute-Marne",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("53","Mayenne",12);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("54","Meurthe-et-Moselle",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("55","Meuse",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("56","Morbihan",3);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("57","Moselle",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("58","Nièvre",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("59","Nord",7);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("60","Oise",7);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("61","Orne",9);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("62","Pas-de-Calais",7);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("63","Puy-de-Dôme",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("64","Pyrénées-Atlantiques",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("65","Hautes-Pyrénées",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("66","Pyrénées-Orientales",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("67","Bas-Rhin",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("68","Haut-Rhin",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("69","Rhône",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("70","Haute-Saône",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("71","Saône-et-Loire",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("72","Sarthe",12);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("73","Savoie",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("74","Haute-Savoie",1);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("75","Paris",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("76","Seine-Maritime",9);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("77","Seine-et-Marne",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("78","Yvelines",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("79","Deux-Sèvres",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("80","Somme",7);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("81","Tarn",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("82","Tarn-et-Garonne",11);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("83","Var",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("84","Vaucluse",13);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("85","Vendée",12);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("86","Vienne",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("87","Haute-Vienne",10);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("88","Vosges",6);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("89","Yonne",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("90","Territoire de Belfort",2);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("91","Essonne",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("92","Hauts-de-Seine",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("93","Seine-Saint-Denis",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("94","Val-de-Marne",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("95","Val-d'Oise",8);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("971","Guadeloupe",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("972","Martinique",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("973","Guyane",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("974","La Réunion",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("975","Saint-Pierre-et-Miquelon",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("977","Saint-Barthélemy",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("978","Saint-Martin",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("984","Terres australes et antarctiques françaises",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("986","Wallis-et-Futuna",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("987","Polynésie française",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("988","Nouvelle-Calédonie",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`, `idRegion`) VALUES ("989","Clipperton",14);
INSERT INTO `departements`( `numeroDepartement`, `libelleDepartement`) VALUES ("976","Mayotte");
