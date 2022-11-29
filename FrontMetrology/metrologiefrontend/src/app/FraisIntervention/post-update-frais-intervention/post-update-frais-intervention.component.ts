import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Equipement, EquipementDto } from 'src/app/core/modeles/Parametrage/Equipement';
import { FraisIntervention, FraisInterventionDto } from 'src/app/core/modeles/Parametrage/FraisIntervention';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import { FraisInterventionService } from 'src/app/core/service/Parametrage/frais-intervention.service';
import { UserService } from 'src/app/core/service/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-post-update-frais-intervention',
  templateUrl: './post-update-frais-intervention.component.html',
  styleUrls: ['./post-update-frais-intervention.component.css']
})
export class PostUpdateFraisInterventionComponent implements OnInit {
  @Input() fk: string;
  currentDate: Date = new Date();
  datesysteme: string;
  newDate: Date;
  fraisInterventionDto: FraisInterventionDto[];
  somme: number = 0;
  constructor(public fraisInterventionservice: FraisInterventionService,

    public bsModalRef: BsModalRef, private fb: FormBuilder,
    public _snackBar: MatSnackBar,
    public userService: UserService,
    private activateroute: ActivatedRoute,
    public SpinnerService: NgxSpinnerService,
    public datePipe: DatePipe,
    public equipementService: EquipementService) { }

  ngOnInit(): void {
    this.equipementService.GetListEquipementByFiliale(this.fk).subscribe(res => {
      this.equipementService.listequipement = (res as Equipement[]),
      console.log(this.equipementService.listequipement)
      } )
    
  }

  onSubmit() {
    if (this.userService.Method == "Post") {
      this.PostFraisIntervention()
    }
    else this.UpdateFraisIntervention();
  }

  PostFraisIntervention() {
    this.fraisInterventionservice.AddOrUpdateFraisInterventionForm.value.FkFiliale = this.fk;
    this.fraisInterventionservice.PostFraisIntervention().subscribe(res => {
      if (res as FraisIntervention) {
        this.bsModalRef.hide();
        this.SpinnerService.hide();

        Swal.fire({
          icon: 'success',
          title: "L'ajout est effectué avec succées",
        })
        this.datesysteme = this.datePipe.transform(this.currentDate, 'yyyy-MM-dd') as string;
        this.fraisInterventionservice.GetListFraisInterventionByTypeIntervention(this.fk, this.datesysteme).subscribe(res => {
          this.fraisInterventionservice.listfraisinterventiondto = (res as FraisInterventionDto[]);
          this.fraisInterventionDto = this.fraisInterventionservice.listfraisinterventiondto;
          let n = this.fraisInterventionDto.length;
          for (let i = 0; i < n; i++) {
            this.somme = this.somme + this.fraisInterventionDto[i].sommeFrais
          }
        });
      }
      else {
        this.SpinnerService.hide();
      }
    },
    )
  }
  UpdateFraisIntervention() {
    this.fraisInterventionservice.AddOrUpdateFraisInterventionForm.value.FkFiliale = this.fk;
    this.fraisInterventionservice.UpdateFraisIntervention().subscribe(res => {
      if (res as FraisIntervention) {
        this.bsModalRef.hide();
        this.SpinnerService.hide();
        Swal.fire({
          icon: 'success',
          title: "Modification est effectué avec succées",
        })
      }
      else {
        this.SpinnerService.hide();
      }
    }
    )
  }
}