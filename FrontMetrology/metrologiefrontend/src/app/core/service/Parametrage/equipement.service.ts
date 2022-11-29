import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Equipement } from '../../modeles/Parametrage/Equipement';

@Injectable({
  providedIn: 'root'
})
export class EquipementService {
  Method: string;
  constructor(private http: HttpClient, private fb: FormBuilder) { }
  formEquipement=this.fb.group({
    equipementId: '00000000-0000-0000-0000-000000000000',
    identifiantInterne: [""],
    numeroSerie:0 ,
    marque: [""],
    type: [""],
    libelle: [""],
    temperature: 0 ,
    dateEtalonnage: [""],
    datePoinconnage: null, 
    dateReparation: null, 
    dateVerification:[""]  ,
    porteMax: 0 ,  
    porteMin: 0 , 
    echellonDeVerification: 0 ,
    numApprobation: 0 ,
    numVignette: 0 ,
    nombreCapteurs:0,
    pressionMesuree:0 ,
    fkFiliale : [""],
   
  });
  initializeFormForUpdate(equipement : Equipement) {
    this.formEquipement.setValue({
      equipementId: equipement.equipementId,
      identifiantInterne: equipement.identifiantInterne,
      numeroSerie: equipement.numeroSerie,
      marque: equipement.marque,
      type: equipement.type,
      libelle: equipement.libelle,
      temperature: equipement.temperature+0,
      dateEtalonnage: equipement.dateEtalonnage+"",
      dateVerification:equipement.dateVerification+"",
      porteMax: equipement.porteMax+0,
      porteMin: equipement.porteMin+0,
      echellonDeVerification: equipement.echellonDeVerification+"",
      numApprobation: equipement.numApprobation+0,
      numVignette: equipement.numVignette+0,
      datePoinconnage: equipement.datePoinconnage+"",
      pressionMesuree: equipement.pressionMesuree+"",
      nombreCapteurs : equipement.nombreCapteurs+0,
      dateReparation: equipement.dateReparation+"",
      fkFiliale : equipement.fkFiliale+"",

    });
  }

  equipement : Equipement;
  listequipement : Equipement[];
  GetListEquipement() {
    return this.http.get(environment.MetrologyBackend + "/Equipement/GetListEquipement");
  }

  GetListEquipementByFiliale(id: any) {
    return this.http.get(environment.MetrologyBackend + "/Equipement/GetListEquipementDtoByFiliale?id="+id);
  }

  DeleteEquipement(id: any) {
    return this.http.delete(environment.MetrologyBackend + "/Equipement/DeleteEquipement?id=" + id)
  }

  PostBain() {
    return this.http.post(environment.MetrologyBackend + "/Bain/PostBain", this.formEquipement.value)
  }
  PuttBain() {
    return this.http.put(environment.MetrologyBackend + "/Bain/PutBain", this.formEquipement.value)
  }
  PostThermohygometre() {
    return this.http.post(environment.MetrologyBackend + "/Thermohygometre/PostThermohygometre", this.formEquipement.value)
  }
  PuttThermohygometre() {
    return this.http.put(environment.MetrologyBackend + "/Thermohygometre/PutThermohygometre", this.formEquipement.value)
  }
  PostTunnelDeRefroidissement() {
    return this.http.post(environment.MetrologyBackend + "/TunnelDeRefroidissement/PostTunnelDeRefroidissement", this.formEquipement.value)
  }
  PuttTunnelDeRefroidissement() {
    return this.http.put(environment.MetrologyBackend + "/TunnelDeRefroidissement/PutTunnelDeRefroidissement", this.formEquipement.value)
  }
  PostTransmtteurDePression() {
    return this.http.post(environment.MetrologyBackend + "/TransmtteurDePression/PostTransmtteurDePression", this.formEquipement.value)
  }
  PuttTransmtteurDePression() {
    return this.http.put(environment.MetrologyBackend + "/TransmtteurDePression/PutTransmtteurDePression", this.formEquipement.value)
  }
  PostSondeRedox() {
    return this.http.post(environment.MetrologyBackend + "/SondeRedox/PostSondeRedox", this.formEquipement.value)
  }
  PuttSondeRedox() {
    return this.http.put(environment.MetrologyBackend + "/SondeRedox/PutSondeRedox", this.formEquipement.value)
  }

