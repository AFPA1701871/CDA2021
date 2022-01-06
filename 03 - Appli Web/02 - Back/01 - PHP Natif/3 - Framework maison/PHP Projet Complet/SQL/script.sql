DROP DATABASE IF EXISTS baseproduits;

CREATE DATABASE IF NOT EXISTS baseproduits DEFAULT CHARACTER
SET utf8;

USE baseproduits;

DROP TABLE IF EXISTS categories;

CREATE TABLE IF NOT EXISTS categories (
  idCategorie int (11) NOT NULL AUTO_INCREMENT,
  LibelleCategorie varchar (50) NOT NULL,
  PRIMARY KEY (idCategorie)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS produits;

CREATE TABLE IF NOT EXISTS produits (
  idProduit int (11) NOT NULL AUTO_INCREMENT,
  libelleProduit varchar (50) NOT NULL,
  prix int (11) NOT NULL,
  dateDePeremption date NOT NULL,
  idCategorie int (11) NOT NULL,
  PRIMARY KEY (idProduit),
  KEY FK_Produit_Categorie (idCategorie)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS utilisateurs;

CREATE TABLE IF NOT EXISTS utilisateurs (
  idUtilisateur int(11) NOT NULL AUTO_INCREMENT,
  nom varchar(50) NOT NULL,
  prenom varchar(50) NOT NULL,
  motDePasse varchar(50) NOT NULL,
  adresseMail varchar(50) NOT NULL,
  role int(11) NOT NULL COMMENT '2 Admin 1 User',
  pseudo varchar(50) NOT NULL,
  PRIMARY KEY (idUtilisateur)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

DROP TABLE IF EXISTS `texte`;
CREATE TABLE IF NOT EXISTS texte (
  idTexte int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  codeTexte varchar(50) NOT NULL,
  FR text,
  EN text
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

ALTER TABLE produits
ADD   CONSTRAINT FK_Produit_Categorie FOREIGN KEY (idCategorie) REFERENCES categories (idCategorie);

INSERT INTO
  categories (idCategorie, LibelleCategorie)
VALUES   (1, 'périssable'),(2, 'éternel');

INSERT INTO   produits (idProduit, libelleProduit, prix, dateDePeremption, idCategorie  )
VALUES (1, 'gomme', 2, '2020-11-30', 1);

INSERT INTO   produits (idProduit, libelleProduit, prix, dateDePeremption, idCategorie  )
VALUES(2, 'crayon', 1, '2020-11-30', 2);

INSERT INTO `utilisateurs` (`idUtilisateur`, `nom`, `prenom`, `motDePasse`, `adresseMail`, `role`, `pseudo`) VALUES
(7, 'ad', 'ad', '11d437a3e6695447bd1bf2331651049e', 'ad', 2, 'ad'),
(8, 'u', 'u', '1d0a5a28d53430e7f2293a1f36682f23', 'u', 1, 'u');

INSERT INTO `texte`(`codeTexte`, `FR`, `EN`) VALUES 
("Accueil","Accueil","Home"),
("Identification","Identification","Identification"),
("Connexion","Connecter","Connect"),
("MotDePasse","Mot de Passe","Password"),
("Envoyer","Envoyer","Send"),
("Inscription","S'incrire","Register"),
("Nom","Nom","Name"),
("Prenom","Prenom","Surname"),
("ConfirmationMotDePasse","Confirmation du mot de passe","Confirm password"),
("AdresseEmail","Adresse Email","Email Adress"),
("Role","Role(1: user - 2: admin)","Role(1: user - 2: admin)"),
("Produits","Produits","Product"),
("Categories","Catégories","Category"),
("TexteMenu","Choisissez entre Produits et catégories","Choose between Product and Category"),
("Ajouter","Ajouter","Add"),
("Editer","Afficher","Show"),
("Modifier","Modifier","Modify"),
("Supprimer","Supprimer","Delete"),
("Libelle","Libelle","Description"),
("Prix","Prix","Price"),
("DatePeremption","Date de peremption","Expiry date"),
("TitreCrud"," un nouveau produit"," a new product"),
("Deconnecter","Deconnecter","Disconnect"),
("Bonjour","Bonjour","Hello"),
("Pseudo","Pseudo","Alias"),
("Annuler","Annuler","Cancel"),
("ListeProduits", "Liste de produits", "List product"),
("GestionProduit", "Gestion des produits", "Product management"),
("ListeCategories", "Liste des Catégories", "List Category"),
("GestionCategories", "Gestion des catégories", "Category management");