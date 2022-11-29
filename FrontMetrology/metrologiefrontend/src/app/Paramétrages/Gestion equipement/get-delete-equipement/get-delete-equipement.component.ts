import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { AddUpdateEquipementComponent } from '../add-update-equipement/add-update-equipement.component';
import { EquipementService } from 'src/app/core/service/Parametrage/equipement.service';
import { Equipement } from 'src/app/core/modeles/Parametrage/Equipement';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-get-delete-equipement',
  templateUrl: './get-delete-equipement.component.html',
  styleUrls: ['./get-delete-equipement.component.css']
})
export class GetDeleteEquipementComponent implements OnInit {
  label: string;
  fkfiliale: string;
  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(private activateroute: ActivatedRoute,public userService: UserService, public modalService: BsModalService,public equipementservice: EquipementService,
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.label = String(this.activateroute.snapshot.paramMap.get('label'));
    this.fkfiliale = String(this.activateroute.snapshot.paramMap.get('fkfiliale'));
    
    console.log('fkfiliale',this.fkfiliale)
    this.equipementservice.GetListEquipementByFiliale(this.fkfiliale).subscribe(res => {
      console.log('liste',res);
      this.equipementservice.listequipement = (res as Equipement[])
      } )
  }





  openComponentForPost() {
    const initialState = {
      fk: this.fkfiliale,
    };       
  
    this.userService.Method = "Post";
    this.bsModalRef = this.modalService.show(AddUpdateEquipementComponent, Object.assign({},
      {
        class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false, initialState
      }));

  }



  // onDelete(user: UserForIdentityServer) {
  //   if (confirm("Vous êtes sûr de vouloir supprimer")) {
  //     this.userService.deleteUserForm.controls.userId.setValue(user.userId);
  //     this.userService.deleteUserForm.controls.applicationId.setValue(environment.IdApplication);
  //     this.userService.deleteUserForm.controls.employeeId.setValue(user.userEmployeeId);
  //     this.SpinnerService.show();
  //     this.userService.DeleteUserByApplication().subscribe(res => {
  //       this.userService.GetListUserByApplicationId().subscribe(res => {
  //         this.userService.ListUserIdentityServer = (res as UserForIdentityServer[])
  //         this.SpinnerService.hide();
  //          Swal.fire({
  //         icon: 'success',
  //         title: "La suppression est effectuée avec succées",
  //       })
  //       })
  //     },
  //       err => {
  //         console.log(err)
  //         this.SpinnerService.hide();
  //       })
  //   }
  // }

  
  openComponentForUpdate(equipement: Equipement) {
    this.equipementservice.equipement = equipement;
    
    this.userService.Method='Put';
    this.equipementservice.initializeFormForUpdate(equipement);
    this.bsModalRef = this.modalService.show(AddUpdateEquipementComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }


  openComponentForDetail(equipement: Equipement){
    this.equipementservice.equipement = equipement;

    console.log("salem")
    this.userService.Method = "Detail";
    this.equipementservice.initializeFormForUpdate(equipement);

    this.bsModalRef = this.modalService.show(AddUpdateEquipementComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }
  openComponentForDelete(equipement: any) {
     Swal.fire({
      title: 'Vous êtes sûr de vouloir supprimer',
      text: "vous ne pouvez pas le récupérer",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Oui, supprimer'
    }).then((result) => {

      if (result.isConfirmed) {
        console.log('id ==> ',this.equipementservice.formEquipement.value.fkFiliale);
        
       this.equipementservice.DeleteEquipement(equipement.equipementId).toPromise().then(res => {
        console.log('hello');
        
          this.equipementservice.GetListEquipementByFiliale(equipement.fkFiliale).toPromise().then(res => {
            this.equipementservice.listequipement = (res as Equipement[]);
     
          this.SpinnerService.hide();
             Swal.fire({
            icon: 'success',
            title: "La suppression est effectuée avec succées",
          })
            
          })
        },
          err => {
            console.log(err)
            this.SpinnerService.hide();
          })
         
       
      }
    })
  }
}
