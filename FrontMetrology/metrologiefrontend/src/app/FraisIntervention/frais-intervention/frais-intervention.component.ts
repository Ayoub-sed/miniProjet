import { state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AxeInterventionEnum } from 'src/app/core/modeles/Parametrage/AxeInterventionEnum';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { SubsidiaryService } from 'src/app/core/service/subsidiary.service';

@Component({
  selector: 'app-frais-intervention',
  templateUrl: './frais-intervention.component.html',
  styleUrls: ['./frais-intervention.component.css']
})
export class FraisInterventionComponent implements OnInit {
fkfiliale: string;
filiale: Subsidiary;
mySet1 = new Set()
data:string;

setArray: any[]
listSectors: any[];
  constructor(public subsidiaryService : SubsidiaryService, private router : Router) {
   
   }

  ngOnInit(): void {
    this.subsidiaryService.GetAllSubsidiaries().subscribe(res => {
      this.subsidiaryService.listSubsidiary = (res as Subsidiary[]);  
      this.subsidiaryService.listSubsidiary.forEach(element => {
        if (element.sectorLabel !== null) {
          this.mySet1.add([element.sectorLabel,element.fkSector]),
          this.setArray  = Array.from(this.mySet1)
        }
        console.log('setarray',this.setArray);});})

  }
  onChangeSubsidiary(event :Subsidiary) {
  this.fkfiliale = event.subsidiaryId;
  this.filiale = event;
  }
  choix (){
    this.router.navigate(['/ListFraisIntervention/', this.fkfiliale, this.filiale.label]);
  }
  filterBySecteur(idSecteur:string){
    this.subsidiaryService.GetAllSubsidiaries().subscribe(res => {
      this.subsidiaryService.listSubsidiary=(res as Subsidiary[]).filter(x=>x.fkSector==idSecteur)
      })
  }
}
