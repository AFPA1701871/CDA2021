<?php
var_dump($_POST);
$mode = $_GET['mode'];

$obj = new Menus($_POST);
switch ($mode) {
    case "ajouter":
        {
            // sans protection, on appelle la fonction addMenu
            MenusManager::addMenu($_POST['libelleMenu']);
            // MenusManager::add($obj);
            break;
        }
    case "modifier":
        {
            MenusManager::update($obj);
            break;
        }
    case "supprimer":
        {
            $obj=new Menus(["idMenu"=>$_GET['id']]);
            MenusManager::delete($obj);
            break;
        }

}
header("location:index.php?page=ListeMenus");
