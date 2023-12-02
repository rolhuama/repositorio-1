import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { InformationResponse } from 'src/app/models/account/information-response.model';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { NgbTypeaheadModule, NgbPaginationModule, NgbModal, NgbModalConfig, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AdminService } from 'src/app/services/admin.service';
import { HelperService } from 'src/app/services/helper.service';

import { CollaboratorCompanyListResponse } from 'src/app/models/admin/collaborator-company-list-response.model';
import { Company } from 'src/app/models/admin/company.model';
import Swal from 'sweetalert2';
import { AddCollaboratorCompanyRequest } from 'src/app/models/admin/add-collaborator-company-request.model';
import { CollaboratorCompany } from 'src/app/models/admin/collaborator-company.model';
import { EditCollaboratorCompanyRequest } from 'src/app/models/admin/edit-collaborator-company-request.model';

@Component({
  selector: 'app-edit-collaborator-company',
  standalone: true,
  imports: [CommonModule, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-collaborator-company.component.html',
  styleUrls: ['./edit-collaborator-company.component.scss']
})
export class EditCollaboratorCompanyComponent  implements OnInit {
  @Input()
  Info:InformationResponse=new InformationResponse


  EntityName: string = 'Servicio'

  filter = new FormControl('', { nonNullable: true })


  ListAll: CollaboratorCompanyListResponse[] = []
  List: CollaboratorCompanyListResponse[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' +this.EntityName

  helper = HelperFunction;

  companyList: Company[] = []
  registerForm = new FormGroup({

    companyId: new FormControl('', [Validators.required]),

  })

 companyForm = new FormGroup({
  
  companyId: new FormControl(0),
  clientPosition: new FormControl('', [Validators.required]),

  })

  private modalRef: NgbModalRef | undefined;

  constructor(
    private adminService: AdminService,
    private helperService: HelperService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ){

  
  }

  ngOnInit(): void {
    this.loadData()
    this.refreshList()
  }

  refreshList():void {

    this.adminService.CollaboratorCompanyList(this.Info.collaboratorId).subscribe((response: CollaboratorCompanyListResponse[]) => {
      this.List = response;
      this.ListAll = response;
      this.collectionSize = response.length;

      this.List = this.ListAll.map((item, i) => ({ index: i + 1, ...item })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize,
      );

      this.rowInitIndex = (this.page - 1) * this.pageSize + 1;

    });
  }

  loadData(){
    this.helperService.CompanyList().subscribe(result=>this.companyList=result)

  }

  onSubmit():void {
    
    if (!this.registerForm.valid) {
      let controlNames = Object.keys(this.registerForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.registerForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    let request: AddCollaboratorCompanyRequest={
      collaboratorId: this.Info.collaboratorId,
      companyId: parseInt((this.registerForm.get('companyId')?.value ?? 0).toString(), 10)
    }

    this.adminService.AddCollaboratorCompany(request).subscribe(
      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Se ha agregado correctamente!',
            showConfirmButton: false,
            timer: 2500
          }).finally(() => {
           
          })
          this.refreshList()

        } else {

          Swal.fire({
            position: 'center',
            icon: 'error',
            title: result.message,
            showConfirmButton: false,
            timer: 3500
          })

        }
      }
    )

    
  }

  Delete(item:CollaboratorCompany):void {

    Swal.fire({
      title: 'Seguro que desea eliminar?',
      text: "No podra revertir el cambio!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Sí, borrar!'
    }).then((result) => {
      if (result.isConfirmed) {

        this.adminService.DeleteCollaboratorCompany(item).subscribe(
          result => {
            if (result.success) {
    
              Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Se ha eliminado correctamente!',
                showConfirmButton: false,
                timer: 2500
              }).finally(() => {
               
              })
              this.refreshList()
    
            } else {
    
              Swal.fire({
                position: 'center',
                icon: 'error',
                title: result.message,
                showConfirmButton: false,
                timer: 3500
              })
    
            }
          }
        )

      }
    })



  }

  openEdit(content: any,item:CollaboratorCompanyListResponse){

    this.RegisterFormTitle = 'Editar datos de Colaborador' 

    this.isRegisterForm = false;

    this.companyForm.patchValue(item);

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });

  }

  onEditSave(){

    if (!this.companyForm.valid) {
      let controlNames = Object.keys(this.companyForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.companyForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }


    let request: EditCollaboratorCompanyRequest={
      collaboratorId: this.Info.collaboratorId,
      companyId: parseInt((this.companyForm.get('companyId')?.value ?? 0).toString(), 10),
      clientPosition: this.companyForm.get('clientPosition')?.value ?? ''
    }

    this.adminService.EditCollaboratorCompany(request).subscribe(
      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Se ha actualizado correctamente!',
            showConfirmButton: false,
            timer: 2500
          }).finally(() => {
           this.closeModal()
          })

          this.refreshList()

        } else {

          Swal.fire({
            position: 'center',
            icon: 'error',
            title: result.message,
            showConfirmButton: false,
            timer: 3500
          })

        }
      }
    )
    


  }

  closeModal() {
    if (this.modalRef) {
      this.modalRef.close();
    }
  }

}
