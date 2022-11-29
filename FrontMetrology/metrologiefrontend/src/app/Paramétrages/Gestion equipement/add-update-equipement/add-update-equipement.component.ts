import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';
import { PontsBasculeElectroniqueService } from 'src/app/core/service/Parametrage/ponts-bascule-electronique.service';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import { Equipement } from 'src/app/core/modeles/Parametrage/Equipement';
import { DatePipe, formatDate } from '@angular/common';

@Component({
  selector: 'app-add-update-equipement',
  templateUrl: './add-update-equipement.component.html',
  styleUrls: ['./add-update-equipement.component.css']
})
export class AddUpdateEquipementComponent implements OnInit {
  @Input() fk: string;
  listeEquipements: any[];
  displayForm = false;
  nomEquipement: string;
  natureEquipement: number;
  x: number = 5;
  selected = 1;
  selected1 = 2;
  dateE: string;
  dateV: string;
  nL: string;
  constructor(
    public userService: UserService,
    public equipementservice: EquipementService,
    public bsModalRef: BsModalRef,
    public datePipe: DatePipe,
    public SpinnerService: NgxSpinnerService,
    public pontsBasculeElectroniqueService: PontsBasculeElectroniqueService
  ) { }

  ngOnInit(): void {
    
    if (this.userService.Method == "Put" || this.userService.Method == "Detail") {
      this.displayForm = true;
      if (this.equipementservice.formEquipement.value.type == "NonReglementaire") {

        this.selected = 1
        this.listeEquipements = [] // ????
        this.listeEquipements =
          [
            { id: 0, libelle: "Thermometre" },
            { id: 1, libelle: "Thermohygometre" },
            { id: 2, libelle: "Bain" },
            { id: 3, libelle: "CapteurDePression" },
            { id: 4, libelle: "PhMetre" },
            { id: 5, libelle: "Four" },
            { id: 6, libelle: "Etuve" },
            { id: 7, libelle: "Refrigerateur" },
            { id: 8, libelle: "DebimetreVolumetrique" },
            { id: 9, libelle: "TunnelDeRefroidissement" },
            { id: 10, libelle: "TransmtteurDePression" },
            { id: 11, libelle: "SondeRedox" },
            { id: 12, libelle: "ManometreDePression" },
            { id: 13, libelle: "DebimetreMassique" },
            { id: 14, libelle: "ChambreFroide" },


          ]
        this.listeEquipements.forEach(e => {

          if (e.libelle == this.equipementservice.formEquipement.value.libelle) {
            this.selected1 = e.id
            this.nomEquipement = e.libelle
          }

        });

      } else {
        this.selected = 0
        this.listeEquipements = []
        this.listeEquipements =
          [
            { id: 0, libelle: "PontsBasculeElectronique" },
            { id: 1, libelle: "Ensacheuse" },
            { id: 2, libelle: "BalanceElectronique" },
            { id: 3, libelle: "Conductivimetre" },

          ]
        this.listeEquipements.forEach(e => {
          if (e.libelle == this.equipementservice.formEquipement.value.libelle) {
            this.selected1 = e.id
            this.nomEquipement = e.libelle
          }

        });
      }
      this.natureEquipement = this.selected1;
    } else {
      this.equipementservice.formEquipement.reset({
        equipementId: '00000000-0000-0000-0000-000000000000',
        identifiantInterne: "",
        numeroSerie: 0,
        marque: "",
        type: "",
        libelle: "",
        temperature: 0,
        dateEtalonnage: "",
        datePoinconnage: "",
        dateReparation: "",
        dateVerification: "",
        porteMax: 0,
        porteMin: 0,
        echellonDeVerification: 0,
        numApprobation: 0,
        numVignette: 0,
        nombreCapteurs: 0,
        pressionMesuree: 0,
        fkFiliale:   this.fk,
      });


    }



  }

  GetlisteEquipement(event: any) {
    this.natureEquipement = 0;
    this.nomEquipement = "";
    if (event == 0) {
      this.listeEquipements = []
      this.listeEquipements =
        [
          { id: 0, libelle: "PontsBasculeElectronique" }, //
          { id: 1, libelle: "Ensacheuse" },//
          { id: 2, libelle: "BalanceElectronique" },
          { id: 3, libelle: "Conductivimetre" },//
        ]
    }
    if (event == 1) {
      this.listeEquipements = []
      this.listeEquipements =
        [
          { id: 0, libelle: "Thermometre" },//
          { id: 1, libelle: "Thermohygometre" },//
          { id: 2, libelle: "Bain" },//
          { id: 3, libelle: "CapteurDePression" },//
          { id: 4, libelle: "PhMetre" },
          { id: 5, libelle: "Four" },//
          { id: 6, libelle: "Etuve" },//
          { id: 7, libelle: "Refrigerateur" },//
          { id: 8, libelle: "DebimetreVolumetrique" },//
          { id: 9, libelle: "TunnelDeRefroidissement" },//
          { id: 10, libelle: "TransmtteurDePression" },//
          { id: 11, libelle: "SondeRedox" },//
          { id: 12, libelle: "ManometreDePression" },//
          { id: 13, libelle: "DebimetreMassique" },//
          { id: 14, libelle: "ChambreFroide" },//

        ]
    }
  }


  GetFormEquipement(event: any) {
    this.displayForm = true;
    this.nomEquipement = this.listeEquipements[event].libelle;
    this.natureEquipement = this.listeEquipements[event].id;
    console.log(this.nomEquipement)
    console.log(this.natureEquipement)
  }



 

}
