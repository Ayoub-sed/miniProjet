import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnsacheuseService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  formEnsacheuse=this.fb.group({
    
    
  });
  
  GetListEnsacheuse() {
    return this.http.get(environment.MetrologyBackend + "/Ensacheuse/GetListEnsacheuse");
  }
  GetEnsacheuse() {
    return this.http.get(environment.MetrologyBackend + "/Ensacheuse/GetEnsacheuse");
  }
  PostEnsacheuse() {
    return this.http.post(environment.MetrologyBackend + "/Ensacheuse/PostEnsacheuse", this.formEnsacheuse.value)
  }
 
  PutEnsacheuse() {
    return this.http.put(environment.MetrologyBackend + "/Ensacheuse/PutEnsacheuse", this.formEnsacheuse.value)
  }
  
  DeleteEnsacheuse(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/Ensacheuse/DeleteEnsacheuse?id=" + id)
  }

}
