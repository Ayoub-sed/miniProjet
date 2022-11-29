export class Equipement {

    equipementId: string;
    identifiantInterne: string;
    numeroSerie:number;
    marque: string;
    type: string;
    libelle: string;
    typeEquipement: string;
    temperature: number ;
    dateEtalonnage: Date;
    dateVerification: Date;
    porteMax: number ; 
    porteMin: number ;
    echellonDeVerification: number ;
    numApprobation: number ;  
    numVignette: number ;
    datePoinconnage: Date; 
    pressionMesuree:number;
    dateReparation: Date;
    nombreCapteurs: number;
    fkFiliale: string;
}
export class EquipementDto{
    libelle: string;
    equipement:Equipement[];
 
}