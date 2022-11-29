import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { SubsidiaryService } from 'src/app/core/service/subsidiary.service';

@Component({
  selector: 'app-choose-filiale-for-equipements',
  templateUrl: './choose-filiale-for-equipements.component.html',
  styleUrls: ['./choose-filiale-for-equipements.component.css']
})
export class ChooseFilialeForEquipementsComponent implements OnInit {
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
            this.mySet1.add(element.sectorLabel),
            this.setArray  = Array.from(this.mySet1)
          }
          });})
  
    }
    onChangeSubsidiary(event :Subsidiary) {
      console.log('selected');
      
    this.fkfiliale = event.subsidiaryId;
    this.filiale = event;
    }
    choix (){
      this.router.navigate(['/ChooseFilialeEquipements/', this.fkfiliale, this.filiale.label]);
    }
    selectSecteur(){
      console.log('selected',this.data);
      this.subsidiaryService.GetAllSubsidiaries().subscribe(res => {
        this.subsidiaryService.listSubsidiary=(res as Subsidiary[]).filter(x=>x.sectorLabel==this.data)
      
      })
    }
  }
  