import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Domaine, DomaineForPost } from '../../modeles/Parametrage/domaine';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DomaineService {
  
  constructor(private http: HttpClient, private fb: FormBuilder) { }

  domaine:Domaine;
  formDomaine=this.fb.group({
    domaineId : [""],
    libelleDomaine :[""] 
  });
  listDomaines:Domaine[];
  hideDomainList=false;
  hideDomainListForupdate=false;
  listDomaineSelectionnes:DomaineForPost[];
  initializeFormDomaineForEdit(domaine: Domaine ) {
    this.formDomaine.setValue({
      domaineId: domaine.domaineId,
      libelleDomaine: domaine.libelleDomaine,
      });
  }
  initializeFormForPost() {
    this.formDomaine.setValue({
      domaineId: '00000000-0000-0000-0000-000000000000',
      libelleDomaine: '',
    });
  }
  GetListDomaines() {
    return this.http.get(environment.MetrologyBackend + "/Domaine/GetListDomaine");
  }
  UpdateDomaine() {
    return this.http.put(environment.MetrologyBackend + "/Domaine/PutDomaine", this.formDomaine.value)
  }
  PostDomaine() {
    return this.http.post(environment.MetrologyBackend + "/Domaine/PostDomaine", this.formDomaine.value)
  }
  DeleteDomaine(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/Domaine/DeleteDomaine?id=" + id)
  }
}
