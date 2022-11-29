import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { TypeIntervention } from '../../modeles/Parametrage/typeIntervention';

@Injectable({
  providedIn: 'root'
})
export class TypeInterventionService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }
  
  typeIntervention:TypeIntervention;
  listTypeIntervention:TypeIntervention[];

  formTypeIntervention=this.fb.group({
  typeInterventionId : [""],
  libelleTypeInterv :[""],
  });
  
  initializeFormTypeInterventionForEdit(typeIntervention: TypeIntervention ) {
    this.formTypeIntervention.setValue({
      typeInterventionId: typeIntervention.typeInterventionId,
      libelleTypeInterv: typeIntervention.libelleTypeInterv,

      });
  }
  initializeFormTypeInterventionForPost() {
    this.formTypeIntervention.setValue({
      typeInterventionId:'00000000-0000-0000-0000-000000000000',
      libelleTypeInterv: '',
    });
  } 


  GetListTypeIntervention() {
    return this.http.get(environment.MetrologyBackend + "/TypeIntervention/GetListTypeIntervention");
  }
  UpdateTypeIntervention() {
    return this.http.put(environment.MetrologyBackend + "/TypeIntervention/PutTypeIntervention", this.formTypeIntervention.value)
  }
  PostTypeIntervention() {
    return this.http.post(environment.MetrologyBackend + "/TypeIntervention/PostTypeIntervention", this.formTypeIntervention.value)
  }
  DeleteTypeIntervention(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/TypeIntervention/DeleteTypeIntervention?id=" + id)
  }
}
