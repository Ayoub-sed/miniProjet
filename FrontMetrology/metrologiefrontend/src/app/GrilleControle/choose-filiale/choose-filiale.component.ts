import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { SubsidiaryService } from 'src/app/core/service/subsidiary.service';

@Component({
  selector: 'app-choose-filiale',
  templateUrl: './choose-filiale.component.html',
  styleUrls: ['./choose-filiale.component.css']
})
export class ChooseFilialeComponent implements OnInit {
   mySet1 = new Set()
  data:string;
  fkfiliale: string;
  filiale: Subsidiary;
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
          
          console.log(this.setArray);});})

   
    }


    
    onChangeSubsidiary(event :Subsidiary) {
    this.fkfiliale = event.subsidiaryId;
    this.filiale = event;
    }
    choix (){
      this.router.navigate(['/ListChooseFiliale/', this.fkfiliale, this.filiale.label]);
    }
    filterBySecteur(idSecteur:string){
      this.subsidiaryService.GetAllSubsidiaries().subscribe(res => {
      this.subsidiaryService.listSubsidiary=(res as Subsidiary[]).filter(x=>x.fkSector==idSecteur)
      })
    }
  

}
