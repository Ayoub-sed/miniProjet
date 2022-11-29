import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ParametragesRoutingModule } from './Paramétrages/parametrages-routing.module';
import { ParametragesModule } from './Paramétrages/parametrages.module';
import { OAuthModule } from 'angular-oauth2-oidc';
import { GeneralLayoutComponent } from './general-layout/general-layout.component';
import { MatNativeDateModule } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { HeaderNavbarComponent } from './navbar/header-navbar/header-navbar.component';
import { SidebarLeftComponent } from './navbar/sidebar-left/sidebar-left.component';
import { FooterLeftComponent } from './navbar/footer-left/footer-left.component';
import { FooterRightComponent } from './navbar/footer-right/footer-right.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { GrilleControleComponent } from './GrilleControle/grille-controle/grille-controle.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { FicheSuiviComponent } from './FicheSuivi/fiche-suivi/fiche-suivi.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { FraisInterventionComponent } from './FraisIntervention/frais-intervention/frais-intervention.component';
import { ListFraisInterventionComponent } from './FraisIntervention/list-frais-intervention/list-frais-intervention.component';
import { PostUpdateFraisInterventionComponent } from './FraisIntervention/post-update-frais-intervention/post-update-frais-intervention.component';
import { GetFraisInterventionComponent } from './FraisIntervention/get-frais-intervention/get-frais-intervention.component';
import { ChooseFilialeComponent } from './GrilleControle/choose-filiale/choose-filiale.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderNavbarComponent,
    SidebarLeftComponent,
    GeneralLayoutComponent,
    FooterLeftComponent,
    FooterRightComponent,
    GrilleControleComponent,
    FicheSuiviComponent,
    FraisInterventionComponent,
    ListFraisInterventionComponent,
    PostUpdateFraisInterventionComponent,
    GetFraisInterventionComponent,
    ChooseFilialeComponent
    
    ],
    schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  imports: [
   ParametragesRoutingModule,
   ParametragesModule,
    CoreModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatAutocompleteModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    NgxPaginationModule,
    MatSortModule,
    MatNativeDateModule,
    NgSelectModule,
    MatFormFieldModule,
    Ng2SearchPipeModule,
    OAuthModule.forRoot({
      resourceServer: {
        allowedUrls: ['http://192.168.160.74:31633/review-identityserver/api/'],
        sendAccessToken: true
      }
    }),
    
  ],
  providers: [DatePipe
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    GeneralLayoutComponent,
  ]
})
export class AppModule { }
