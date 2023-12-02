import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { WorkArea } from 'src/app/models/admin/work-area.model';
import { FormsModule, ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbTypeaheadModule, NgbPaginationModule, NgbModalRef, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { startWith, map } from 'rxjs';
import { AdminService } from 'src/app/services/admin.service';
import Swal from 'sweetalert2';
import { WorkAreaTeam } from 'src/app/models/admin/work-area-team.model';

@Component({
  selector: 'app-work-areas',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './work-areas.component.html',
  styleUrls: ['./work-areas.component.scss']
})
export class WorkAreasComponent {

  PageName: string = 'Configurar Áreas de Trabajo'
  EntityName: string = 'Área de Trabajo'

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


  ListAll: WorkArea[] = []
  List: WorkArea[] = []
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
    name: new FormControl('', [Validators.required]),

  })

  registerTeamForm = new FormGroup({
    id: new FormControl(0),
    workAreaId: new FormControl(0),
    code: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),

  })



  WorkAreaTeamList: WorkAreaTeam[] = []
  WorkAreaTeamListAll: WorkAreaTeam[] = []

  pageTeam = 1;
  pageTeamSize = 10;
  collectionTeamSize = this.WorkAreaTeamList.length;
  rowTeamInitIndex: number = 0

  filterTeam = new FormControl('', { nonNullable: true })

  constructor(
    private adminService: AdminService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ){

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

  refreshList() {

    this.adminService.WorkAreaList().subscribe((response: WorkArea[]) => {
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

  refreshTeamList():void {

    this.adminService.WorkAreaTeamList().subscribe((response: WorkAreaTeam[]) => {

      let areaId=this.registerForm.get('id')?.value ?? 0

      response=response.filter(i=>i.workAreaId==areaId)

      this.WorkAreaTeamList = response;
      this.WorkAreaTeamListAll = response;
      this.collectionTeamSize = response.length;

      this.WorkAreaTeamList = this.WorkAreaTeamListAll.map((item, i) => ({ index: i + 1, ...item })).slice(
        (this.pageTeam - 1) * this.pageTeamSize,
        (this.pageTeam - 1) * this.pageTeamSize + this.pageTeamSize,
      );

      this.rowTeamInitIndex = (this.pageTeam - 1) * this.pageTeamSize + 1;

    });
  }

  search(text: string): WorkArea[] {
    return this.ListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.name.toLowerCase().includes(term) 
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

  openEdit(content: any, item: WorkArea) {

    this.RegisterFormTitle = 'Editar ' + this.EntityName

    this.isRegisterForm = false;

    this.registerForm.patchValue(item);

    this.refreshTeamList()

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

    let request: WorkArea ={
      id: 0,
      code: this.registerForm.get('code')?.value ?? '',
      name: this.registerForm.get('name')?.value ?? '',
      teams: []
    }


    if (this.isRegisterForm) {
      this.Create(request)
    }
    else {
      request.id =this.registerForm.get('id')?.value ?? 0
      this.Edit(request)
    }
  

  }

  Create(request: WorkArea){

    this.adminService.CreateWorkArea(request).subscribe(
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

  Edit(request: WorkArea){

    this.adminService.EditWorkArea(request).subscribe(
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


  AddTeam(){

    if (!this.registerTeamForm.valid) {
      let controlNames = Object.keys(this.registerTeamForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.registerTeamForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    let request: WorkAreaTeam ={
      id: 0,
      code: this.registerTeamForm.get('code')?.value ?? '',
      name: this.registerTeamForm.get('name')?.value ?? '',
      workAreaId:this.registerForm.get('id')?.value ?? 0
    }


    this.adminService.CreateWorkAreaTeam(request).subscribe(
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



  DeleteTeam(item:WorkAreaTeam){

    if (!this.registerTeamForm.valid) {
      let controlNames = Object.keys(this.registerTeamForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.registerTeamForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }


    this.adminService.DeleteWorkAreaTeam(item).subscribe(
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



}
