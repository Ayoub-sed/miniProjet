import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FormBuilder, Validators } from '@angular/forms';
import { AddSupplier, Supplier, SupplierSearch } from '../../modeles/Parametrage/supplier';
import { Prestataire } from '../../modeles/Parametrage/prestataire';


@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  
  listSupplier: Supplier[];
  listPrestataire: Prestataire[];
  supplier: Supplier;
  listSupplierSearch: SupplierSearch[];


  form = this.fb.group({
    prestataireId: [""],
    NomPrenom: [""],
    matricule: [""],
   
  });


  searchForm = this.fb.group({
    searchKey: [""],
  });

  initializeSearchForm() {
    this.searchForm.setValue({
      searchKey: '',
    });
  }

  initializeFormForPost() {
    this.form.setValue({
      prestataireId: '00000000-0000-0000-0000-000000000000',
      NomPrenom: '',
      matricule: ''
    });
  }

  initializeFormForEdit(supplier: AddSupplier) {
    this.form.setValue({
      prestataireId: supplier.prestataireId,
      NomPrenom: supplier.NomPrenom,
      matricule: supplier.matricule,
     
    });
  }


  constructor(private http: HttpClient, private fb: FormBuilder) { }

  getListSuppliers() {
    return this.http.get(environment.SupplierMicroservice + "/Supplier/GetListSupplier")
  }

  getSupplierById(id:string) {
    if (id == null) {
      return null;
    }
    return this.http.get(environment.SupplierMicroservice + "/Supplier/GetSupplierByIdDto?id=" + id);
  }

  SerachSupplierWithKeyWord(searchKey:string) {
    return this.http.get(environment.SupplierMicroservice + "/Supplier/SerachSupplier?searchKey=" + searchKey);
  }


  SerachSupplier(searchKey:string) {
    return this.http.get(environment.SupplierMicroservice + "/Supplier/SerachSupplier?searchKey=" + searchKey);
  }


  insertSupplier() {
    return this.http
      .post(
        environment.SupplierMicroservice + "/Supplier",
        this.form.value,
        { responseType: "text" }
      );
  }

  getSupplierWithoutCode() {
    return this.http.get(environment.SupplierMicroservice + "/Supplier/GetListSupplierWithoutCode")
  }

  putSupplier() {
    return this.http
      .put(
        environment.SupplierMicroservice + "/Supplier/" + this.form.controls.supplierId.value,
        this.form.value,
        { responseType: "text" }
      );
  }

  DeleteSupplier(supplierId:string) {
    return this.http
      .delete(environment.SupplierMicroservice + "/Supplier/" + supplierId,
        { responseType: "text" });
  }
}
