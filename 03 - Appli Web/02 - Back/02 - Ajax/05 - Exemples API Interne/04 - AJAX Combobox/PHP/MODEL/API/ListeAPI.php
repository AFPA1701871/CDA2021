<?php

$id = $_POST['idRegion'];
echo json_encode( DepartementsManager::getListByRegion($id,true));
// var_dump($listeDepartement);
?>

