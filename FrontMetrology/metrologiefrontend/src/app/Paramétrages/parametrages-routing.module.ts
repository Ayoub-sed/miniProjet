import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetDeleteDomaineComponent } from './Gestion Domaine/get-delete-domaine/get-delete-domaine.component';
import { CritereGetDeleteComponent } from './Gestion Critere/critere-get-delete/critere-get-delete.component';
import { GetDeletePrestatireComponent } from './Gestion Prestataire/get-delete-prestatire/get-delete-prestatire.component';
import { GetDeleteUserComponent } from './Gestion User/get-delete-user/get-delete-user.component';
import { GetDeleteEquipementComponent } from './Gestion equipement/get-delete-equipement/get-delete-equipement.component';
import { GetDeleteAffectationFilialeCritereComponent } from './Affectation Critere Filiale/get-delete-affectation-filiale-critere/get-delete-affectation-filiale-critere.component';
import { AddUpdateEquipementComponent } from './Gestion equipement/add-update-equipement/add-update-equipement.component';
import { GetDeleteTypeInterventionComponent } from './Gestion Type intervention/get-delete-type-intervention/get-delete-type-intervention.component';
import { GrilleControleComponent } from '../GrilleControle/grille-controle/grille-controle.component';
import { FicheSuiviComponent } from '../FicheSuivi/fiche-suivi/fiche-suivi.component';




const routes: Routes = [
  {path:'HomePage',component: FicheSuiviComponent},
  {path:'GestionUtilisateur',component: GetDeleteUserComponent},
  {path:'GestionPrestataire',component: GetDeletePrestatireComponent},
  {path:'GestionDomaine',component: GetDeleteDomaineComponent},  
  {path:'GestionCritere',component: CritereGetDeleteComponent},
  {path:'GestionEquipement',component: GetDeleteEquipementComponent},
  {path:'GestionTypeIntervention',component: GetDeleteTypeInterventionComponent},
  {path:'AffectationFilialeCritere',component: GetDeleteAffectationFilialeCritereComponent},


  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParametragesRoutingModule { }
