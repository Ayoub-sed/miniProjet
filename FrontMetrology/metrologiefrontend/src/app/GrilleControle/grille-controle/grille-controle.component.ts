import { Component, Input, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { CritereService } from 'src/app/core/service/Parametrage/critere.service';
import { Critere, CritereDto, CritereNoteDto } from 'src/app/core/modeles/Parametrage/critere.model';
import { DatePipe } from '@angular/common';
import { SubsidiaryService } from 'src/app/core/service/subsidiary.service';
import { Subsidiary } from 'src/app/core/modeles/subsidiary.model';
import { NoteCritereService } from 'src/app/core/service/Parametrage/note-critere.service';
import { FormArray, FormBuilder, FormsModule } from '@angular/forms';
import { NoteCritere } from 'src/app/core/modeles/Parametrage/note-critere.model';
import { UserService } from 'src/app/core/service/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ReturnStatement } from '@angular/compiler';
import { NoteAxe } from 'src/app/core/modeles/Parametrage/NoteAxe';
import { NoteAxeService } from 'src/app/core/service/Parametrage/note-axe.service';
import { NgMultiLabelTemplateDirective } from '@ng-select/ng-select/lib/ng-templates.directive';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-grille-controle',
  templateUrl: './grille-controle.component.html',
  styleUrls: ['./grille-controle.component.css']
})


export class GrilleControleComponent implements OnInit {
 noteFiliale: number = 0;
 noteFinalFiliale: number = 0;
 numofaxe: number = 0;
  datesys = new Date();
  datesysteme: string;
  datepipe: DatePipe;
  bsModalRef: any;
  data: string;
  current: number = 1;
  listSubsidiary: Subsidiary[];
  listnoteCritere: NoteCritere[];
  noteCritere: NoteCritere;
  noteaxe: NoteAxe;
  listnoteaxe: NoteAxe[];
  fkcr: any;
  x: Date;
  y: string;
  random: 34
  NoteA: any;
  submittedNoteCritere: boolean;
  clicked = new Array();
  u: 0;
  i: number;
  listofnotcritere: any[];
  listofexistingnotcritere: any[];
  dataList = [
    {
      pname: "abc",
      numbers: [123, 234]
    },
    {
      pname: "mno",
      numbers: [125, 237]
    }
  ]

  lab: string;
  lab2: string;
  fkfiliale: string;
  note: number;
  noteCr: any;
  DateGrille: any;

  filiale: Subsidiary;
  Cri: any;
  Note: any;
  lengh:  number = 0;
  arrayOfCriteres: CritereNoteDto
  numberOfNC: number= 0;
  numberOfC: number= 0;

  constructor(private activateroute: ActivatedRoute, private router : Router,
    public userService: UserService, public modalService: BsModalService, public NoteAxeService: NoteAxeService, public critereService: CritereService, public SpinnerService: NgxSpinnerService, public subsidiaryService: SubsidiaryService, public NoteCritereService: NoteCritereService, public datePipe: DatePipe, public fb: FormBuilder, public _snackBar: MatSnackBar
  ) { }





  ngOnInit(): void {
    this.lab = String(this.activateroute.snapshot.paramMap.get('label'));
    this.fkfiliale = String(this.activateroute.snapshot.paramMap.get('fkfiliale'));
    this.subsidiaryService.GetAllSubsidiaries().subscribe(res => {
      this.listSubsidiary = (res as Subsidiary[]);
      this.critereService.GettNoteCritereByfilialByDate(this.fkfiliale, this.datePipe.transform(this.datesys, 'yyyy-MM-dd') as string).subscribe(res => {
        this.critereService.listCritereDto = (res as CritereDto[]);
        console.log(this.critereService.listCritereDto)
        this.noteFiliale =0;
        this.numofaxe += 0;

    




        //////////////// LIST NOTE CRITERE


        this.NoteCritereService.GetNoteCritereByfilialByDate(this.fkfiliale, this.datePipe.transform(this.datesys, 'yyyy-MM-dd') as string).subscribe(res => {
          this.listnoteCritere = (res as NoteCritere[]);
          this.listnoteCritere.forEach(element => {
            this.numberOfNC +=1;


              });
              console.log("Number of notes criteres",this.numberOfNC)
                      //////////////// LIST CRITERE
        this.critereService.listCritereDto.forEach(element => {
          this.numofaxe = 1 + this.numofaxe;
          this.noteFiliale += element.noteAxe ;

                element.critere.forEach(ress => {
                  this.arrayOfCriteres=ress;
                  console.log(this.arrayOfCriteres) 
                
               
                  // Loop for array2
                  for(let j = 0; j < this.numberOfNC; j++) {
                        
                    // Compare the element of each and
                    // every element from both of the
                    // arrays
                    if(this.arrayOfCriteres.critereId === this.listnoteCritere[j].fkCritere) {
                      
                      console.log("najahna")
                      
                    }
                }
              });

        });
        });


        this.noteFinalFiliale = this.noteFiliale / this.numofaxe

      });
    });

        


      






    this.DateGrille = this.datePipe.transform(this.datesys, 'yyyy-MM') as string;
    // this.NoteCritereService.GetNoteCritereByfilialByDate(this.fkfiliale, this.datePipe.transform(this.datesys, 'yyyy-MM-dd') as string).subscribe(res => {
    //   this.listnoteCritere = (res as NoteCritere[]);
    //   console.log(this.listnoteCritere)



    // });

      console.log(this.arrayOfCriteres)
  }
 
 
  
