import { DomaineForPost } from "./domaine";

export class Prestataire {
    prestataireId:string ;
    matricule:string ;
    adresse:string ;
    telephone:string ;
    nomPrenom:string;
    typeAccredite:string
}

export class PrestataireDTO
{
    prestataireId:string ;
    matricule:string ;
    adresse:string ;
    telephone:string ;
    nomPrenom:string;
    listPresDomDto: DomaineForPost[];
    typeAccredite:string
}