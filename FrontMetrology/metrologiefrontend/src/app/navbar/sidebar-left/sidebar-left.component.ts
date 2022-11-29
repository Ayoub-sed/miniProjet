declare var $: any;

import { AuthenticationService } from 'src/app/core/service/Authentication.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar-left',
  templateUrl: './sidebar-left.component.html',
  styleUrls: ['./sidebar-left.component.css']


})
export class SidebarLeftComponent implements OnInit {


  user: any;

  constructor(
    public authenticationService: AuthenticationService, public router : Router, 
  ) { }

  ngOnInit() {
    $('[data-widget="treeview"]').Treeview('init');

    
    this.user=this.authenticationService.currentUser;

  }





}