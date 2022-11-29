import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Prestataire, PrestataireDTO } from '../../modeles/Parametrage/prestataire';
import { Supplier } from '../../modeles/Parametrage/supplier';

@Injectable({
  providedIn: 'root'
})
export class PrestataireService {

  formPrestataire=this.fb.group({
    prestataireId : [""],
    matricule :[""] ,
    nomPrenom :[""] ,
    adresse :[""] ,
    telephone :[""] ,
    typeAccredite:[""] ,
    
  });
  prestataireDto : PrestataireDTO;
  listPrestataireDto : PrestataireDTO[];
  listPrestataireDtoNew : Supplier[];
  constructor(private http: HttpClient, private fb: FormBuilder) { }
  initializeFormForPost() {
    this.formPrestataire.setValue({
      prestataireId: '00000000-0000-0000-0000-000000000000',
      matricule: '',
      nomPrenom: '',
      adresse: '',
      telephone: '',
      typeAccredite:''
    });
  }

  initializeFormForUpdate(prestataire : Prestataire) {
    this.formPrestataire.setValue({
      prestataireId: prestataire.prestataireId,
      matricule: prestataire.matricule,
      nomPrenom: prestataire.nomPrenom,
      adresse:prestataire.adresse,
      telephone: prestataire.telephone,
      typeAccredite: prestataire.typeAccredite,
    });
  }
  PostPrestataire() {
    return this.http.post(environment.MetrologyBackend + "/Prestataire/PostPrestataire", this.formPrestataire.value)
  }

  GetAllPrestataire() {
    return this.http.get(environment.MetrologyBackend + "/Prestataire/GetListPrestataireDto");
  }
  GetListPrestataire() {
    return this.http.get(environment.MetrologyBackend + "/Prestataire/GetListPrestataire");
  }
  DeletePrestataire(id:string) {
    return this.http.delete(environment.MetrologyBackend + "/Prestataire/DeletePrestataire?id=" + id)
  }


  UpdatePrestataire() {
    return this.http.put(environment.MetrologyBackend + "/Prestataire/PutPrestataire", this.formPrestataire.value)
  }
}