import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Equipement } from 'src/app/core/modeles/Parametrage/Equipement';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-ensacheuse',
  templateUrl: './ensacheuse.component.html',
  styleUrls: ['./ensacheuse.component.css']
})
export class EnsacheuseComponent implements OnInit {

  constructor(  public _snackBar: MatSnackBar,public equipementservice: EquipementService ,   public bsModalRef: BsModalRef,  public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
  }
  OnSubmit(){
    console.log("salem",this.equipementservice.formEquipement)
    this.equipementservice.formEquipement.value.type = "Reglementaire"
    this.equipementservice.formEquipement.value.libelle = "Ensacheuse"
    this.equipementservice.PostEnsacheuse().subscribe(res=>{
      if(res as Equipement){
        this.bsModalRef.hide();
        this.equipementservice.GetListEquipementByFiliale(this.equipementservice.formEquipement.value.fkFiliale).subscribe(res => {
          this.equipementservice.listequipement = (res as Equipement[])
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
      this.equipementservice.formEquipement.reset();
  }
  
}
