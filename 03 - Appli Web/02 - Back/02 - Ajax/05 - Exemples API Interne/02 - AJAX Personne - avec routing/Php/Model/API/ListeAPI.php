<?php
//fichier pour appel AJAX
echo json_encode(PersonneManager::getList(true));
