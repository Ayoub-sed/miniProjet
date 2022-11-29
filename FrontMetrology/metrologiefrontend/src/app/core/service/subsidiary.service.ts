import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Sector } from '../modeles/Parametrage/sector.model';
import { Subsidiary } from '../modeles/subsidiary.model';

@Injectable({
  providedIn: 'root'
})
export class SubsidiaryService {

  form = this.fb.group({
    subsidiaryId: [""],
    subsidiaryCode: [""],
    label: [""],
    logo: [""],
    fkSector: [""],
  });

  searchForm = this.fb.group({
    searchKey: [""],
  });

  initializeSearchForm() {
    this.searchForm.setValue({
      searchKey: '',
    });
  }

  listSubsidiary: Subsidiary[];
  listSectors : Sector[];
  subsidiary: Subsidiary;
  subsidiaryUserConnected: Subsidiary;
  subsidiaryList: Subsidiary[];
  subsidiaryLoyer = new Subsidiary;
  subsidiaryPart2: Subsidiary;
  subsidiaryPart2Loyer: Subsidiary;
  listSubsidarySearch: any;
  constructor(private http: HttpClient, private fb: FormBuilder) { }

  GetAllSectors() {
    return this.http.get(environment.SubsidiariesMicroservice + "/Sector");
  }
  GetSubsidiariesBySectors(SectorId: string) {
    return this.http.get(environment.SubsidiariesMicroservice + "/Subsidiary/GetSubsidiariesBySectorId?SectorId=" + SectorId);
  }
  GetAllSubsidiaries() {
    return this.http.get(environment.SubsidiariesMicroservice + "/Subsidiary/GetListSubsidiaries");
  }
  SerachSubsidary(searchKey :string) {
    return this.http.get(environment.SubsidiariesMicroservice + "/Subsidiary/SerachSubsidary?searchKey=" + searchKey);
  }

}
