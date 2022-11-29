import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { Critere } from 'src/app/core/modeles/Parametrage/critere.model';
import { AuthenticationService } from 'src/app/core/service/Authentication.service';
import { CritereService } from 'src/app/core/service/Parametrage/critere.service';
declare var $: any;
@Component({
  selector: 'app-fiche-suivi',
  templateUrl: './fiche-suivi.component.html',
  styleUrls: ['./fiche-suivi.component.css']
})
export class FicheSuiviComponent implements OnInit {
  user: any;

  constructor(
    public authenticationService: AuthenticationService, public router : Router, 
  ) { }

  ngOnInit() {
    $('[data-widget="treeview"]').Treeview('init');

    this.user=this.authenticationService.currentUser;

  }
 

}
