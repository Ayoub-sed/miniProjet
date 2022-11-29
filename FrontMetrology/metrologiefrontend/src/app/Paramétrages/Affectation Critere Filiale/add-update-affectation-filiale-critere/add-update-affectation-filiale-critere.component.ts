import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import Swal from 'sweetalert2';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Critere } from 'src/app/core/modeles/Parametrage/critere.model';
import { Sector } from 'src/app/core/modeles/Parametrage/sector.model';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { CritereService } from 'src/app/core/service/Parametrage/critere.service';
import { FilialeCritereService } from 'src/app/core/service/Parametrage/filiale-critere.service';
import { SubsidiaryService } from 'src/app/core/service/subsidiary.service';
import { UserService } from 'src/app/core/service/user.service';
import { FilialeCritere } from 'src/app/core/modeles/Parametrage/filiale-critere.model';

@Component({
  selector: 'app-add-update-affectation-filiale-critere',
  templateUrl: './add-update-affectation-filiale-critere.component.html',
  styleUrls: ['./add-update-affectation-filiale-critere.component.css']
})
export class AddUpdateAffectationFilialeCritereComponent implements OnInit {

  constructor(public subsidiaryService : SubsidiaryService,public critereService : CritereService, public filialeCritereService : FilialeCritereService, public bsModalRef: BsModalRef, private fb: FormBuilder, public _snackBar: MatSnackBar,
    public SpinnerService: NgxSpinnerService,
    public userService : UserService) { }

  ngOnInit(): void {
    this.subsidiaryService.GetAllSectors().subscribe(res=>{
      this.subsidiaryService.listSectors = res as Sector[]
    })
    this.critereService.GetAllCritere().subscribe(res=>{
      this.critereService.listCritere = res as Critere[]
    })
  }

  onChangeSector(secteur : Sector){
    this.subsidiaryService.GetSubsidiariesBySectors(secteur.sectorId).subscribe(res=>{
      this.subsidiaryService.listSubsidiary = res as Subsidiary[]
    })
  }

  onChangeSubsidiary( filiale : Subsidiary){
    this.filialeCritereService.formFilialeCritere.setValue({
      subsidiarylabel: filiale.label
      });
  }

  onSubmit(){if (this.userService.Method == "Post"){
    this.PostFilialeCritere()
  }
  else this.updateFilialeCritere();
 }

 PostFilialeCritere(){
  this.filialeCritereService.PostFilialeCritere().subscribe(res=>{
    if(res as Critere){
      this.bsModalRef.hide();
      this.filialeCritereService.GetAllFilialeCriteres().subscribe(res => {
        this.filialeCritereService.listFilaileCritere = (res as FilialeCritere[])
      })
      this.SpinnerService.hide(); 
      Swal.fire({
        icon: 'success',
        title: "L'ajout est effectué avec succées",
      })
    }
    else {
      this.SpinnerService.hide();
    }
  },
    err => {
      console.log(err)
      this.SpinnerService.hide();
      this._snackBar.open("erreur " , "X", {
        duration: 3000,
        panelClass: ["red-snackbar"]
      });
    })
}



updateFilialeCritere(){
  this.filialeCritereService.UpdateFilialeCritere().subscribe(res=>{
      this.bsModalRef.hide();
      this.filialeCritereService.GetAllFilialeCriteres().subscribe(res => {
        this.filialeCritereService.listFilaileCritere = (res as FilialeCritere[])
      })
      this.SpinnerService.hide();
      Swal.fire({
        icon: 'success',
        title: "La modification est effectuée avec succées",
      })
  },
    err => {
      console.log(err)
      this.SpinnerService.hide();
    })

 }

}
