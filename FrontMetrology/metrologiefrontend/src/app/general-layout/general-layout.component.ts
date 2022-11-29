import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/service/Authentication.service';

@Component({
  selector: 'app-general-layout',
  templateUrl: './general-layout.component.html',
  styles: []
})
export class GeneralLayoutComponent implements OnInit {

  constructor(public authentication: AuthenticationService, public router: Router) { }

  ngOnInit() {
    
  }

  isURLHome(){

    if (this.router.url.startsWith('/?') || this.router.url === '/') {
      return true;
    } else {
      return false;
    }
    
  }
  isURLDefault(){

    if (this.router.url.startsWith('/!') || this.router.url === '/Home') {
      return false;
    } 
    else {
      return true;
    }
    
  }


}
