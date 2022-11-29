import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder ,ReactiveFormsModule } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { NoteCritere } from '../../modeles/Parametrage/note-critere.model';

@Injectable({
  providedIn: 'root'
})
export class NoteCritereService {

  listNoteCritere : NoteCritere[];
  NoteCritere : NoteCritere;

  constructor( private http: HttpClient, 
    private fb: FormBuilder) { }

addNoteCritereForm = this.fb.group ({
  //noteCritereId:[''],
  Note : 0 ,
  DateDebut : Date,
  FkCritere :'',
  FkFiliale : '',
  FkNoteAxe : '',
  done: true
})

InitialiseNoteCritereForm(){
  this.addNoteCritereForm.setValue ({
  // noteCritereId:'00000000-0000-0000-0000-000000000000',
    Note : 0 ,
    DateDebut : '',
    FkCritere : '',
    FkFiliale : '',
    FkNoteAxe :''
  })
}


GetNoteCritere(id:string) {
 
  return this.http.get(environment.MetrologyBackend + "/NoteCritere/GetNoteCritere?id=" + id)
}


PostNoteCritere() {
  return this.http.post(environment.MetrologyBackend + "/NoteCritere/PostNoteCritere", this.addNoteCritereForm.value)
}

GetListNoteCritere() {
  return this.http.get(environment.MetrologyBackend + "/NoteCritere/GetListNoteCritere");
}

GetListNoteCritereByFililale() {
  return this.http.get(environment.MetrologyBackend + "/NoteCritere/GetNoteCritereByfilial");
}
DeleteNoteCritere(id:string) {
  return this.http.delete(environment.MetrologyBackend + "/NoteCritere/DeleteNoteCritere?id=" + id)
}


GetNoteCritereByfilialByDate(id:any ,date: any) {
  return this.http.get(environment.MetrologyBackend + "/NoteCritere/GetNoteCritereByfilialByDate?id2="+id + "&datesearch=" + date );
}

GetCriteretNoteCritereByfilialByDate(id:any , id2: any , date: any) {
  return this.http.get(environment.MetrologyBackend + "/NoteCritere/GetCriteretNoteCritereByfilialByDate?id1="+id +"&id2=" + id2+ "&datesearch=" + date );
}




UpdateNoteCritere() {
  return this.http.put(environment.MetrologyBackend + "/NoteCritere/PutNoteCritere", this.addNoteCritereForm.value)
}


}
