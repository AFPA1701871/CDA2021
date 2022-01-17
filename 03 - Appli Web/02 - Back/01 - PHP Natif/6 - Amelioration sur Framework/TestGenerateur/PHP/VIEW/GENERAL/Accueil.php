<?php
echo "test2";
/*$test2 = new Test2avecmaj(["libAvecMaj"=>"t2","num"=>3,"dat"=>"2019-01-21"]);
var_dump($test2);
Test2avecmajManager::add($test2);
*/
 $test1= new Test1(["idTest1"=>1,"libtest1"=>"t2","idtest2"=>4]);
 var_dump( Test1Manager::delete($test1));
