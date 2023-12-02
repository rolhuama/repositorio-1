import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyService } from 'src/app/models/admin/company-service.model';
import { NgbModal, NgbModalConfig, NgbModalRef, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { startWith, map } from 'rxjs';
import { AdminService } from 'src/app/services/admin.service';
import { HelperService } from 'src/app/services/helper.service';
import Swal from 'sweetalert2';
import { Company } from 'src/app/models/admin/company.model';
import { CompanyInformationResponse } from 'src/app/models/admin/company-information-response.model';
import { ServiceType } from 'src/app/models/common/service-type.model';

@Component({
  selector: 'app-edit-company-services',
  standalone: true,
  imports: [CommonModule, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-company-services.component.html',
  styleUrls: ['./edit-company-services.component.scss']
})
export class EditCompanyServicesComponent implements OnInit {
  
  @Input()
  Info:CompanyInformationResponse=new CompanyInformationResponse

  EntityName: string = 'Servicio'

  filter = new FormControl('', { nonNullable: true })


  ListAll: CompanyService[] = []
  List: CompanyService[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' +this.EntityName

  helper = HelperFunction;
  private modalRef: NgbModalRef | undefined;

  registerForm = new FormGroup({
    id: new FormControl(0),
    code: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    typeId: new FormControl(0, [Validators.required]),
    costCenterCode:new FormControl(''),
  })

  typeList:ServiceType[]=[]

  constructor(
    private adminService: AdminService,
    private helperService: HelperService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ){
        // customize default values of modals used by this component tree
        config.backdrop = 'static'
        config.keyboard = false
  
    
        this.filter.valueChanges.pipe(
          startWith(''),
          map((text) => this.search(text))
        ).subscribe(filteredData => {
          this.List = filteredData;
          this.collectionSize = filteredData.length;
        })
  }


  ngOnInit(): void {

    this.LoadData()
    this.refreshList()
  }


  refreshList() {

    this.helperService.CompanyServicesList(this.Info.id).subscribe((response: CompanyService[]) => {
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

  LoadData():void{
    this.helperService.ServicesTypesList().subscribe(result => this.typeList=result)

  }

  search(text: string): CompanyService[] {
    return this.ListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.description.toLowerCase().includes(term) 
        // item.commercialName.toLowerCase().includes(term) ||
        // item.taxIdentificationNumber.toLowerCase().includes(term) 
        // pipe.transform(user.email).includes(term) ||
        // pipe.transform(user.roleName).includes(term)
      );
    });
  }

  openCreate(content: any) {
    this.RegisterFormTitle = 'Crear ' +this.EntityName
    this.isRegisterForm = true;

    this.registerForm.reset();

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  openEdit(content: any, item: CompanyService) {

    this.RegisterFormTitle = 'Editar ' +this.EntityName

    this.isRegisterForm = false;

    item.typeId = item.type?.id ?? 0
    item.costCenterCode = item.costCenter?.code ?? ''

    this.registerForm.patchValue(item);

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  onSubmit() {

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


    let request: CompanyService ={
      id: 0,
      code: this.registerForm.get('code')?.value ?? '',
      company: new Company,
      description: this.registerForm.get('description')?.value ?? '',
      type: null,
      typeId: this.registerForm.get('typeId')?.value ?? 0,
      companyId: this.Info.id,
      costCenter: null,
      costCenterCode: this.registerForm.get('costCenterCode')?.value ?? '',
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id =this.registerForm.get('id')?.value ?? 0
      this.Edit(request)
    }
  

  }

  Create(request: CompanyService){

    this.adminService.CreateCompanyService(request).subscribe(
      result=>{
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Cliente Creado!',
            showConfirmButton: false,
            timer: 2500
          }).finally(()=>{
            this.closeModal()
          })
           this.refreshList() 
          
        }else {

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

  Edit(request: CompanyService){

    this.adminService.EditCompanyService(request).subscribe(
      result=>{
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Cliente modificado!',
            showConfirmButton: false,
            timer: 2500
          }).finally(()=>{
            this.closeModal()
          })
           this.refreshList() 
          
        }else {

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
