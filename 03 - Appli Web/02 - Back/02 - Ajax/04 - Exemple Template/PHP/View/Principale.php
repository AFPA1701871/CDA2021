<!-- Cette page est le contenu de la page principale du site; Elle présente la liste des parkings. -->

<div id="divSousTitre">
	<h3>Selectionner un point de retrait</h3>
	<button id="actu">Actualiser</button>
</div>
<div id="divContenu">
	<div class=" titreLigne">
		<div class="commune">Commune</div>
		<div class="nom">Nom</div>
		<div class="etat">Etat</div>
	</div>
	<div class="espaceHorizon"></div>
	<template id="ligne">
		<div class="ligne" id="">
			<div class="ville commune"></div>
			<div class="libelle nom"></div>
			<div class="etat"></div>
		</div>
	</template>
	<template id="espace">
		<div class="espaceHorizon"></div>
	</template>
</div>