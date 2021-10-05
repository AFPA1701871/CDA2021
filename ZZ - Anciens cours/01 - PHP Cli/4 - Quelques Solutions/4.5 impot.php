<?php
$age = readline("Donnez votre age : ");
$genre = readline("Donnez votre genre (homme/femme) : ");

if (($genre == "homme" && $age > 20) || ($genre == "femme" && $age > 18 && $age < 35))
{
    echo "Imposable";
}
else
{
    echo "Pas imposable";
}
