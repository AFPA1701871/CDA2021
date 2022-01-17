<?php
 $r = new Regions(["reg_v_nom"=>"test","reg_nb_dep"=>3]);
 RegionsManager::add($r);
 $r = RegionsManager::findById(15);
 $r2 = RegionsManager::findById(16);
$r->setReg_nb_dep(1);
var_dump($r);
RegionsManager::update($r);
RegionsManager::delete($r2);