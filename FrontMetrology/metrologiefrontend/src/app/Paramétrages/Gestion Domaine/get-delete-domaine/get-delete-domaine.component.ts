import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { DomaineService } from 'src/app/core/service/Parametrage/domaine.service';
import { Domaine } from 'src/app/core/modeles/Parametrage/domaine';
import { AddUpdateDomaineComponent } from '../add-update-domaine/add-update-domaine.component';

@Component({
  selector: 'app-get-delete-domaine',
  templateUrl: './get-delete-domaine.component.html',
  styleUrls: ['./get-delete-domaine.component.css']
})
export class GetDeleteDomaineComponent implements OnInit {

  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(
    public userService: UserService, 
    public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService,
    public domaineService : DomaineService) { }

  ngOnInit(): void {
    this.domaineService.GetListDomaines().subscribe(res => {
      this.domaineService.listDomaines = (res as Domaine[])
    })
  }
  openComponentForPost() {
    this.userService.Method = "Post";
    this.domaineService.initializeFormForPost();
    this.bsModalRef = this.modalService.show(AddUpdateDomaineComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }
  onDelete(domaine: Domaine) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.SpinnerService.show();
      this.domaineService.DeleteDomaine(domaine.domaineId).subscribe(res => {
        this.domaineService.GetListDomaines().subscribe(res => {
          this.domaineService.listDomaines = (res as Domaine[])
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
  openComponentForUpdate(domaine: Domaine) {
    this.userService.Method = "Put";
    this.domaineService.initializeFormDomaineForEdit(domaine);
    this.bsModalRef = this.modalService.show(AddUpdateDomaineComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }

}
