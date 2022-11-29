import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Domaine } from 'src/app/core/modeles/Parametrage/domaine';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { User, userApplicationRoles } from 'src/app/core/modeles/user';
import { DomaineService } from 'src/app/core/service/Parametrage/domaine.service';
import { UserService } from 'src/app/core/service/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-update-domaine',
  templateUrl: './add-update-domaine.component.html',
  styleUrls: ['./add-update-domaine.component.css']
})
export class AddUpdateDomaineComponent implements OnInit {

  constructor(
    public userService : UserService,
    public bsModalRef: BsModalRef, 
    public _snackBar: MatSnackBar,
    public domaineService : DomaineService,
  public SpinnerService: NgxSpinnerService) { }

  ngOnInit() {
  
  }

  onSubmit(){
    if (this.userService.Method == "Post"){
      this.PostDomaine()
    }
    else this.updateDomaine();
  }

  PostDomaine(){
    this.SpinnerService.show();
    this.domaineService.PostDomaine().subscribe(res=>{
      if(res as Domaine){
        this.bsModalRef.hide();
        this.domaineService.GetListDomaines().subscribe(res => {
          this.domaineService.listDomaines = (res as Domaine[])               
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
        this._snackBar.open("erreur" , "X", {
          duration: 3000,
          panelClass: ["red-snackbar"]
        });
      })
  }

  
  updateDomaine(){
    this.SpinnerService.show();
    this.domaineService.UpdateDomaine().subscribe(res=>{
        this.bsModalRef.hide();
        this.domaineService.GetListDomaines().subscribe(res => {
          this.domaineService.listDomaines = (res as Domaine[])               
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
