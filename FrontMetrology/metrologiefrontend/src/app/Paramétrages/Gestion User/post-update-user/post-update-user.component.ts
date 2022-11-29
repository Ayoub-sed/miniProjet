import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { Role, User, userApplicationRoles, UserForIdentityServer } from 'src/app/core/modeles/user';
import { UserService } from 'src/app/core/service/user.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-post-update-user',
  templateUrl: './post-update-user.component.html',
  styleUrls: ['./post-update-user.component.css']
})
export class PostUpdateUserComponent implements OnInit {

  ListUser : User[]
  role = new userApplicationRoles
  ListSubsidiaries : Subsidiary[]
  Searchform = this.fb.group({
    FkSubsidiary: [''],
  })

  constructor(public userService : UserService,public bsModalRef: BsModalRef, private fb: FormBuilder, public _snackBar: MatSnackBar,
  public SpinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.userService.GetRoleByApplicationId().subscribe(res=>{
      this.userService.ListRole = res as Role[]
      if(this.userService.Method == "Put"){
        this.onChangeRole();
      }
    })
    this.userService.User.userApplicationRoles = []
  }

  onSubmit(){
    if (this.userService.Method == "Post"){
      this.PostUser()
    }
    else this.updateUserRole();
  }

  PostUser(){
    this.userService.User.applicationId= environment.IdApplication;
    this.userService.User.applicationName= JSON.parse(sessionStorage.getItem("id_token_claims_obj") || '{}').aud;
    this.SpinnerService.show();
    this.userService.PostUser().subscribe(res=>{
      if(res as string){
        this.bsModalRef.hide();
        this.userService.GetListUserByApplicationId().subscribe(res => {
          this.userService.ListUserIdentityServer = (res as UserForIdentityServer[])               
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
        this._snackBar.open("L'utilisateur " + this.userService.User.userFullName + " à déjà un rôle", "X", {
          duration: 3000,
          panelClass: ["red-snackbar"]
        });
      })
  }

  onChangeUser(user : User){
    this.userService.User.userUserName = user.matricule.toString();
    this.userService.User.userFullName = user.fullName;
    this.userService.User.userEmployeeId = user.matricule.toString();
    this.userService.User.userEmail = user.lotusAdress;
    this.userService.User.userPassword = user.matricule.toString();
    this.userService.User.userSubsidiaryCode = user.subsidiaryCode;
    this.userService.User.userIsEnabled = true;
  }

  onChangeRole(){
    this.userService.User.userApplicationRoles = []
    this.role.roleId = ((this.userService.ListRole.find(x=>x.id == this.userService.AddOrUpdateUserForm.controls.roleId.value)) as Role).id;
    this.role.roleName = ((this.userService.ListRole.filter(x=>x.id == this.userService.AddOrUpdateUserForm.controls.roleId.value)[0]) as Role).name
    this.userService.User.userApplicationRoles.push(this.role) 
  }

  onSearchUser(event : any) {
  
    if(event.term.length >= 3){
      this.userService.SearchUserWithKeyWord(event.term).subscribe(res => {
        this.ListUser = res as User[];
  
      })
    }
  }
  updateUserRole(){
    this.userService.User.applicationId= environment.IdApplication;
    this.userService.User.applicationName= JSON.parse(localStorage.getItem("id_token_claims_obj") || '{}').aud;
    this.SpinnerService.show();
    this.userService.UpdateUserOneRolePermitted().subscribe(res=>{
        this.bsModalRef.hide();
        this.userService.GetListUserByApplicationId().subscribe(res => {
          this.userService.ListUserIdentityServer = (res as UserForIdentityServer[])
          //.filter(x=>x.userEmployeeId != '07041830' && x.userEmployeeId != '04809975' && x.userEmployeeId != '09950523' )
               
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