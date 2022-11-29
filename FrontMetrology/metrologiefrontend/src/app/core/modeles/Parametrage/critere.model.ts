export class Critere {
    critereId : string;
    codeCritere : number;
    libelleCritere : string;
    axe : string;
    coefficient : number;
}

export class CritereNoteDto {
    critereId : string;
    codeCritere : number;
    libelleCritere : string;
    axe : string;
    coefficient : number;
    note:number;
    done:boolean
}

export class CritereDto{
    axe: string;
    critere:CritereNoteDto[];
    noteAxe:number;
}
