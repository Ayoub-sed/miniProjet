import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { DomaineService } from './domaine.service';

@Injectable({
  providedIn: 'root'
})
export class DomainePrestataireService {
  
  formDomainePrestataire=this.fb.group({
    prestataireDomaineId : [""],
    fkPrestataire :[""] ,
    fkDomaine :[""] ,
    accredite :false ,
    agree :false ,
  });
  constructor(
    private http: HttpClient, 
    private fb: FormBuilder,
    public domaineService : DomaineService) { }


  PostPrestataireDomaine() 
  {
    return this.http.post(environment.MetrologyBackend + "/PrestataireDomaine/PostRangePrestataireDomaine",this.domaineService.listDomaineSelectionnes,{responseType: 'text'});
  }
}
