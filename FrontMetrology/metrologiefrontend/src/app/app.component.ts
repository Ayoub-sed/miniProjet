import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { OAuthService } from "angular-oauth2-oidc";
import { BehaviorSubject } from "rxjs";
import { filter } from "rxjs/operators";
import { authPasswordFlowConfig } from "./auth.config";
import { AuthenticationService } from "./core/service/Authentication.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  title = "MÉTROLOGIE LÉGALE";

  constructor(
    private oauthService: OAuthService,
    public authService: AuthenticationService,
    public router: Router,
    
  ) {
    this.oauthService.configure(authPasswordFlowConfig);
    this.oauthService.setStorage(localStorage);
    this.oauthService.loadDiscoveryDocumentAndLogin();
    this.oauthService.setupAutomaticSilentRefresh();
    this.oauthService.events
      .pipe(filter((e) => e.type === "token_received"))
      .subscribe((_) =>
        this.oauthService
          .loadUserProfile()
          .then((response) => {
          })
          .catch((error) => {
            console.log(error);
          })
          .finally()
      );
  }
  ngOnInit() {
    this.oauthService.events
      .pipe(filter((e) => e.type === "token_received"))
      .subscribe((_) => {
        this.oauthService
          .loadUserProfile()
          .then((response) => {
            this.authService.currentUser = JSON.parse(
              localStorage.getItem("id_token_claims_obj") || "{}"
            ).FullName;
            this.authService.currentUserRole = JSON.parse(
              localStorage.getItem("id_token_claims_obj") || "{}"
            ).role;
            this.authService.currentUserMatricule = JSON.parse(
              localStorage.getItem("id_token_claims_obj") || "{}"
            ).IdentityCardNumber;
            this.authService.currentUserSubject = new BehaviorSubject<any>(
              this.oauthService.getIdentityClaims()
            );
            this.authService.User =
              this.authService.currentUserSubject.asObservable();
          })
          .catch((error) => {
            console.log(error);
          })
          .finally();
      });
    let test = JSON.parse(localStorage.getItem("id_token_claims_obj") || "{}");
    if (
      JSON.parse(localStorage.getItem("id_token_claims_obj") || "{}") != null
    ) {
      this.authService.currentUser = JSON.parse(
        localStorage.getItem("id_token_claims_obj") || "{}"
      ).FullName;
      this.authService.currentUserRole = JSON.parse(
        localStorage.getItem("id_token_claims_obj") || "{}"
      ).role;
      this.authService.currentUserMatricule = JSON.parse(
        localStorage.getItem("id_token_claims_obj") || "{}"
      ).IdentityCardNumber;
      this.authService.currentUserSubject = new BehaviorSubject<any>(
        JSON.parse(localStorage.getItem("id_token_claims_obj") || "{}")
      );
      this.authService.User =
        this.authService.currentUserSubject.asObservable();
    }
  }
}
