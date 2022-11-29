import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from 'src/app/core/service/user.service';
import { environment } from 'src/environments/environment';
import { PostUpdateUserComponent } from '../post-update-user/post-update-user.component';
import { UserForIdentityServer } from 'src/app/core/modeles/user';

@Component({
  selector: 'app-get-delete-user',
  templateUrl: './get-delete-user.component.html',
  styleUrls: ['./get-delete-user.component.css']
})
export class GetDeleteUserComponent implements OnInit {
  bsModalRef: any;
  data:string;
  current: number = 1;
  constructor(public userService: UserService, public modalService: BsModalService, 
    public SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.userService.GetListUserByApplicationId().subscribe(res => {
      console.log(res);
      
      this.userService.ListUserIdentityServer = (res as UserForIdentityServer[])
    })
  }
  openComponentForPost() {
    this.userService.Method = "Post";
    this.userService.initializeAddOrUpdateUserForm();
    this.bsModalRef = this.modalService.show(PostUpdateUserComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }
 async  onDelete(user: UserForIdentityServer) {
    if (confirm("Vous êtes sûr de vouloir supprimer")) {
      this.userService.deleteUserForm.controls.userId.setValue(user.userId);
      this.userService.deleteUserForm.controls.applicationId.setValue(environment.IdApplication);
      this.userService.deleteUserForm.controls.employeeId.setValue(user.userEmployeeId);
      this.SpinnerService.show();
      await this.userService.DeleteUserByApplication().toPromise().then(res => {
       this.userService.GetListUserByApplicationId().subscribe(res => {
          this.userService.ListUserIdentityServer = (res as UserForIdentityServer[])
          this.SpinnerService.hide();
          
        })
      },
      err => {
        console.log(err)
        this.SpinnerService.hide();
      }) 
      Swal.fire({
        icon: 'success',
        title: "La suppression est effectuée avec succées",
      })
      window.location.reload()
    }
  }
  openComponentForUpdate(user: UserForIdentityServer) {
   // debugger
   
   
    this.userService.Method = "Put"
    this.userService.User = user;
    this.userService.initializeAddOrUpdateUserFormForUpdate(user);
    this.bsModalRef = this.modalService.show(PostUpdateUserComponent, {
      class: 'modal-dialog-centered', ignoreBackdropClick: true, keyboard: false
    });
  }
}
