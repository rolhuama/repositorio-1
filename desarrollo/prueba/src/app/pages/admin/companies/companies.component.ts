import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { NgbModal, NgbModalConfig, NgbModalRef, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { map, startWith } from 'rxjs';
import { AdminService } from 'src/app/services/admin.service';
import { Company } from 'src/app/models/admin/company.model';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import Swal from 'sweetalert2';
import { Country } from 'src/app/models/common/country.model';
import { HelperService } from 'src/app/services/helper.service';
import { CompanyRequest } from 'src/app/models/admin/company-request.model';

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss']
})
export class CompaniesComponent  implements OnInit {
  PageName: string = 'Configurar Clientes'
  EntityName: string = 'Cliente'

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
      name: this.EntityName,
      link: '',
      active: true
    }
  ]

  filter = new FormControl('', { nonNullable: true })


  ListAll: Company[] = []
  List: Company[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' + this.EntityName

  helper = HelperFunction;
  private modalRef: NgbModalRef | undefined;

  companyForm = new FormGroup({
    id: new FormControl(0),
    legalName: new FormControl('', [Validators.required]),
    commercialName: new FormControl('', [Validators.required]),
    fiscalAddress: new FormControl('', [Validators.required]),
    taxIdentificationNumber: new FormControl('', [Validators.required]),
    economicSector: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required]),
    costCenterCode: new FormControl(''),
    isActive: new FormControl(false)
  })

  countryList: Country[] = []

  constructor(
    private adminService: AdminService,
    private helperService: HelperService,
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
      this.List = filteredData;
      this.collectionSize = filteredData.length;
    })
  }

  ngOnInit(): void {

    this.helperService.Countries().subscribe(
      response => this.countryList = response
    )
  }

  refreshList() {

    this.adminService.CompanyList().subscribe((response: Company[]) => {
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

  search(text: string): Company[] {
    return this.ListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.legalName.toLowerCase().includes(term) ||
        item.commercialName.toLowerCase().includes(term) ||
        item.taxIdentificationNumber.toLowerCase().includes(term) 
        // pipe.transform(user.email).includes(term) ||
        // pipe.transform(user.roleName).includes(term)
      );
    });
  }

  openCreate(content: any) {
    this.RegisterFormTitle = 'Crear ' + this.EntityName
    this.isRegisterForm = true;

    this.companyForm.reset();

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  openEdit(content: any, item: Company) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

    this.companyForm.patchValue(item);

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  onSubmit() {

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

    const isActive = this.companyForm.get('isActive')?.value === true;

    let request: CompanyRequest ={
      id: 0,
      legalName: this.companyForm.get('legalName')?.value ?? '',
      commercialName: this.companyForm.get('commercialName')?.value ?? '',
      fiscalAddress: this.companyForm.get('fiscalAddress')?.value ?? '',
      taxIdentificationNumber: this.companyForm.get('taxIdentificationNumber')?.value ?? '',
      economicSector: this.companyForm.get('economicSector')?.value ?? '',
      country: this.companyForm.get('country')?.value ?? '',
      costCenterCode: this.companyForm.get('costCenterCode')?.value ?? '',
      isActive: isActive,
      isInterCompany: false,
      costCenter: null
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id =this.companyForm.get('id')?.value ?? 0
      this.Edit(request)
    }
  

  }

  Create(request: CompanyRequest){

    this.adminService.CreateCompany(request).subscribe(
      result=>{
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Creado!',
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

  Edit(request: CompanyRequest){

    this.adminService.EditCompany(request).subscribe(
      result=>{
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Modificado!',
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
