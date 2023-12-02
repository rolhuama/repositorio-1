import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { NgbTypeaheadModule, NgbPaginationModule, NgbModalRef, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { PeopleService } from 'src/app/services/people.service';
import Swal from 'sweetalert2';
import { ActivityType } from 'src/app/models/common/activity-type.model';
import { map, startWith } from 'rxjs';
import { Company } from 'src/app/models/admin/company.model';
import { HelperService } from 'src/app/services/helper.service';

@Component({
  selector: 'app-activity-type-config',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './activity-type-config.component.html',
  styleUrls: ['./activity-type-config.component.scss']
})
export class ActivityTypeConfigComponent implements OnInit {
  PageName: string = 'Configurar Tipos de Actividad Diaria'
  EntityName: string = 'Tipo Actividad Diaria'

  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'People',
      link: '',
      active: false
    },
    {
      name: this.PageName,
      link: '',
      active: true
    }
  ]

  filter = new FormControl('', { nonNullable: true })


  ListAll: ActivityType[] = []
  List: ActivityType[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' + this.EntityName

  helper = HelperFunction;
  private modalRef: NgbModalRef | undefined;

  actualYear: number = new Date().getFullYear()

  registerForm = new FormGroup({
    id: new FormControl(0),
    code: new FormControl('', [Validators.required, Validators.minLength(4)]),
    description: new FormControl('', [Validators.required, Validators.minLength(4)]),
    companyId: new FormControl(0, [Validators.required]),
  })

  companyList: Company[] = []


  constructor(
    config: NgbModalConfig,
    private modalService: NgbModal,
    private peopleService: PeopleService,
    private helperService: HelperService
  ) {
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
    this.helperService.CompanyList().subscribe(result => this.companyList = result)
    this.refreshList()
  }

  refreshList() {

    this.peopleService.ActivityTypeList().subscribe((response: ActivityType[]) => {
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

  search(text: string): ActivityType[] {
    return this.ListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.description.toLowerCase().includes(term)
        // item.commercialName.toLowerCase().includes(term) ||
        // item.taxIdentificationNumber.toLowerCase().includes(term) 

      );
    });
  }

  openCreate(content: any) {
    this.RegisterFormTitle = 'Crear ' + this.EntityName
    this.isRegisterForm = true;

    this.registerForm.reset();

    this.modalRef = this.modalService.open(content, { size: 'lg', animation: true, windowClass: 'fade' });
  }

  openEdit(content: any, item: ActivityType) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

    this.registerForm.reset();

    item.companyId = item.company?.id ?? 0
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


    let request: ActivityType = {
      id: 0,
      code: this.registerForm.get('code')?.value ?? '',
      description: this.registerForm.get('description')?.value ?? '',
      companyId: parseInt((this.registerForm.get('companyId')?.value ?? 0).toString(), 10),
      company: new Company
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id = this.registerForm.get('id')?.value ?? 0
      this.Edit(request)
    }

  }

  Create(request: ActivityType) {

    this.peopleService.CreateActivityType(request).subscribe(
      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Se ha Creado correctamente!',
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

  Edit(request: ActivityType) {

    this.peopleService.EditActivityType(request).subscribe(
      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Se ha modificado correctamente!',
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
