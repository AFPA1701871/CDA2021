USE StagiairesAfpa;

insert into groupes values (1,"Informatique");
insert into groupes values (2,"Automatisme");
insert into groupes values (3,"Reseau");

insert into formations values (1,"TSAII",2);
insert into formations values (2,"TRTE",3);
insert into formations values (3,"DWWM",1);
insert into formations values (4,"CDA",1);
insert into formations values (5,"TSSR",3);

insert into hebergements values (1,"AFPA");
insert into hebergements values (2,"AUTRE");

insert into formateurs values (null,"Poix","Martine");
insert into formateurs values (null,"Dubois","Thomas");
insert into formateurs values (null,"Butterdroghe","Hervé");
insert into formateurs values (null,"Batzic","Jean Paul");

insert into  animations values(null,2,5);
insert into  animations values(null,1,3);
insert into  animations values(null,2,2);
insert into  animations values(null,4,5);
insert into  animations values(null,1,4);
insert into  animations values(null,3,1);
insert into  animations values(null,4,3);
insert into  animations values(null,4,2);

insert into matieres values( 1,"Math");
insert into matieres values( 2,"Français");
insert into matieres values( 3,"Sport");

insert into constitutions values (null,1,1);
insert into constitutions values (null,1,2);
insert into constitutions values (null,1,3);
insert into constitutions values (null,2,1);
insert into constitutions values (null,2,2);
insert into constitutions values (null,2,3);
insert into constitutions values (null,3,1);
insert into constitutions values (null,3,2);
insert into constitutions values (null,3,3);
insert into constitutions values (null,4,1);
insert into constitutions values (null,4,2);
insert into constitutions values (null,4,3);

INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (1,"roblin","lea","12,bd de la liberte","calais",62100,"21345678","2014-09-01","F","1995-01-14",5,2,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (2,"macarthur","leon","121,bd gambetta","calais",62100,"21-30-65-09","2014-09-01","M","1994-04-12",3,1,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (3,"minol","luc","9,rue des prairies","boulogne",62200,"21-30-20-10","2014-09-01","M","1997-03-12",2,2,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (4,"minol","sophie","12,rue des capucines","wimereux",62930,"21-89-04-30","2014-09-01","F","1996-03-21",5,4,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (5,"minol","marc","67,allee ronde","marcq",62300,"21-90-87-65","2014-09-01","M","1993-02-05",3,1,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (6,"vendraux","marc","5,rue de marseille","calais",62100,"21-96-00-09","2013-09-01","M","1996-01-21",4,1,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (7,"vendermaele","helene","456,rue de paris","boulogne",62200,"21-45-45-60","2014-09-01","F","1995-03-30",5,2,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (8,"besson","loic","3,allee carpentier","dunkerque",59300,"28-90-89-78","2014-09-01","M","1994-05-21",1,3,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (9,"godart","jean-paul","123,rue de lens","marck",59870,"28-09-87-65","2013-09-01","M","1993-01-12",1,3,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (10,"beaux","marie","1,allee des cygnes","dunkerque",59100,"21-30-87-90","2014-09-01","F","1996-04-12",2,2,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (11,"turini","elsa","12,route de paris","boulogne",62200,"21-32-47-97","2014-09-01","F","1996-07-17",1,3,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (12,"torelle","elise","123,vallee du denacre","boulogne",62200,"21-67-86-90","2014-09-01","F","1997-04-16",3,1,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (13,"pharis","pierre","12,avenue foch","calais",62100,"21-21-85-90","2014-09-01","M","1996-03-18",4,1,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (14,"ephyre","luc","12,rue de lyon","calais",62100,"21-35-32-90","2014-09-01","M","1995-01-21",3,4,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (15,"leclercq","jules","12,allee des ravins","boulogne",62200,"21-36-71-92","2014-09-01","M","1994-05-19",3,1,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (16,"dupont","luc","21,avenue monsigny","calais",62200,"21-21-34-99","2014-09-01","M","1996-11-02",2,2,2);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (17,"marke","loic","312,route de paris","wimereux",62930,"21-87-87-71","2014-09-01","M","1996-11-12",5,4,1);
INSERT INTO `stagiaires`(`idStagiaire`, `nomStagiaire`, `prenomStagiaire`, `adresseStagiaire`, `ville`, `codePostal`, `telStagiaire`, `dateEntree`, `SexeStagiaire`, `dateNaissance`, `idFormation`, `idFormateur`, `idHebergement`) VALUES (18,"dewa","leon","121,allee des eglantines","dunkerque",59100,"28-30-87-90","2014-09-01","M","1997-04-03",2,4,1);

insert into suivis values ( 1,17,1,17);
insert into suivis values ( 2,3,2,16);
insert into suivis values ( 3,5,3,4);
insert into suivis values ( 4,18,1,0);
insert into suivis values ( 5,10,2,5);
insert into suivis values ( 6,12,2,4);
insert into suivis values ( 7,11,1,8);
insert into suivis values ( 8,1,3,19);
insert into suivis values ( 9,7,1,3);
insert into suivis values ( 10,15,3,17);
insert into suivis values ( 11,2,3,11);
insert into suivis values ( 12,16,3,7);
insert into suivis values ( 13,17,3,9);
insert into suivis values ( 14,11,2,16);
insert into suivis values ( 16,10,1,15);
insert into suivis values ( 17,15,2,0);
insert into suivis values ( 18,18,2,4);
insert into suivis values ( 20,14,2,14);
insert into suivis values ( 22,15,1,20);
insert into suivis values ( 23,3,1,12);
insert into suivis values ( 24,6,1,10);
insert into suivis values ( 25,8,3,0);
insert into suivis values ( 26,4,2,6);
insert into suivis values ( 27,5,1,10);
insert into suivis values ( 29,13,2,8);
