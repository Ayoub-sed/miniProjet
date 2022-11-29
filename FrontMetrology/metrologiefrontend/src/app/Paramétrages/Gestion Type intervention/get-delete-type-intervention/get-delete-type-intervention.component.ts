import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { environment } from 'src/environments/environment';
import { UserForIdentityServer } from 'src/app/core/modeles/user';
import { PostUpdateUserComponent } from '../../Gestion User/post-update-user/post-update-user.component';
import { TypeInterventionService } from 'src/app/core/service/Parametrage/type-intervention.service';
import { TypeIntervention } from 'src/app/core/modeles/Parametrage/typeIntervention';
import { AddUpdateTypeInterventionComponent } from '../add-update-type-intervention/add-update-type-intervention.component';

@Component({
  selector: 'app-get-delete-type-intervention',
  templateUrl: './get-delete-type-intervention.component.html',
  styleUrls: ['./get-delete-type-intervention.component.css']
})
export class GetDeleteTypeInterventionComponent implements OnInit {

  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(
    public userService: UserService, 
    public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService,
    public typeInterventionService : TypeInterventionService) { }

  ngOnInit(): void {
    this.typeInterventionService.GetListTypeIntervention().subscribe(res => {
      this.typeInterventionService.listTypeIntervention = (res as TypeIntervention[])
    })
  }
  openComponentForPost() {
    this.userService.Method = "Post";
    this.typeInterventionService.initializeFormTypeInterventionForPost();
    this.bsModalRef = this.modalService.show(AddUpdateTypeInterventionComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }
  onDelete(typeIntervention: TypeIntervention) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.SpinnerService.show();
      this.typeInterventionService.DeleteTypeIntervention(typeIntervention.typeInterventionId).subscribe(res => {
        this.typeInterventionService.GetListTypeIntervention().subscribe(res => {
          this.typeInterventionService.listTypeIntervention = (res as TypeIntervention[])
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
  }
  openComponentForUpdate(typeIntervention: TypeIntervention) {
    this.userService.Method = "Put"
    this.typeInterventionService.initializeFormTypeInterventionForEdit(typeIntervention);
    this.bsModalRef = this.modalService.show(AddUpdateTypeInterventionComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }

}
