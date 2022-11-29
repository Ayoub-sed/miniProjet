import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Critere, CritereDto } from '../../modeles/Parametrage/critere.model';

@Injectable({
  providedIn: 'root'
})
export class CritereService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  formCritere=this.fb.group({
    critereId : [""],
    codeCritere :[] ,
    libelleCritere :[""] ,
    axe :[""] ,
    coefficient :[] ,
   
  });
  critere : Critere;
  listCritere : Critere[];
  listCritereDto : CritereDto[];
  initializeFormForPost() {
    this.formCritere.setValue({
      critereId: '00000000-0000-0000-0000-000000000000',
      codeCritere: '',
      libelleCritere: '',
      axe: '',
      coefficient: '',
  
    });
  }

  initializeFormForUpdate(critere : Critere) {
    this.formCritere.setValue({
      critereId: critere.critereId,
      codeCritere: critere.codeCritere,
      libelleCritere: critere.libelleCritere,
      axe:critere.axe,
      coefficient: critere.coefficient,
    });
  }

  GetAllCritere() {
    return this.http.get(environment.MetrologyBackend + "/Critere/GetListCritere");
  }
  GetListCritereGroupedByAxe() {
    return this.http.get(environment.MetrologyBackend + "/Critere/GetListCritereGroupedByAxe");
  }
  PostCritere() {
    return this.http.post(environment.MetrologyBackend + "/Critere/PostCritere", this.formCritere.value)
  }
 
  UpdateCritere() {
    return this.http.put(environment.MetrologyBackend + "/Critere/PutCritere", this.formCritere.value)
  }
  
  DeleteCritere(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/Critere/DeleteCritere?id=" + id)
  }
  GettNoteCritereByfilialByDate(id:any , date: any) {
    return this.http.get(environment.MetrologyBackend + "/Critere/GetListCritereGroupedByAxeWithNote?idF="+id+ "&dateSearch=" + date );
  }

}
