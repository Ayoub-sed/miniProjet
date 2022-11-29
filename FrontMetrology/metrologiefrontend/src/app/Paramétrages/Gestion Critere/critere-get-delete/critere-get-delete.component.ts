import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { Critere } from 'src/app/core/modeles/Parametrage/critere.model';
import { CritereService } from 'src/app/core/service/Parametrage/critere.service';
import { CriterePostUpdateComponent } from '../critere-post-update/critere-post-update.component';
import { UserService } from 'src/app/core/service/user.service';

@Component({
  selector: 'app-critere-get-delete',
  templateUrl: './critere-get-delete.component.html',
  styleUrls: ['./critere-get-delete.component.css']
})
export class CritereGetDeleteComponent implements OnInit {

  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(    
    public userService : UserService,
    public critereService : CritereService,
    public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    
    this.critereService.GetAllCritere().subscribe(res => {
      this.critereService.listCritere = (res as Critere[])
    })
  }
  openComponentForPost() {    
    this.userService.Method='Post';
    this.critereService.initializeFormForPost();
    this.bsModalRef = this.modalService.show(CriterePostUpdateComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }


  onDelete(critere: Critere) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.SpinnerService.show();
      this.critereService.DeleteCritere(critere.critereId).subscribe(res => {
        this.critereService.GetAllCritere().subscribe(res => {
          this.critereService.listCritere = (res as Critere[])
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
  openComponentForUpdate(critere: Critere) {
    this.critereService.critere=critere;
    this.userService.Method='Put';
    this.critereService.initializeFormForUpdate(critere);
    this.bsModalRef = this.modalService.show(CriterePostUpdateComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }

}
