import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }
//   public getData = (route: string) => {
//     return this.http.get<any[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
//   }
//  public create = (route: string, body:any) => {
//     return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
//   }
//   public delete = (route: string) => {
//     return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
//   }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
