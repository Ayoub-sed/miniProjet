import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import { Critere } from 'src/app/core/modeles/Parametrage/critere.model';
import { CritereService } from 'src/app/core/service/Parametrage/critere.service';
import { UserService } from 'src/app/core/service/user.service';

@Component({
  selector: 'app-critere-post-update',
  templateUrl: './critere-post-update.component.html',
  styleUrls: ['./critere-post-update.component.css']
})
export class CriterePostUpdateComponent implements OnInit {

  constructor(
    public userService : UserService,
    public critereService : CritereService,
    public bsModalRef: BsModalRef, 
    private fb: FormBuilder, 
    public _snackBar: MatSnackBar,
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit() {
  }

  onSubmit(){
    if (this.userService.Method == "Post"){
      this.PostCritere()
    }
    else this.updateCritere();
   }

   PostCritere(){
    this.critereService.PostCritere().subscribe(res=>{
      if(res as Critere){
        this.bsModalRef.hide();
        this.critereService.GetAllCritere().subscribe(res => {
          this.critereService.listCritere = (res as Critere[])
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
  


  updateCritere(){
    this.critereService.UpdateCritere().subscribe(res=>{
        this.bsModalRef.hide();
        this.critereService.GetAllCritere().subscribe(res => {
          this.critereService.listCritere = (res as Critere[])
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
