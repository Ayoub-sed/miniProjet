import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ParametragesRoutingModule } from './parametrages-routing.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSlideToggleModule} from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule} from 'ngx-pagination'; 
import { NgSelectModule } from '@ng-select/ng-select';
import { GetDeleteUserComponent } from './Gestion User/get-delete-user/get-delete-user.component';
import { PostUpdateUserComponent } from './Gestion User/post-update-user/post-update-user.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { GetDeletePrestatireComponent } from './Gestion Prestataire/get-delete-prestatire/get-delete-prestatire.component';
import { AddUpdatePrestataireComponent } from './Gestion Prestataire/add-update-prestataire/add-update-prestataire.component';
import { AddUpdateDomaineComponent } from './Gestion Domaine/add-update-domaine/add-update-domaine.component';
import { GetDeleteDomaineComponent } from './Gestion Domaine/get-delete-domaine/get-delete-domaine.component';
import { CriterePostUpdateComponent } from './Gestion Critere/critere-post-update/critere-post-update.component';
import { CritereGetDeleteComponent } from './Gestion Critere/critere-get-delete/critere-get-delete.component';
import { AddUpdateAffectationFilialeCritereComponent } from './Affectation Critere Filiale/add-update-affectation-filiale-critere/add-update-affectation-filiale-critere.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { GetDeleteAffectationFilialeCritereComponent } from './Affectation Critere Filiale/get-delete-affectation-filiale-critere/get-delete-affectation-filiale-critere.component';
import { AddUpdateEquipementComponent } from './Gestion equipement/add-update-equipement/add-update-equipement.component';
import { GetDeleteEquipementComponent } from './Gestion equipement/get-delete-equipement/get-delete-equipement.component';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { PontBasculeFormComponent } from './Gestion equipement/pont-bascule-form/pont-bascule-form.component';
import { AddUpdateTypeInterventionComponent } from './Gestion Type intervention/add-update-type-intervention/add-update-type-intervention.component';
import { GetDeleteTypeInterventionComponent } from './Gestion Type intervention/get-delete-type-intervention/get-delete-type-intervention.component';
import { GrilleControleComponent } from '../GrilleControle/grille-controle/grille-controle.component';
import { BainFormComponent } from './Gestion equipement/bain-form/bain-form.component';
import { ThermohygometreFormComponent } from './Gestion equipement/thermohygometre-form/thermohygometre-form.component';
import { TunnelDeRefroidissementFormComponent } from './Gestion equipement/tunnel-de-refroidissement-form/tunnel-de-refroidissement-form.component';
import { TransmtteurDePressionComponent } from './Gestion equipement/transmtteur-de-pression/transmtteur-de-pression.component';
import { SondeRedoxComponent } from './Gestion equipement/sonde-redox/sonde-redox.component';
import { RefregirateurFormComponent } from './Gestion equipement/refregirateur-form/refregirateur-form.component';
import { ManometreDePressionComponent } from './Gestion equipement/manometre-de-pression/manometre-de-pression.component';
import { FourDormComponent } from './Gestion equipement/four-dorm/four-dorm.component';
import { EtuveFormComponent } from './Gestion equipement/etuve-form/etuve-form.component';
import { DebimetreMassiqueFormComponent } from './Gestion equipement/debimetre-massique-form/debimetre-massique-form.component';
import { DebimetreVolumetriqueFormComponent } from './Gestion equipement/debimetre-volumetrique-form/debimetre-volumetrique-form.component';
import { ChambreFroideComponent } from './Gestion equipement/chambre-froide/chambre-froide.component';
import { ConductivimetreFormComponent } from './Gestion equipement/conductivimetre-form/conductivimetre-form.component';
import { EnsacheuseFormComponent } from './Gestion equipement/ensacheuse-form/ensacheuse-form.component';
import { ThermometreFormComponent } from './Gestion equipement/thermometre-form/thermometre-form.component';
import { CapteurDePressionFormComponent } from './Gestion equipement/capteur-de-pression-form/capteur-de-pression-form.component';
import { ChooseFilialeForEquipementsComponent } from './Gestion equipement/choose-filiale-for-equipements/choose-filiale-for-equipements.component';
import { BalanceElectroniqueComponent } from './Gestion equipement/balance-electronique/balance-electronique.component';
import { PhMetreComponent } from './Gestion equipement/ph-metre/ph-metre.component';




@NgModule({
      declarations:  [
        PhMetreComponent,
      BalanceElectroniqueComponent,
      GetDeleteUserComponent,
      PostUpdateUserComponent,
      GetDeletePrestatireComponent,
      AddUpdatePrestataireComponent,
      AddUpdateDomaineComponent,
      GetDeleteDomaineComponent,
      CriterePostUpdateComponent,
      CritereGetDeleteComponent,
      AddUpdateEquipementComponent,
      GetDeleteEquipementComponent,
      AddUpdateAffectationFilialeCritereComponent,
      GetDeleteAffectationFilialeCritereComponent,
      PontBasculeFormComponent,
      AddUpdateTypeInterventionComponent,
      GetDeleteTypeInterventionComponent,
      BainFormComponent,
      ThermohygometreFormComponent,
      TunnelDeRefroidissementFormComponent,
      TransmtteurDePressionComponent,
      SondeRedoxComponent,
      RefregirateurFormComponent,
      ManometreDePressionComponent,
      FourDormComponent,
      EtuveFormComponent,
      DebimetreMassiqueFormComponent,
      DebimetreVolumetriqueFormComponent,
      ChambreFroideComponent,
      ConductivimetreFormComponent,
      EnsacheuseFormComponent,
      ThermometreFormComponent,
      CapteurDePressionFormComponent,
      ChooseFilialeForEquipementsComponent,
     


      ],

      entryComponents : [
      PostUpdateUserComponent
      ],  
      
      imports: [
    CommonModule,
    CoreModule,
    ParametragesRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatAutocompleteModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    ModalModule.forRoot(),
    MatSortModule,
    MatSnackBarModule,
    Ng2SearchPipeModule,
    NgxPaginationModule,
    NgSelectModule,
    MatSlideToggleModule,
    NgxSpinnerModule,

  ]
  
})
export class ParametragesModule { }