  changeFn(c: Critere, e: any) {
    
    if(e.target.value < 0 || e.target.value >20){
      Swal.fire({
        icon: 'error',
        title: "la valeur doit être entre 0 et 20",
      })
    }
    else
    {
    this.NoteCritereService.GetCriteretNoteCritereByfilialByDate(c.critereId, this.fkfiliale, this.DateGrille).subscribe(resN => {

      if (resN == null) {


        this.NoteCritereService.addNoteCritereForm.value.FkCritere = c.critereId;
        this.NoteCritereService.addNoteCritereForm.value.FkFiliale = this.fkfiliale;
        this.NoteCritereService.addNoteCritereForm.value.DateDebut = this.DateGrille;
        this.NoteCritereService.addNoteCritereForm.value.Note = e.target.value;
        this.NoteCritereService.PostNoteCritere().subscribe(res => { res as NoteCritere, 
          console.log("salemmm alaykom")
          this.critereService.GettNoteCritereByfilialByDate(this.fkfiliale, this.datePipe.transform(this.NoteCritereService.addNoteCritereForm.value.DateDebut, 'yyyy-MM-dd') as string).subscribe(res => {
            this.critereService.listCritereDto = (res as CritereDto[]);
            this.noteFiliale =0;
            this.numofaxe += 0;
            this.critereService.listCritereDto.forEach(element => {
              this.numofaxe += 1;
              this.noteFiliale += element.noteAxe ;
              this.arrayOfCriteres
              
            });
            console.log(this.numofaxe)
            this.noteFinalFiliale = this.noteFiliale / this.numofaxe
    
          }); });

      } else {

        this.noteCr = resN
       

        if (this.noteCr.note == e.target.value) {


        } else {

          this.NoteCritereService.addNoteCritereForm.value.noteCritereId = this.noteCr.noteCritereId
          this.NoteCritereService.addNoteCritereForm.value.FkCritere = this.noteCr.fkCritere
          this.NoteCritereService.addNoteCritereForm.value.FkFiliale = this.noteCr.fkFiliale
          this.NoteCritereService.addNoteCritereForm.value.DateDebut = this.DateGrille
          this.NoteCritereService.addNoteCritereForm.value.Note = e.target.value;
          this.NoteCritereService.UpdateNoteCritere().subscribe(res => { res as NoteCritere, 
            console.log("salemmm alaykom")
            this.critereService.GettNoteCritereByfilialByDate(this.fkfiliale, this.datePipe.transform(this.NoteCritereService.addNoteCritereForm.value.DateDebut, 'yyyy-MM-dd') as string).subscribe(res => {
              this.critereService.listCritereDto = (res as CritereDto[]);
              this.noteFiliale =0;
              this.numofaxe += 0;
              this.critereService.listCritereDto.forEach(element => {
                this.numofaxe += 1;
                this.noteFiliale += element.noteAxe ;
                
              });
              console.log(this.numofaxe)
              this.noteFinalFiliale = this.noteFiliale / this.numofaxe
      
            }); });
          this.NoteCritereService.addNoteCritereForm.value.noteCritereId = ""
        }


      }
    })
  }
    this.note = e.target.value;
  
  }
  dateGrille(e: any) {
    this.critereService.GettNoteCritereByfilialByDate(this.fkfiliale, e.target.value).subscribe(res => {
      this.critereService.listCritereDto = (res as CritereDto[]);
      this.noteFiliale =0;
      this.numofaxe += 0;
      this.critereService.listCritereDto.forEach(element => {
        this.numofaxe += 1;
        this.noteFiliale += element.noteAxe ;
        
      });
      console.log(this.numofaxe)
      this.noteFinalFiliale = this.noteFiliale / this.numofaxe
      this.DateGrille = e.target.value;
      
    });
  }


  choix (e: any){
    window.location.reload()
    this.DateGrille = e.target.value;
  }

    GetAddedOrNot(){
     





    }

  

}  
