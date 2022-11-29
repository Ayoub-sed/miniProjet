import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Role, User, UserForIdentityServer, UserForRoleAssign } from '../modeles/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  Method: string;
  ListUserIdentityServer: UserForIdentityServer[]
  ListRole: Role[];
  User = new UserForIdentityServer;
  listUser: User[] = new Array
  UserForRoleAssign = new UserForRoleAssign;

  AddOrUpdateUserForm = this.fb.group({
    userId: [''],
    userFullName: [''],
    roleId: ['', Validators.required],
    roleName: [''],
    userEmployeeId: ['']
  })

  deleteUserForm = this.fb.group({
    userId: [''],
    applicationId: [''],
    employeeId: ['']
  })


  constructor(public http: HttpClient, private fb: FormBuilder) { }


  SearchUserWithKeyWord(searchKey: string) {
    return this.http.get(environment.UserMicroservice + "/User/SerachUserWithKeyWord?searchKey=" + searchKey);
  }
  SearchSupplierWithKeyWord(searchKey: string) {
    return this.http.get(environment.SupplierMicroservice + "/Supplier/SerachSupplier?searchKey=" + searchKey);
  }

  GetListUserByApplicationId() {
    return this.http.get(environment.IdentityServer + "/Users/GetAllByApplication/" + environment.IdApplication)
  }

  GetRoleByApplicationId() {
    return this.http.get(environment.IdentityServer + "/Roles/RoleByApplicationID?id=" + environment.IdApplication)
  }

  PostUser() {
    return this.http.post(environment.IdentityServer + "/Users", this.User, { 'responseType': 'text' })
  }

  initializeAddOrUpdateUserForm() {
    this.AddOrUpdateUserForm.setValue({
      userId: null,
      userFullName: '',
      roleId: '',
      roleName: '',
      userEmployeeId: ''
    });
  }

  initializeAddOrUpdateUserFormForUpdate(user: UserForIdentityServer) {
    //debugger
    this.AddOrUpdateUserForm.setValue({
      userId: user.userId,
      userFullName: user.userFullName,
      roleId: user.userApplicationRoles.length?user.userApplicationRoles[0].roleId:"0000",
      roleName: user.userApplicationRoles.length?user.userApplicationRoles[0].roleName:"No Role",
      userEmployeeId: user.userEmployeeId?user.userEmployeeId:""
    });
  }

  DeleteUserByApplication() {
   
    
    
    var header = {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }
    return this.http.post(environment.IdentityServer + "/Users/DeleteUserFromApp", this.deleteUserForm.value, header)
  }

  UpdateUserOneRolePermitted() {
    var header = {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
    }
    return this.http.put(environment.IdentityServer + "/Users/UpdateUserOneRolePermitted", this.User, header)
  }

  PostUserApplicationRoleAssign() {
    return this.http.post(environment.IdentityServer + "/Users/UserApplicationRoleAssign", this.UserForRoleAssign)
  }
}