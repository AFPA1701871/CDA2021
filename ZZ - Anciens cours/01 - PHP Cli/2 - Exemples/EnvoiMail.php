
<?php
$prochainId = ProchainId::get();
if ($prochainId < 739) {
    $nbMail = 5;
    $nouveauId = (int) $prochainId + (int) $nbMail;
    $tableauMail = ClientManager::getList($prochainId, $nouveauId);
    $resultat = "";
    ProchainId::update($nouveauId);
    foreach ($tableauMail as $client) {
        $mail = $client->getMail();
        if (!preg_match("#^[a-z0-9._-]+@(hotmail|live|msn).[a-z]{2,4}$#", $mail)) // On filtre les serveurs qui rencontrent des bogues.
        {
            $passage_ligne = "\r\n";
        } else {
            $passage_ligne = "\n";
        }
        // =====Déclaration des messages au format texte et au format HTML.
        $message_txt = "Bla Bla ";
        $message_html = "<html><head></head><body><h1><b>Bla bla mis en forme</b></h1>";
        $message_html .= "<img src='http://chemin de l image sur le serveur.jpg' alt='desc image' width='600px'></body></html>";
        // ==========
        //=====Lecture et mise en forme de la pièce jointe. IMAGE
        $fichier = fopen("../../images/fichier.jpg", "r");
        $attachement = fread($fichier, filesize("../../images/fichier.jpg"));
        $attachement = chunk_split(base64_encode($attachement));
        fclose($fichier);

        /*mp*/
        $fichier = fopen("../../images/fichier.pdf", "r");
        $attachementPDF = fread($fichier, filesize("../../images/fichier.pdf"));
        $attachementPDF = chunk_split(base64_encode($attachementPDF));
        fclose($fichier);
        /*fin mp*/

        //==========
        // =====Création de la boundary
        $boundary = "-----=" . md5(rand());
        $boundary_alt = "-----=" . md5(rand());
        // ==========

        // =====Définition du sujet.
        $sujet = "mon sujet";
        // =========

        // =====Création du header de l'e-mail.
        $header = "From: \"nom presente\"<contact@domaine.com>" . $passage_ligne;
        $header .= "Reply-to: \"nom presente\"<contact@domaine.com>" . $passage_ligne;
        $header .= "MIME-Version: 1.0" . $passage_ligne;
        //$header .= "Content-Type: multipart/alternative;" . $passage_ligne . " boundary=\"$boundary\"" . $passage_ligne;

        $header .= "Content-Type: multipart/mixed;" . $passage_ligne . " boundary=\"$boundary\"" . $passage_ligne;
        // ==========

        //=====Création du message.
        $message = $passage_ligne . "--" . $boundary . $passage_ligne;
        $message .= "Content-Type: multipart/alternative;" . $passage_ligne . " boundary=\"$boundary_alt\"" . $passage_ligne;
        $message .= $passage_ligne . "--" . $boundary_alt . $passage_ligne;
//=====Ajout du message au format texte.
        $message .= "Content-Type: text/plain; charset=\"ISO-8859-1\"" . $passage_ligne;
        $message .= "Content-Transfer-Encoding: 8bit" . $passage_ligne;
        $message .= $passage_ligne . $message_txt . $passage_ligne;
//==========

        $message .= $passage_ligne . "--" . $boundary_alt . $passage_ligne;

//=====Ajout du message au format HTML.
        $message .= "Content-Type: text/html; charset=\"ISO-8859-1\"" . $passage_ligne;
        $message .= "Content-Transfer-Encoding: 8bit" . $passage_ligne;
        $message .= $passage_ligne . $message_html . $passage_ligne;
//==========

//=====On ferme la boundary alternative.
        $message .= $passage_ligne . "--" . $boundary_alt . "--" . $passage_ligne;
//==========

        $message .= $passage_ligne . "--" . $boundary . $passage_ligne;

//=====Ajout de la pièce jointe.
        $message .= "Content-Type: image/jpeg; name=\"fichier.jpg\"" . $passage_ligne;
        $message .= "Content-Transfer-Encoding: base64" . $passage_ligne;
        $message .= "Content-Disposition: attachment; filename=\"fichier.jpg\"" . $passage_ligne;
        $message .= $passage_ligne . $attachement . $passage_ligne . $passage_ligne;


        $message .= $passage_ligne . "--" . $boundary . $passage_ligne;
        $message .= "Content-Type: image/pdf; name=\"fichier.pdf\"" . $passage_ligne;
        $message .= "Content-Transfer-Encoding: base64" . $passage_ligne;
        $message .= "Content-Disposition: attachment; filename=\"fichier.pdf\"" . $passage_ligne;
        $message .= $passage_ligne . $attachementPDF . $passage_ligne . $passage_ligne;

//=====On ferme la boundary
        $message .= $passage_ligne . "--" . $boundary . "--" . $passage_ligne;
        // =====Envoi des e-mail.

        $res = mail($mail, $sujet, $message, $header);
        $resultat .= "<div id='mailenvoye'>mail envoyé à " . $mail . " : ";
        $resultat .= $res ? "ok" : "ko";
        $resultat .= "</div>";

    }
    echo $resultat;
/*compte rendu*/
    $to = 'toto@gmail.com';
    $subject = 'CR de ' . $prochainId . ' a ' . $nouveauId;
    $message_txt = 'CR de ' . $prochainId . ' a ' . $nouveauId;
    $message_html = '<html><head></head><body><div>cr de ' . $prochainId . ' a ' . $nouveauId . '</div><div>' . $resultat . '</div></body></html>';
    // =====Création du message.
    $message = $passage_ligne . "--" . $boundary . $passage_ligne;
    // =====Ajout du message au format texte.
    $message .= "Content-Type: text/plain; charset=\"ISO-8859-1\"" . $passage_ligne;
    $message .= "Content-Transfer-Encoding: 8bit" . $passage_ligne;
    $message .= $passage_ligne . $message_txt . $passage_ligne;
    // ==========
    $message .= $passage_ligne . "--" . $boundary . $passage_ligne;
    // =====Ajout du message au format HTML
    $message .= "Content-Type: text/html; charset=\"ISO-8859-1\"" . $passage_ligne;
    $message .= "Content-Transfer-Encoding: 8bit" . $passage_ligne;
    $message .= $passage_ligne . $message_html . $passage_ligne;
    // ==========
    $message .= $passage_ligne . "--" . $boundary . "--" . $passage_ligne;
    $message .= $passage_ligne . "--" . $boundary . "--" . $passage_ligne;
    // ==========

    echo $subject . "\n";
    $res = mail($to, $subject, $message, $header);
    echo "<div id='mailenvoye'>compte rendu " . $to . " : ";
    echo $res ? "ok" : "ko";
    echo "</div>";
}
?>