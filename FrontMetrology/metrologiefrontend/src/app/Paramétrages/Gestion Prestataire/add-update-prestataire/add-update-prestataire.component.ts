import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Domaine, DomaineForPost } from 'src/app/core/modeles/Parametrage/domaine';
import { Prestataire, PrestataireDTO } from 'src/app/core/modeles/Parametrage/prestataire';
import { Supplier } from 'src/app/core/modeles/Parametrage/supplier';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { User, userApplicationRoles } from 'src/app/core/modeles/user';
import { DomainePrestataireService } from 'src/app/core/service/Parametrage/domaine-prestataire.service';
import { DomaineService } from 'src/app/core/service/Parametrage/domaine.service';
import { PrestataireService } from 'src/app/core/service/Parametrage/prestataire.service';
import { SupplierService } from 'src/app/core/service/Parametrage/supplier.service';
import { UserService } from 'src/app/core/service/user.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-add-update-prestataire',
  templateUrl: './add-update-prestataire.component.html',
  styleUrls: ['./add-update-prestataire.component.css']
})
export class AddUpdatePrestataireComponent implements OnInit {
  
  listeTest=false;
  currentPg: number = 1;
  data: string;
  ListFournisseur : Supplier[];
  ListFournisseurMetrologie : Supplier[];
  role = new userApplicationRoles
  ListSubsidiaries : Subsidiary[]
  Searchform = this.fb.group({
    FkSubsidiary: [''],
  })

  constructor(
    public userService : UserService,
    public supplierService : SupplierService,
    public domaineService : DomaineService,
    public prestataireService : PrestataireService,
    public domainePrestataireService : DomainePrestataireService,
    public bsModalRef: BsModalRef, 
    private fb: FormBuilder, 
    public _snackBar: MatSnackBar,
    public SpinnerService: NgxSpinnerService
  ) { }

  ngOnInit() {
    // this.supplierService.getListSuppliers().subscribe(res=>{
    //   this.supplierService.listPrestataire = res as Prestataire[];
    // });
   
    this.domaineService.listDomaineSelectionnes=[];
    this.domaineService.GetListDomaines().subscribe(res=>{
        this.domaineService.listDomaines = res as Domaine[];
      })
  }

  onSubmit(){
    if (this.userService.Method == "Post"){
      this.PostPrestatireDomaine()
    }
    else this.updatePrestataireDomaine();
   }

  PostPrestatireDomaine(){
    this.prestataireService.PostPrestataire().subscribe(res=>{
      if(res as Prestataire){
        this.domaineService.listDomaineSelectionnes.forEach((element: DomaineForPost) => {
          element.fkPrestataire=(res as Prestataire).prestataireId;
        })
         this.domainePrestataireService.PostPrestataireDomaine().subscribe(reess=>{
        // if(reess as string){
        //   this.bsModalRef.hide();
        //   this.prestataireService.GetListPrestataire().subscribe(pres => {
        //  this.supplierService.listPrestataire = (pres as Prestataire[])            
        //   })
        //   this.SpinnerService.hide();
        //   Swal.fire({
        //     icon: 'success',
        //     title: "L'ajout est effectué avec succées",
        //   })
        // }
        this.prestataireService.GetListPrestataire().subscribe(res => {
          this.supplierService.listPrestataire = (res as Prestataire[])
          this.SpinnerService.hide();
           Swal.fire({
          icon: 'success',
          title: "L'ajout est effectuée avec succées",
        })
        })
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
  checkActiveAgree(event : any,i :number,domaine:DomaineForPost)
  {
    let index =this.domaineService.listDomaineSelectionnes.findIndex(x => x.domaineId === domaine.domaineId);
    this.domaineService.listDomaineSelectionnes[index].agree=event.target.checked;
    
  }

  checkActiveAccridite(event : any, i : number,domaine:DomaineForPost)
  {
    let index =this.domaineService.listDomaineSelectionnes.findIndex(x => x.domaineId === domaine.domaineId);
    this.domaineService.listDomaineSelectionnes[index].accredite=event.target.checked;
   
  }


  onChangeDomain(domaine : DomaineForPost){
     this.domaineService.hideDomainList = true;
     if (this.domaineService.listDomaineSelectionnes.findIndex(x => x.domaineId === domaine.domaineId)==-1)
     {
      domaine.agree=this.domainePrestataireService.formDomainePrestataire.controls.agree.value;
      domaine.accredite=this.domainePrestataireService.formDomainePrestataire.controls.agree.value;
      domaine.fkDomaine=domaine.domaineId; 
      this.domaineService.listDomaineSelectionnes.push(domaine);
     }
     else 
     {
      Swal.fire({
                 icon: 'error',
                 title: "Vous avez déjà sélectionné ce domaine !",
               })
     } 
  
  }
  
  updatePrestataireDomaine(){
    this.prestataireService.UpdatePrestataire().subscribe(res=>{
        this.bsModalRef.hide();
        this.prestataireService.GetAllPrestataire().subscribe(res => {
          this.prestataireService.listPrestataireDto = (res as PrestataireDTO[])
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
   onDelete(domaine : DomaineForPost,i : number){
    delete this.domaineService.listDomaineSelectionnes[i];
  
   }

   chercherFournisseur(event : any){
    this.listeTest=true;
    this.supplierService.SerachSupplierWithKeyWord(event).subscribe(res => {
      this.ListFournisseur = res as Supplier[];
   })
   }
   selectedRowIds: Set<string> = new Set<string>();

   rowIsSelected(id: string) {
    return this.selectedRowIds.has(id);
  }
  onRowClick(pd: Supplier) 
  {
    if(this.selectedRowIds.has(pd.supplierId)) {
     this.selectedRowIds.delete(pd.supplierId);
    }
    else {
      this.selectedRowIds.add(pd.supplierId);
    }

   this.prestataireService.formPrestataire.controls.prestataireId.setValue(pd.supplierId);
   this.prestataireService.formPrestataire.controls.matricule.setValue(pd.codeSupplier)
   this.prestataireService.formPrestataire.controls.nomPrenom.setValue(pd.supplierName)

   this.prestataireService.PostPrestataire().subscribe(res => {
    // this.prestataireService.re();
     let test = res as Prestataire;
     if (test != null) {
       //this.bsModalRef.hide();
       this.prestataireService.GetListPrestataire().subscribe(res => {
         this.supplierService.listPrestataire = res as Prestataire[];

       })
      //  this._snackBar.open("L'ajout est effectué avec succées", "X", {
      //    duration: 3000,
         
         
      //    panelClass: ["green-snackbar"]
      //  });
      Swal.fire({
        icon: 'success',
        title: "L'ajout est effectuée avec succées",
      })
     }
   },
     err => {
       console.log(err)

      //  this._snackBar.open("Erreur", "X", {
      //    duration: 3000,
      //    verticalPosition: 'top',
         
      //    panelClass: ["red-snackbar"]
      //  });
      Swal.fire({
        icon: 'warning',
        title: 'Ce fournisseur existe déjà !',})
     }
   )

  }

}
