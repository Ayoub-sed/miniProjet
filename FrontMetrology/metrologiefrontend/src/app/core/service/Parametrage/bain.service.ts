import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BainService {

 
  constructor(private http: HttpClient, private fb: FormBuilder) { }

  formBain=this.fb.group({
    
    
  });
  
  GetListBain() {
    return this.http.get(environment.MetrologyBackend + "/Bain/GetListBain");
  }
  GetBain() {
    return this.http.get(environment.MetrologyBackend + "/Bain/GetBain");
  }
  PostBain() {
    return this.http.post(environment.MetrologyBackend + "/Bain/PostBain", this.formBain.value)
  }
 
  PutBain() {
    return this.http.put(environment.MetrologyBackend + "/Bain/PutBain", this.formBain.value)
  }
  
  DeleteBain(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/Bain/DeleteBain?id=" + id)
  }
}
