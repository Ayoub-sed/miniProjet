import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NoteAxe } from '../../modeles/Parametrage/NoteAxe';

@Injectable({
  providedIn: 'root'
})
export class NoteAxeService {


  listNoteAxe : NoteAxe[];
  NoteAxe : NoteAxe;
  constructor(private http: HttpClient, 
    private fb: FormBuilder) { }
  addNoteAxeForm = this.fb.group ({
    NoteAxeId : '00000000-0000-0000-0000-000000000000',
    note : 0 ,
    dateDebut : Date,
    fkFiliale : '',
    axe : '',
    fkCritere : '',



  })

  
  
    GetNoteAxe(id:string) {
 
    return this.http.get(environment.MetrologyBackend + "/NoteAxe/GetNoteAxe?id=" + id)
  }
  


  
PostNoteAxe() {
  return this.http.post(environment.MetrologyBackend + "/NoteAxe/PostNoteAxe", this.addNoteAxeForm.value)
}

GetListNoteAxe() {
  return this.http.get(environment.MetrologyBackend + "/NoteAxe/GetListNoteAxe");
}

GetNoteAxeByFilialeAndDateAndAxeName(id:any , d: Date , name: any) {
  return this.http.get(environment.MetrologyBackend + "/NoteAxe/GetNoteAxeByFilialeAndDateAndAxeName?fkFiliale="+id +"&date=" + d+ "&libelleaxe=" + name );
}
DeleteNoteAxe(id:string) {
  return this.http.delete(environment.MetrologyBackend + "/NoteAxe/DeleteNoteAxe?id=" + id)
}


UpdateNoteAxe() {
  return this.http.put(environment.MetrologyBackend + "/NoteAxe/PutNoteAxe", this.addNoteAxeForm.value)
}

}


