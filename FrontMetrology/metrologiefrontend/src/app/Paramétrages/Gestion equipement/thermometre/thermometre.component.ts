import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Equipement } from 'src/app/core/modeles/Parametrage/Equipement';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-thermometre',
  templateUrl: './thermometre.component.html',
  styleUrls: ['./thermometre.component.css']
})
export class ThermometreComponent implements OnInit {

 
  constructor(  public _snackBar: MatSnackBar,public equipementservice: EquipementService ,   public bsModalRef: BsModalRef,  public SpinnerService: NgxSpinnerService) { }
  listeEquipements:any[];
  ngOnInit(): void {
   
  }
  OnSubmit(){
    console.log("salem",this.equipementservice.formEquipement)
    this.equipementservice.formEquipement.value.type = "Non Reglementaire"
    this.equipementservice.formEquipement.value.libelle = "Thermomètre"
    this.equipementservice.PostThermometre().subscribe(res=>{
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
      });
      console.log(this.equipementservice.formEquipement)
      this.equipementservice.formEquipement.reset();
      console.log(this.equipementservice.formEquipement)
  }
  
  }

