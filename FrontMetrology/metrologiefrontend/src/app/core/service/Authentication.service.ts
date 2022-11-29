import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private oauthService: OAuthService) { }

  public currentUserSubject: BehaviorSubject<any>;
  public User: Observable<any>;
  public currentUser: string;
  public currentUserMatricule: string;
  public currentUserRole: string[];
  public applicationTitle= "PGH Metrologie ";

getUserClaims() {
    const user = this.oauthService.loadUserProfile();
}
  get idToken(): string {
    return this.oauthService.getIdToken();
  }
  get accessToken(): string {
    return this.oauthService.getAccessToken();
  }
  refresh() {
    this.oauthService.refreshToken();
  }
  logout() {
    this.oauthService.logOut(false);
  }
  hasValidToken() {
    return this.oauthService.hasValidAccessToken();
  }

}
