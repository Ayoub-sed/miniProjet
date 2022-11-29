import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { FraisIntervention, FraisInterventionDto } from '../../modeles/Parametrage/FraisIntervention';

@Injectable({
  providedIn: 'root'
})
export class FraisInterventionService {
  listfraisinterventiondto: FraisInterventionDto[];
  AddOrUpdateFraisInterventionForm = this.fb.group({
    fraisInterventionId: [''],
    FkFiliale: [''],
    DateIntervention: ['', [Validators.required]],
    Frais: ['', Validators.required],
    LibelleIntervention: ['', Validators.required],
    TypeIntervention: [''],
    fkEquipement: [''],
    fkPrestataire: ['']
  })
  fraisintervention = new FraisIntervention;
  constructor(public http: HttpClient, private fb: FormBuilder) { }
  initializeAddForm() {
    this.AddOrUpdateFraisInterventionForm.setValue({
      fraisInterventionId: '00000000-0000-0000-0000-000000000000',
      FkFiliale: '',
      DateIntervention: '',
      Frais: null,
      LibelleIntervention: '',
      TypeIntervention: '',
      fkEquipement: '',
      fkPrestataire: ''
    });
  }
  initializeUpdateForm(fraisIntervention: FraisIntervention) {
    this.AddOrUpdateFraisInterventionForm.setValue({
      fraisInterventionId: fraisIntervention.fraisInterventionId,
      FkFiliale: fraisIntervention.fkFiliale,
      DateIntervention: fraisIntervention.dateIntervention,
      Frais: fraisIntervention.frais,
      LibelleIntervention: fraisIntervention.libelleIntervention,
      TypeIntervention: fraisIntervention.typeIntervention,
      fkPrestataire: fraisIntervention.fkPrestataire,
      fkEquipement: fraisIntervention.fkEquipement
    });
  }
  PostFraisIntervention() {
    return this.http.post(environment.MetrologyBackend + "/FraisIntervention/PostFraisIntervention", this.AddOrUpdateFraisInterventionForm.value)
  }

  UpdateFraisIntervention() {

    return this.http.put(environment.MetrologyBackend + "/FraisIntervention/PutFraisIntervention", this.AddOrUpdateFraisInterventionForm.value)
  }
  GetListFraisInterventionByTypeIntervention(fkFiliale: string, dateintervention: string) {
    return this.http.get(environment.MetrologyBackend + "/FraisIntervention/GetListFraisInterventionByTypeIntervention?fkFiliale=" + fkFiliale + "&dateintervention=" + dateintervention);
  }
  DeleteFraisIntervention(fkFraisIntervention: string) {
    return this.http.delete(environment.MetrologyBackend + "/FraisIntervention/DeleteFraisIntervention?id=" + fkFraisIntervention);
  }
}
