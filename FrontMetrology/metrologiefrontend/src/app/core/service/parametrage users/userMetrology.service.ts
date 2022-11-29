import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Userlabo, UserlaboDto } from '../../modeles/userlabo.model';

@Injectable({
  providedIn: 'root'
})
export class UserMetrologyService {
  user:Userlabo;
  formUserlabo=this.fb.group({
    userLaboId:[""],
    matricule:["",Validators.required],
    fkLabo:["",Validators.required],
    labo:null,
    signatureUsers:null,  
  });
  listUserlabo:Userlabo[];
  listUserlaboDto:UserlaboDto[];

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  initializeFormForEdit(userlabo: Userlabo ) {
    this.formUserlabo.setValue({
      userLaboId: userlabo.userLaboId,
      matricule: userlabo.matricule,
      //libelleLabo: userlabo.libelleLabo,
      fkLabo: userlabo.fkLabo,
      labo:null,
      signatureUsers:null,  

    });
  }
  initializeFormForPost() {
    this.formUserlabo.setValue({
      userLaboId: '00000000-0000-0000-0000-000000000000',
      fkLabo: null,
      matricule:'00000000-0000-0000-0000-000000000000',
      //libelleLabo:'',
      labo:null,
      signatureUsers:null,  
    });
  }
  
}
