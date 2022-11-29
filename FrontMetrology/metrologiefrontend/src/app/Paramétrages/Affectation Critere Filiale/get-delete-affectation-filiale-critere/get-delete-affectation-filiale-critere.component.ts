import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import { FilialeCritere } from 'src/app/core/modeles/Parametrage/filiale-critere.model';
import { FilialeCritereService } from 'src/app/core/service/Parametrage/filiale-critere.service';
import { UserService } from 'src/app/core/service/user.service';
import { AddUpdateAffectationFilialeCritereComponent } from '../add-update-affectation-filiale-critere/add-update-affectation-filiale-critere.component';

@Component({
  selector: 'app-get-delete-affectation-filiale-critere',
  templateUrl: './get-delete-affectation-filiale-critere.component.html',
  styleUrls: ['./get-delete-affectation-filiale-critere.component.css']
})
export class GetDeleteAffectationFilialeCritereComponent implements OnInit {

  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(    
    public userService : UserService,
    public filialecritereService : FilialeCritereService,
    public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    
    this.filialecritereService.GetAllFilialeCriteres().subscribe(res => {
      this.filialecritereService.listFilaileCritere = (res as FilialeCritere[])
    })
  }
  openComponentForPost() {    
    this.userService.Method='Post';
    this.filialecritereService.initializeFormForPost();
    this.bsModalRef = this.modalService.show(AddUpdateAffectationFilialeCritereComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }


  onDelete(filialecritere: FilialeCritere) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.SpinnerService.show();
      this.filialecritereService.DeleteFilialeCritere(filialecritere.filialeCritereId).subscribe(res => {
        this.filialecritereService.GetAllFilialeCriteres().subscribe(res => {
          this.filialecritereService.listFilaileCritere = (res as FilialeCritere[])
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
  openComponentForUpdate(filialecritere: FilialeCritere) {
    this.filialecritereService.filialecritere=filialecritere;
    this.userService.Method='Put';
    this.filialecritereService.initializeFormForEdit(filialecritere);
    this.bsModalRef = this.modalService.show(AddUpdateAffectationFilialeCritereComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }

}
