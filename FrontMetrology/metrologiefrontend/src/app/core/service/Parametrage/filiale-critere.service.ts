import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { FilialeCritere } from '../../modeles/Parametrage/filiale-critere.model';
import { DomaineService } from './domaine.service';

@Injectable({
  providedIn: 'root'
})
export class FilialeCritereService {

  listFilaileCritere : FilialeCritere[];
  filialecritere : FilialeCritere;

  formFilialeCritere=this.fb.group({
    filialeCritereId : [""],
    fkFiliale :[""] ,
    subsidiarylabel : [""],
    fkCritere :[""] ,
  }); 
  constructor(
    private http: HttpClient, 
    private fb: FormBuilder) { }

    initializeFormForEdit(filialecritere: FilialeCritere) {
    this.formFilialeCritere.setValue({
      filialeCritereId: filialecritere.filialeCritereId,
      fkFiliale: filialecritere.fkFiliale,      
      fkCritere: filialecritere.fkCritere
      });
  }
  initializeFormForPost() {
    this.formFilialeCritere.setValue({
      filialeCritereId: '00000000-0000-0000-0000-000000000000',
      fkFiliale: '',
      subsidiarylabel: '',
      fkCritere: ''
    });
  }

  PostFilialeCritere() 
  {
    return this.http.post(environment.MetrologyBackend + "/FilialeCritere/PostFilialeCritere",this.formFilialeCritere.value);
  }

  UpdateFilialeCritere() {
    return this.http.put(environment.MetrologyBackend + "/FilialeCritere/PutFilialeCritere", this.formFilialeCritere.value)
  }

  GetAllFilialeCriteres() {
    return this.http.get(environment.MetrologyBackend + "/FilialeCritere/GetListFilialeCritere");
  }

  DeleteFilialeCritere(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/FilialeCritere/DeleteFilialeCritere?id=" + id)
  }

}
