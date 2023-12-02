import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbModalRef, NgbModalConfig, NgbModal, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { startWith, map } from 'rxjs';
import { CostCenter } from 'src/app/models/admin/cost-center.model';
import { AdminService } from 'src/app/services/admin.service';
import { HelperService } from 'src/app/services/helper.service';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import Swal from 'sweetalert2';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';

@Component({
  selector: 'app-ceco',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './ceco.component.html',
  styleUrls: ['./ceco.component.scss']
})
export class CecoComponent implements OnInit {
  PageName: string = 'Configurar CECO'
  EntityName: string = 'Centro de Costo'

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


  ListAll: CostCenter[] = []
  List: CostCenter[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' + this.EntityName

  helper = HelperFunction;
  private modalRef: NgbModalRef | undefined;

  registerForm = new FormGroup({
    id: new FormControl(0),
    code: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),

  })

  // countryList: Country[] = []

  constructor(
    private adminService: AdminService,
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


  }

  refreshList() {

    this.adminService.CostCenterList().subscribe((response: CostCenter[]) => {
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

  search(text: string): CostCenter[] {
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
    this.RegisterFormTitle = 'Crear ' + this.EntityName
    this.isRegisterForm = true;

    this.registerForm.reset();

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  openEdit(content: any, item: CostCenter) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

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

    // const isActive = this.registerForm.get('isActive')?.value === true;

    let request: CostCenter ={
      id: 0,
      code: this.registerForm.get('code')?.value ?? '',
      description: this.registerForm.get('description')?.value ?? '',
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id =this.registerForm.get('id')?.value ?? 0
      this.Edit(request)
    }
  

  }

  Create(request: CostCenter){

    this.adminService.CreateCostCenter(request).subscribe(
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

  Edit(request: CostCenter){

    this.adminService.EditCostCenter(request).subscribe(
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
