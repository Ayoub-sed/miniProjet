import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { TypeIntervention } from 'src/app/core/modeles/Parametrage/typeIntervention';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { Role, User, userApplicationRoles, UserForIdentityServer } from 'src/app/core/modeles/user';
import { TypeInterventionService } from 'src/app/core/service/Parametrage/type-intervention.service';
import { UserService } from 'src/app/core/service/user.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-add-update-type-intervention',
  templateUrl: './add-update-type-intervention.component.html',
  styleUrls: ['./add-update-type-intervention.component.css']
})
export class AddUpdateTypeInterventionComponent implements OnInit {

  ListUser : User[]
  role = new userApplicationRoles
  ListSubsidiaries : Subsidiary[]
  Searchform = this.fb.group({
    FkSubsidiary: [''],
  })

  constructor(public typeInterventionService : TypeInterventionService,    public modalService: BsModalService, 
    public userService : UserService,public bsModalRef: BsModalRef, private fb: FormBuilder, public _snackBar: MatSnackBar,
  public SpinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.typeInterventionService.GetListTypeIntervention().subscribe(res => {
      this.typeInterventionService.listTypeIntervention = (res as  TypeIntervention[])
    })
  }

  onSubmit(){
    if (this.userService.Method == "Post"){
      this.PosttypeIntervention()
    }
    else this.updatetypeIntervention();
  }
  PosttypeIntervention(){
    this.SpinnerService.show();
    this.typeInterventionService.PostTypeIntervention().subscribe(res=>{
      if(res as TypeIntervention){
        this.bsModalRef.hide();
        this.typeInterventionService.GetListTypeIntervention().subscribe(res => {
          this.typeInterventionService.listTypeIntervention = (res as TypeIntervention[])               
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

  
  updatetypeIntervention(){
    this.SpinnerService.show();
    this.typeInterventionService.UpdateTypeIntervention().subscribe(res=>{
        this.bsModalRef.hide();
        this.typeInterventionService.GetListTypeIntervention().subscribe(res => {
          this.typeInterventionService.listTypeIntervention = (res as TypeIntervention[])               
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
