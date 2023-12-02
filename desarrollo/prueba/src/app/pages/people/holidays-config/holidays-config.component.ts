import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { NgbModal, NgbModalConfig, NgbModalRef, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { Holiday } from 'src/app/models/activity/holiday.model';
import { HelperService } from 'src/app/services/helper.service';
import { PeopleService } from 'src/app/services/people.service';
import { map, startWith } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-holidays-config',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './holidays-config.component.html',
  styleUrls: ['./holidays-config.component.scss']
})
export class HolidaysConfigComponent implements OnInit {

  PageName: string = 'Configurar Feriados'
  EntityName: string = 'Feriado'

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


  ListAll: Holiday[] = []
  List: Holiday[] = []
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
    year: new FormControl(this.actualYear, [Validators.required, Validators.min(this.actualYear)]),
    description: new FormControl('', [Validators.required, Validators.minLength(4)]),
    startDate: new FormControl('', [Validators.required]),
    endDate: new FormControl('', [Validators.required]),
    // days: new FormControl(0, [Validators.required])
  })


  constructor(
    private helperService: HelperService,
    config: NgbModalConfig,
    private modalService: NgbModal,
    private peopleService: PeopleService
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
    this.refreshList()
  }

  refreshList() {

    this.peopleService.HolidayList().subscribe((response: Holiday[]) => {
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

  search(text: string): Holiday[] {
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

  openEdit(content: any, item: Holiday) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

    this.registerForm.patchValue(item);

    this.registerForm.patchValue({
      startDate: item.startDate.toString().split('T')[0],
      endDate: item.endDate.toString().split('T')[0]
    })


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


    let request: Holiday = {
      id: 0,
      year: this.registerForm.get('year')?.value ?? this.actualYear,
      description: this.registerForm.get('description')?.value ?? '',
      startDate: this.registerForm.get('startDate')?.value ?? '',
      endDate: this.registerForm.get('endDate')?.value ?? '',
      days: 0
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id = this.registerForm.get('id')?.value ?? 0
      this.Edit(request)
    }

  }

  Create(request: Holiday) {

    this.peopleService.CreateHoliday(request).subscribe(
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

  Edit(request: Holiday) {

    this.peopleService.EditHoliday(request).subscribe(
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
