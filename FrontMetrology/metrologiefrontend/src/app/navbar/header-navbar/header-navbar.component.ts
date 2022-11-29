import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/service/Authentication.service';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-header-navbar',
  templateUrl: './header-navbar.component.html',
  styles: []
})
export class HeaderNavbarComponent implements OnInit {

  constructor(private oauthService: OAuthService, public router: Router, public authentication: AuthenticationService) {

  }

  ngOnInit() {
 
  }
  logout() {
    this.oauthService.logOut(false);
  }

}
