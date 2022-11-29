import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FicheSuiviComponent } from './FicheSuivi/fiche-suivi/fiche-suivi.component';

import { FraisInterventionComponent } from './FraisIntervention/frais-intervention/frais-intervention.component';
import { ListFraisInterventionComponent } from './FraisIntervention/list-frais-intervention/list-frais-intervention.component';

import { ChooseFilialeComponent } from './GrilleControle/choose-filiale/choose-filiale.component';

import { GrilleControleComponent } from './GrilleControle/grille-controle/grille-controle.component';
import { ChooseFilialeForEquipementsComponent } from './Paramétrages/Gestion equipement/choose-filiale-for-equipements/choose-filiale-for-equipements.component';
import { GetDeleteEquipementComponent } from './Paramétrages/Gestion equipement/get-delete-equipement/get-delete-equipement.component';

const routes: Routes = [

  {path:'GrilleControle',component: ChooseFilialeComponent},
  {path: 'ListChooseFiliale/:fkfiliale/:label', component: GrilleControleComponent},
  {path:'ListEquipement',component: ChooseFilialeForEquipementsComponent},
  {path: 'ChooseFilialeEquipements/:fkfiliale/:label', component: GetDeleteEquipementComponent},
  {path:'',component: FicheSuiviComponent},
  {path: 'FraisIntervention', component: FraisInterventionComponent},
  {path: 'ListFraisIntervention/:fkfiliale/:label', component: ListFraisInterventionComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
