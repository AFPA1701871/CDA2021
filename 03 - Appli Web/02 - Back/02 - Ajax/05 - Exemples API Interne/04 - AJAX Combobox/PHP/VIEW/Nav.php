<?php

if (isset($_SESSION['utilisateur']))
{
	if ($_SESSION['utilisateur']->getRoleUser() == 1)
	{
		echo '<button><a href="index.php?codePage=admin">'.texte('admin').'</a></button>';
	}
	echo '<button><a href="index.php?codePage=user">'.texte('user').'</a></button>';
}