import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { environment } from 'src/environments/environment';
import { UserForIdentityServer } from 'src/app/core/modeles/user';
import { AddUpdatePrestataireComponent } from '../add-update-prestataire/add-update-prestataire.component';
import { DomaineService } from 'src/app/core/service/Parametrage/domaine.service';
import { PrestataireService } from 'src/app/core/service/Parametrage/prestataire.service';
import { Prestataire, PrestataireDTO } from 'src/app/core/modeles/Parametrage/prestataire';
import { Supplier } from 'src/app/core/modeles/Parametrage/supplier';
import { SupplierService } from 'src/app/core/service/Parametrage/supplier.service';

@Component({
  selector: 'app-get-delete-prestatire',
  templateUrl: './get-delete-prestatire.component.html',
  styleUrls: ['./get-delete-prestatire.component.css']
})
export class GetDeletePrestatireComponent implements OnInit {
  listTypePrestataire: any[];

  bsModalRef: any;
  data:string;
  current: number = 1;
selectedValue: any;
  constructor(
    public domaineService : DomaineService,
    public prestataireService : PrestataireService,
    public supplierService : SupplierService,
    public userService: UserService, public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    
    this.prestataireService.GetListPrestataire().subscribe(res => {
      this.supplierService.listPrestataire = (res as Prestataire[])
      console.log(this.supplierService.listPrestataire)
    })
    this.listTypePrestataire=["Accrédité","Agréé"]
    console.log(this.listTypePrestataire)
  }
  openComponentForPost() {
    this.domaineService.hideDomainList=false;
    this.domaineService.hideDomainListForupdate=false;

    this.userService.Method = "Post"
    this.prestataireService.initializeFormForPost();
    this.bsModalRef = this.modalService.show(AddUpdatePrestataireComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }


  onDelete(prestataire: PrestataireDTO) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.SpinnerService.show();
      this.prestataireService.DeletePrestataire(prestataire.prestataireId).subscribe(res => {
        this.prestataireService.GetListPrestataire().subscribe(res => {
          this.supplierService.listPrestataire = (res as Prestataire[])
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
  openComponentForUpdate(prestataire: PrestataireDTO) {
    this.domaineService.hideDomainListForupdate=true;
    this.domaineService.hideDomainList=false;
    this.userService.Method = "Put";
    this.prestataireService.prestataireDto=prestataire;
    console.log('prestataire',prestataire)
    this.prestataireService.initializeFormForUpdate(prestataire);
    this.bsModalRef = this.modalService.show(AddUpdatePrestataireComponent, {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }

  ChangeTypePrestataire(g: Prestataire[] , e: any){
    console.log(g,e.value)

  }
}
