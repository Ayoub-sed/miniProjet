export class Domaine {
    domaineId : string;
    libelleDomaine : string;
}

export class DomaineForPost {
    prestataireDomaineId:string;
    domaineId : string;
    fkDomaine :string;
    fkPrestataire:string;
    libelleDomaine : string;
    accredite : boolean;
    agree : boolean;
}




