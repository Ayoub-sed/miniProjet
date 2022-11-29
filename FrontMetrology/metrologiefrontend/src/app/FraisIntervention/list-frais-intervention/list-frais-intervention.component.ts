import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { modalConfigDefaults } from 'ngx-bootstrap/modal/modal-options.class';
import { NgxSpinnerService } from 'ngx-spinner';
import { FraisIntervention, FraisInterventionDto } from 'src/app/core/modeles/Parametrage/FraisIntervention';
import { FraisInterventionService } from 'src/app/core/service/Parametrage/frais-intervention.service';
import { UserService } from 'src/app/core/service/user.service';
import { PostUpdateFraisInterventionComponent } from '../post-update-frais-intervention/post-update-frais-intervention.component';
import Swal from 'sweetalert2';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { GetFraisInterventionComponent } from '../get-frais-intervention/get-frais-intervention.component';
@Component({
  selector: 'app-list-frais-intervention',
  templateUrl: './list-frais-intervention.component.html',
  styleUrls: ['./list-frais-intervention.component.css']
})
export class ListFraisInterventionComponent implements OnInit {
  
  label: string;
  fkfiliale: string;
  bsModalRef: any;
  currentDate: Date = new Date();
  datesysteme: string;
  fraisInterventionDto: FraisInterventionDto[];
  somme: number = 0;
  DateMax:string;
  DateValue:string;
  TestDate : string;
  constructor(private activateroute: ActivatedRoute,
    public fraisInterventionservice: FraisInterventionService,
    public modalService: BsModalService,
    public userService: UserService,
    public datePipe: DatePipe,
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.label = String(this.activateroute.snapshot.paramMap.get('label'));
    this.fkfiliale = String(this.activateroute.snapshot.paramMap.get('fkfiliale'));
    this.datesysteme = this.datePipe.transform(this.currentDate, 'yyyy-MM-dd') as string;
    this.DateMax = this.datePipe.transform(this.currentDate, 'yyyy-12') as string;
    this.DateValue = this.datePipe.transform(this.currentDate, 'yyyy') as string;
    this.TestDate = this.datePipe.transform(this.currentDate, 'yyyy') as string;
    this.fraisInterventionservice.GetListFraisInterventionByTypeIntervention(this.fkfiliale, this.datesysteme).subscribe(res => {
      this.fraisInterventionservice.listfraisinterventiondto = (res as FraisInterventionDto[]);
      this.fraisInterventionDto = this.fraisInterventionservice.listfraisinterventiondto;
      let n = this.fraisInterventionDto.length;
      for (let i = 0; i < n; i++) {
        this.somme = this.somme + this.fraisInterventionDto[i].sommeFrais
      }
    });


  }
  openComponentForPost() {
    const initialState = {
      fk: String(this.activateroute.snapshot.paramMap.get('fkfiliale'))
    };
    this.userService.Method = "Post";
    this.fraisInterventionservice.initializeAddForm();
    this.bsModalRef = this.modalService.show(PostUpdateFraisInterventionComponent, Object.assign({},
      {
        class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false, initialState
      }));

  }
  changeDate(){
    if (this.DateValue > this.TestDate || "2000">this.DateValue ){
      Swal.fire({
        icon: 'error',
        title: "Date n'est pas valide, doit être entre 2000 et " +this.TestDate ,
      })
    }else{
    this.fraisInterventionservice.GetListFraisInterventionByTypeIntervention(this.fkfiliale, this.DateValue+"-01-01").subscribe(res => {
      this.fraisInterventionservice.listfraisinterventiondto = (res as FraisInterventionDto[]);
      this.fraisInterventionDto = this.fraisInterventionservice.listfraisinterventiondto;
      let n = this.fraisInterventionDto.length;
      this.somme = 0;
      for (let i = 0; i < n; i++) {
        this.somme = this.somme + this.fraisInterventionDto[i].sommeFrais
      }
    });
  }
}
update(fraisIntervention: FraisIntervention){
  const initialState = {
    fk: String(this.activateroute.snapshot.paramMap.get('fkfiliale')),
  };
  this.userService.Method = "Put";
  this.fraisInterventionservice.initializeUpdateForm(fraisIntervention);
  this.bsModalRef = this.modalService.show(PostUpdateFraisInterventionComponent, Object.assign({},
    {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false, initialState
    }));
}
delete(fraisIntervention: FraisIntervention){
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
      this.fraisInterventionservice.DeleteFraisIntervention(fraisIntervention.fraisInterventionId).subscribe(res => {
        this.fraisInterventionservice.GetListFraisInterventionByTypeIntervention(this.fkfiliale, this.DateValue+"-01-01").subscribe(res => {
          this.fraisInterventionservice.listfraisinterventiondto = (res as FraisInterventionDto[]);
          this.fraisInterventionDto = this.fraisInterventionservice.listfraisinterventiondto;
          let n = this.fraisInterventionDto.length;
          this.somme = 0;
          for (let i = 0; i < n; i++) {
            this.somme = this.somme + this.fraisInterventionDto[i].sommeFrais
          }
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

      Swal.fire(
        'Deleted!',
        'Your file has been deleted.',
        'success'
      )
    }
  })
 
}

show(fraisIntervention: FraisIntervention){
  
  const initialState = {
    fraisInterventionn: fraisIntervention,
    libelle: this.label,
  };
  this.bsModalRef = this.modalService.show(GetFraisInterventionComponent, Object.assign({},
    {
      class: 'modal-lg modal-dialog-centered', ignoreBackdropClick: true, keyboard: false, initialState
    }));
}
}