<?php
class ProduitsManager
{
    public static function add(Produits $obj)
    {
        $db = DbConnect::getDb();
        $q = $db->prepare("INSERT INTO Produits (libelleProduit,prix,dateDePeremption,idCategorie) VALUES (:libelleProduit,:prix,:dateDePeremption,:idCategorie)");
        $q->bindValue(":libelleProduit", $obj->getLibelleProduit());
        $q->bindValue(":prix", $obj->getPrix());
        $q->bindValue(":dateDePeremption", $obj->getDateDePeremption());
        $q->bindValue(":idCategorie", $obj->getIdCategorie());
        $q->execute();
    }

    public static function update(Produits $obj)
    {
        $db = DbConnect::getDb();
        $q = $db->prepare("UPDATE Produits SET libelleProduit=:libelleProduit, prix=:prix, dateDePeremption=:dateDePeremption, idCategorie=:idCategorie WHERE idProduit=:idProduit");
        $q->bindValue(":libelleProduit", $obj->getLibelleProduit());
        $q->bindValue(":prix", $obj->getPrix());
        $q->bindValue(":dateDePeremption", $obj->getDateDePeremption());
        $q->bindValue(":idCategorie", $obj->getIdCategorie());
        $q->bindValue(":idProduit", $obj->getIdProduit());
        $q->execute();
    }

    public static function delete(Produits $obj)
    {
        $db = DbConnect::getDb();
        $db->exec("DELETE FROM Produits WHERE idProduit=" . $obj->getIdProduit());
    }

    public static function findById($id)
    {
        $db = DbConnect::getDb();
        $id = (int) $id;  // on verifie que id est numerique, evite l'injection SQL
        $q = $db->query("SELECT * FROM Produits WHERE idProduit=" . $id);
        $results = $q->fetch(PDO::FETCH_ASSOC);
        if ($results != false)
        {
            return new Produits($results);
        }
        else
        {
            return false;
        }
    }

    public static function getList()
    {
        $db = DbConnect::getDb();
        $liste = [];
        $q = $db->query("SELECT * FROM Produits");
        while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
        {
            if ($donnees != false)
            {
                $liste[] = new Produits($donnees);
            }
        }
        return $liste;  // tableau contenant les objets Produits
    }

    public static function getListByCategorie($idCategorie)
    {
        $idCategorie=(int) $idCategorie;
        $db = DbConnect::getDb();
        $liste = [];
        $q = $db->query("SELECT * FROM Produits where idCategorie=$idCategorie");
        while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
        {
            if ($donnees != false)
            {
                $liste[] = new Produits($donnees);
            }
        }
        return $liste;  // tableau contenant les objets Produits
    }
}
