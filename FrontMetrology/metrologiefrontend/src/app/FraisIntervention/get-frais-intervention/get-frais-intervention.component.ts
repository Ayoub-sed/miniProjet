import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { FraisIntervention } from 'src/app/core/modeles/Parametrage/FraisIntervention';
import { FraisInterventionService } from 'src/app/core/service/Parametrage/frais-intervention.service';
import { UserService } from 'src/app/core/service/user.service';

@Component({
  selector: 'app-get-frais-intervention',
  templateUrl: './get-frais-intervention.component.html',
  styleUrls: ['./get-frais-intervention.component.css']
})
export class GetFraisInterventionComponent implements OnInit {
  @Input() fraisInterventionn: FraisIntervention;
  @Input() libelle: string;
  constructor(public fraisInterventionservice: FraisInterventionService,
    public bsModalRef: BsModalRef,
     private fb: FormBuilder,
    public _snackBar: MatSnackBar,
    public userService: UserService,
    private activateroute: ActivatedRoute,
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
  }

}
