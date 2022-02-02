    
</main>
<div class="mini"></div>
    </section>
<footer>
<div class="colonne center">
   <div class="titre">Services et Garanties</div>
   <div>Garanties et assurances</div>
   <div>Mon espace Client</div>
   <div>Nos magasins</div>
</div>
<div class="colonne center">
   <div class="titre">Livraison et paiement</div>
   <div>Les modes et frais de livraison</div>
   <div>Livraison en europe</div>
   <div>Livraison à l'international</div>
</div>
<div class="colonne center">
   <div class="titre">Contactez nous</div>
   <div>Contact Service Client</div>
   <div>Contact publicité</div>
   <div>Recrutement</div>
</div>

</footer>
<?php
if($page[1]="FormArticles") echo ' <script src="./JS/FormArticles.js"></script>';
 if (substr($page[1],0,4)=="Form"){
    echo ' <script src="./JS/VerifForm.js"></script>';
 }
 echo ' <script src="./JS/script.js"></script>';
echo '</body>
</html>';