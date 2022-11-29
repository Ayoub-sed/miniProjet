import { AxeInterventionEnum } from "./AxeInterventionEnum";

export class FraisIntervention {
    fraisInterventionId : string;
    fkFiliale : string;
    dateIntervention : Date;
    frais : number;
    libelleIntervention: string;
    typeIntervention : AxeInterventionEnum;
    fkEquipement: string;
    fkPrestataire: string;
}

export class FraisInterventionDto{
    typeIntervention: AxeInterventionEnum;
    sommeFrais: number;
    fraisIntervention:FraisIntervention[];
}