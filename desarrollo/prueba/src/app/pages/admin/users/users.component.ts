import { Component, OnInit, } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { NgbModal, NgbModalConfig, NgbModalRef, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { UserListResponse } from 'src/app/models/admin/user-list-response.model';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdminService } from 'src/app/services/admin.service';
import { map, startWith } from 'rxjs/operators';
import { BaseResponse } from 'src/app/models/common/interface/base-response.model';
import { Role } from 'src/app/models/admin/role.model';
import { CreateUserRequest } from 'src/app/models/admin/create-user-request.model';
import Swal from 'sweetalert2';
import { HelperFunction } from 'src/app/shared/functions/helper-function';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, RouterLink, BreadcrumbComponent, DecimalPipe, FormsModule, ReactiveFormsModule, NgbTypeaheadModule, NgbPaginationModule],
  providers: [DecimalPipe],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  PageName: string = 'Configurar Usuarios'

  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Admistracion',
      link: '',
      active: false
    },
    {
      name: 'Usuarios',
      link: '',
      active: true
    }
  ]

  filter = new FormControl('', { nonNullable: true })

  UserList: UserListResponse[] = []
  UserListAll: UserListResponse[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.UserList.length;

  RoleList: Role[] = []
  selectedUser: UserListResponse = new UserListResponse

  userForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    roles: new FormControl('', [Validators.required]),
    active: new FormControl(false)
  })

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar Usuario'
  rowInitIndex:number =0

  helper= HelperFunction;
  private modalRef: NgbModalRef | undefined;

  constructor(
    private adminService: AdminService,
    pipe: DecimalPipe,
    config: NgbModalConfig,
    private modalService: NgbModal
  ) {

    // customize default values of modals used by this component tree
    config.backdrop = 'static'
    config.keyboard = false

    this.refreshList()

    this.filter.valueChanges.pipe(
      startWith(''),
      map((text) => this.search(text))
    ).subscribe(filteredData => {
      this.UserList = filteredData;
      this.collectionSize = filteredData.length;
    })
  }

  ngOnInit(): void {

    this.adminService.RoleList().subscribe(
      response => this.RoleList = response
    )
  }


  refreshList() {

    this.adminService.UserList().subscribe((response: BaseResponse<UserListResponse[]>) => {
      this.UserList = response.data;
      this.UserListAll = response.data;
      this.collectionSize = response.data.length;

      this.UserList = this.UserListAll.map((user, i) => ({ id: i + 1, ...user })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize,
      );

      this.rowInitIndex = (this.page - 1) * this.pageSize + 1;

    });
  }

  search(text: string): UserListResponse[] {
    return this.UserListAll.filter((user) => {
      const term = text.toLowerCase();
      return (
        user.userName.toLowerCase().includes(term)
        // pipe.transform(user.email).includes(term) ||
        // pipe.transform(user.roleName).includes(term)
      );
    });
  }

  openCreate(content: any) {
    this.RegisterFormTitle = 'Crear usuario'
    this.isRegisterForm = true;

    this.userForm.patchValue({
      userName: "",
      email: "",
      active: true
    });

    this.modalRef =  this.modalService.open(content, { size: 'lg' , animation: true, windowClass: 'fade'});
  }

  openEdit(content: any, user: UserListResponse) {

    this.RegisterFormTitle = 'Editar usuario'

    this.isRegisterForm = false;

    this.userForm.patchValue({
      userName: user.userName,
      email: user.email,
      roles:user.roleId,
      active: !user.lockoutEnabled
    });

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  changeEmail() {

    const emailValue = this.userForm.get('email')?.value
    this.userForm.patchValue({ userName: emailValue })

  }


  onSubmit() {

    let controlNames = Object.keys(this.userForm.controls);
    HelperFunction.validateFirstGroup(controlNames,this.userForm)

    if (!this.userForm.valid) {      
      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    const isActive = this.userForm.get('active')?.value === true;

    let request: CreateUserRequest = {
      userName: this.userForm.get('email')?.value ?? '',
      email: this.userForm.get('email')?.value ?? '',
      roleId: this.userForm.get('roles')?.value ?? '',
      lockoutEnabled: !isActive
    }

    if (this.isRegisterForm) {
      this.RegisterUser(request)
    }
    else {
      this.EditUser(request)
    }

  }

  RegisterUser(request: CreateUserRequest) {

    this.adminService.CreateUser(request).subscribe(
      response => {

        if (response.data.id) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Usuario Creado!',
            showConfirmButton: false,
            timer: 2500
          }).finally(()=>{
            this.closeModal()
          })

        } else {

          Swal.fire({
            position: 'center',
            icon: 'error',
            title: response.message,
            showConfirmButton: false,
            timer: 3500
          })

        }

        this.refreshList()

      }
    )

  }

  EditUser(request: CreateUserRequest) {

    this.adminService.EditUser(request).subscribe(
      response => {

        if (response.data.id) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Usuario Modificado!',
            showConfirmButton: false,
            timer: 2500
          }).finally(()=>{
            this.closeModal()
          })

        } else {

          Swal.fire({
            position: 'center',
            icon: 'error',
            title: response.message,
            showConfirmButton: false,
            timer: 3500
          })

        }

        this.refreshList()

      }
    )

  }

  closeModal() {
    if (this.modalRef) {
      this.modalRef.close();
    }
  }



}
