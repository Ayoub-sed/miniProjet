export class User {
    userID : string;
    nom: string;
    prenom: string;
    fullName : string;
    matricule: number;
    lotusAdress: string;
    addDate : Date
    isActive : boolean
    fK_Unit: string;
    fK_Subsidiary: string;
    subsidiaryCode : string;
    numGsm : string;
    numPersonnel : string ;
    numPoste : string;
    subsidiaryLabel : string;
}


export class UserForIdentityServer{
    applicationId: number;
    userId: string;
    userUserName: string;
    applicationName: string;
    userEmployeeId: string;
    userFullName: string;
    userEmail: string;
    userPassword: string;
    userSubsidiaryCode: string;
    userIsEnabled: boolean;
    userApplicationRoles : userApplicationRoles[] = new Array
}


export class userApplicationRoles {
    roleId : string
    roleName : string;
}


export class Role {
    id : string;
    name : string;
}

export class UserForRoleAssign{
    applicationId : number
    userEmployeeId : string;
    userApplicationRoles : userApplicationRoles[] = new Array;
}






