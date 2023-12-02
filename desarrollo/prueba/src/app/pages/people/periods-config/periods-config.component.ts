import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbTypeaheadModule, NgbPaginationModule, NgbModalRef, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import Swal from 'sweetalert2';
import { PeopleService } from 'src/app/services/people.service';
import { map, startWith } from 'rxjs';
import { Period } from 'src/app/models/activity/period.model';
import { Month } from 'src/app/models/common/month.model';
import { HelperService } from 'src/app/services/helper.service';
import { MasterDetailTable } from 'src/app/models/common/master-detail-table.model';

@Component({
  selector: 'app-periods-config',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './periods-config.component.html',
  styleUrls: ['./periods-config.component.scss']
})
export class PeriodsConfigComponent implements OnInit {

  PageName: string = 'Configurar Periodos'
  EntityName: string = 'Periodo'

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


  ListAll: Period[] = []
  List: Period[] = []
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
    id: new FormControl(''),
    year: new FormControl(this.actualYear, [Validators.required, Validators.min(this.actualYear)]),
    month: new FormControl(0, [Validators.required]),
    description: new FormControl('', [Validators.required, Validators.minLength(4)]),
    state: new FormControl('', [Validators.required]),
    maximumHours: new FormControl(),
    // startDate: new FormControl('', [Validators.required]),
    // endDate: new FormControl('', [Validators.required])
  })

  monthList: Month[] = []
  stateList: MasterDetailTable[] = []

  constructor(
    config: NgbModalConfig,
    private modalService: NgbModal,
    private peopleService: PeopleService,
    private helperService:HelperService
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

    this.LoadLists()
    this.refreshList()
  
  }

  LoadLists() {
    this.monthList = HelperFunction.GetMonths()
    this.helperService.MasterTableList("Periods","States").subscribe(
      result=> this.stateList= result
    )
  }

  refreshList() {

    this.peopleService.PeriodList().subscribe((response: Period[]) => {
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

  search(text: string): Period[] {
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

  openEdit(content: any, item: Period) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

    this.registerForm.patchValue(item);

    // this.registerForm.patchValue({
    //   startDate: item.startDate.toString().split('T')[0],
    //   endDate: item.endDate.toString().split('T')[0]
    // })


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


    let request: Period = {
      id: '',
      year: this.registerForm.get('year')?.value ?? this.actualYear,
      month: parseInt((this.registerForm.get('month')?.value ?? 0).toString(), 10),
      description: this.registerForm.get('description')?.value ?? '',
      state: this.registerForm.get('state')?.value ?? '',
      startDate: this.registerForm.get('startDate')?.value ?? '',
      endDate: this.registerForm.get('endDate')?.value ?? '',
      stateMasterTable: null,
      maximumHours: this.registerForm.get('maximumHours')?.value ?? 0
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id = this.registerForm.get('id')?.value ?? ''
      this.Edit(request)
    }

  }

  Create(request: Period) {

    this.peopleService.CreatePeriod(request).subscribe(
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

  Edit(request: Period) {

    this.peopleService.EditPeriod(request).subscribe(
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
