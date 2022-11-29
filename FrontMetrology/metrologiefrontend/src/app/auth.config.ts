import { AuthConfig } from 'angular-oauth2-oidc';
export const authPasswordFlowConfig: AuthConfig = {
  issuer: 'http://192.168.160.57/hajerauth',
  redirectUri: "http://localhost:4200",
  postLogoutRedirectUri: "http://localhost:4200",
  responseType: 'id_token token',
  clientId: 'MetrologieLegale',
  scope: 'openid profile offline_access IdentityServerApi MertologieLegaleApi',
  showDebugInformation: true,
  requireHttps: false,
};
