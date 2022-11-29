import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/service/user.service';
import { DatePipe } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Equipement } from 'src/app/core/modeles/Parametrage/Equipement';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tunnel-de-refroidissement-form',
  templateUrl: './tunnel-de-refroidissement-form.component.html',
  styleUrls: ['./tunnel-de-refroidissement-form.component.css']
})
export class TunnelDeRefroidissementFormComponent implements OnInit {
  dateE: string;
  dateV: string;
  constructor(public userService: UserService, public datePipe: DatePipe, public _snackBar: MatSnackBar, public equipementservice: EquipementService, public bsModalRef: BsModalRef, public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
console.log("salemou ")
    if(this.userService.Method == "Detail"){
      this.equipementservice.formEquipement.disable();
      
    }else{
      this.equipementservice.formEquipement.enable();
    }
    
   
  }
  OnSubmit() {
    if (this.userService.Method == "Post") {
      this.equipementservice.formEquipement.value.type = "NonReglementaire"
      this.equipementservice.formEquipement.value.libelle = "TunnelDeRefroidissement"
      console.log(this.equipementservice.formEquipement)
      this.equipementservice.PostTunnelDeRefroidissement().subscribe(res => {
        if (res as Equipement) {
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
          this._snackBar.open("erreur ", "X", {
            duration: 3000,
            panelClass: ["red-snackbar"]
          });
        })
    } else {
      this.equipementservice.PuttTunnelDeRefroidissement().subscribe(res => {
        if (res as Equipement) {
          this.bsModalRef.hide();
          this.equipementservice.GetListEquipement().subscribe(res => {
            this.equipementservice.listequipement = (res as Equipement[])
          })
          this.SpinnerService.hide();
          Swal.fire({
            icon: 'success',
            title: "La modification  est effectué avec succées",
          })
        }
        else {
          this.SpinnerService.hide();
        }
      },
        err => {
          console.log(err)
          this.SpinnerService.hide();
          this._snackBar.open("erreur ", "X", {
            duration: 3000,
            panelClass: ["red-snackbar"]
          });
        })
    }
  }

}