  PostRefrigerateur() {
    return this.http.post(environment.MetrologyBackend + "/Refrigerateur/PostRefrigerateur", this.formEquipement.value)
  }
  PuttRefrigerateur() {
    return this.http.put(environment.MetrologyBackend + "/Refrigerateur/PutRefrigerateur", this.formEquipement.value)
  }
  PostPontsBasculeElectronique() {
    return this.http.post(environment.MetrologyBackend + "/PontsBasculeElectronique/PostPontsBasculeElectronique", this.formEquipement.value)
  }
  PuttPontsBasculeElectronique() {
    return this.http.put(environment.MetrologyBackend + "/PontsBasculeElectronique/PutPontsBasculeElectronique", this.formEquipement.value)
  }
  PostManometreDePression() {
    return this.http.post(environment.MetrologyBackend + "/ManometreDePression/PostManometreDePression", this.formEquipement.value)
  }
  PuttManometreDePression() {
    return this.http.put(environment.MetrologyBackend + "/ManometreDePression/PutManometreDePression", this.formEquipement.value)
  }
  PostFour() {
    return this.http.post(environment.MetrologyBackend + "/Four/PostFour", this.formEquipement.value)
  }
  PuttFour() {
    return this.http.put(environment.MetrologyBackend + "/Four/PutFour", this.formEquipement.value)
  }
  PostEtuve() {
    return this.http.post(environment.MetrologyBackend + "/Etuve/PostEtuve", this.formEquipement.value)
  }
  PuttEtuve() {
    return this.http.put(environment.MetrologyBackend + "/Etuve/PutEtuve", this.formEquipement.value)
  }
  PostDebimetreMassique() {
    return this.http.post(environment.MetrologyBackend + "/DebimetreMassique/PostDebimetreMassique", this.formEquipement.value)
  }
  PuttDebimetreMassique() {
    return this.http.put(environment.MetrologyBackend + "/DebimetreMassique/PutDebimetreMassique", this.formEquipement.value)
  }
  PostDebimetreVolumetrique() {
    return this.http.post(environment.MetrologyBackend + "/DebimetreVolumetrique/PostDebimetreVolumetrique", this.formEquipement.value)
  }
  PuttDebimetreVolumetrique() {
    return this.http.put(environment.MetrologyBackend + "/DebimetreVolumetrique/PutDebimetreVolumetrique", this.formEquipement.value)
  }
  PostChambreFroide() {
    return this.http.post(environment.MetrologyBackend + "/ChambreFroide/PostChambreFroide", this.formEquipement.value)
  }
  PuttChambreFroide() {
    return this.http.put(environment.MetrologyBackend + "/ChambreFroide/PutChambreFroide", this.formEquipement.value)
  }
  PostConductivimetre() {
    return this.http.post(environment.MetrologyBackend + "/Conductivimetre/PostConductivimetre", this.formEquipement.value)
  }
  PuttConductivimetre() {
    return this.http.put(environment.MetrologyBackend + "/Conductivimetre/PutConductivimetre", this.formEquipement.value)
  }
  PostEnsacheuse() {
    return this.http.post(environment.MetrologyBackend + "/Ensacheuse/PostEnsacheuse", this.formEquipement.value)
  }
  PuttEnsacheuse() {
    return this.http.put(environment.MetrologyBackend + "/Ensacheuse/PutEnsacheuse", this.formEquipement.value)
  }
  PostThermometre() {
    return this.http.post(environment.MetrologyBackend + "/Thermometre/PostThermometre", this.formEquipement.value)
  }
  PuttThermometre() {
    return this.http.put(environment.MetrologyBackend + "/Thermometre/PutThermometre", this.formEquipement.value)
  }
  PostCapteurDePression() {
    return this.http.post(environment.MetrologyBackend + "/CapteurDePression/PostCapteurDePression", this.formEquipement.value)
  }
  PuttCapteurDePression() {
    return this.http.put(environment.MetrologyBackend + "/CapteurDePression/PutCapteurDePression", this.formEquipement.value)
  }
  PostBalanceElectronique() {
    return this.http.post(environment.MetrologyBackend + "/BalanceElectronique/PostBalanceElectronique", this.formEquipement.value)
  }
  PuttBalanceElectronique() {
    return this.http.put(environment.MetrologyBackend + "/BalanceElectronique/PutBalanceElectronique", this.formEquipement.value)
  }
  PostPhMetre(){
    return this.http.post(environment.MetrologyBackend + "/PhMetre/PostPhMetre", this.formEquipement.value)
  }
  PutPhMetre(){
    return this.http.put(environment.MetrologyBackend + "/PhMetre/PutPhMetre", this.formEquipement.value)
  }
}
