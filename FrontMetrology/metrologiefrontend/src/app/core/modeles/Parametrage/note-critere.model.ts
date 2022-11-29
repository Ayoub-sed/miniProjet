export class NoteCritere { 

  noteCritereId : string;
  note : number ;
  dateDebut : Date ;
  fkCritere : string;
  fkFiliale : string;
  fkNoteAxe : string;
  done: boolean
}

export class NoteCritereDto{
    fkFiliale : string;
    NoteCritere:NoteCritere[];
}
