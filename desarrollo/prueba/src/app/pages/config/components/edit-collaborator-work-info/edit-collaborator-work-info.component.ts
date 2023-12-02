import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InformationResponse } from 'src/app/models/account/information-response.model';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { WorkArea } from 'src/app/models/admin/work-area.model';
import { WorkAreaTeam } from 'src/app/models/admin/work-area-team.model';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { AdminService } from 'src/app/services/admin.service';
import { NgbTypeaheadModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { WorkInfo } from 'src/app/models/admin/work-info.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-collaborator-work-info',
  standalone: true,
  imports: [CommonModule,NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-collaborator-work-info.component.html',
  styleUrls: ['./edit-collaborator-work-info.component.scss']
})
export class EditCollaboratorWorkInfoComponent implements OnInit {
  @Input()
  Info:InformationResponse=new InformationResponse

  helper = HelperFunction;

  registerForm = new FormGroup({
    userId: new FormControl(''),
    position: new FormControl('', [Validators.required]),
    workAreaTeamId: new FormControl(-1, [Validators.required]),
    workAreaId:new FormControl(-1, [Validators.required]),

  })


  WorkAreaList: WorkArea[] = []
  WorkAreaTeamList: WorkAreaTeam[] = []
  WorkAreaTeamListAll: WorkAreaTeam[] = []

  page = 1;
  pageSize = 10;
  collectionSize = this.WorkAreaTeamList.length;
  rowInitIndex: number = 0

  filter = new FormControl('', { nonNullable: true })

  constructor(
    private adminService: AdminService,
  ){
    this.loadList()
  }


  ngOnInit(): void {
   
    
  }

  loadList(){
    this.adminService.WorkAreaList().subscribe(result=>{
      this.WorkAreaList=result

      this.loadData()
   
    })

  }

  refreshTeamList(selectItem:any):void {

    this.registerForm.get('workAreaTeamId')?.setValue(-1);

    this.LoadTeamList(selectItem.target.value)
  }

  LoadTeamList(workAreaId:number):void {

    this.adminService.WorkAreaTeamList().subscribe((response: WorkAreaTeam[]) => {


      response=response.filter(i=>i.workAreaId==workAreaId)

      this.WorkAreaTeamList = response;


    });
  }


  loadData(){
    this.adminService.WorkInfo(this.Info.collaboratorId).subscribe(result=>{
      this.registerForm.patchValue(result.data)

      this.LoadTeamList(result.data.workAreaId)

    })
  }

  

  onSubmit(){

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


    let request: WorkInfo={
      userId: this.Info.user.id,
      position: this.registerForm.controls.position.value ?? '',
      workAreaTeamId: this.registerForm.controls.workAreaTeamId.value ?? 0,
      workAreaId: this.registerForm.controls.workAreaId.value ?? 0
    }


    this.adminService.EditWorkInfo(request).subscribe(
      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Se ha modificado correctamente!',
            showConfirmButton: false,
            timer: 2500
          }).finally(() => {
           
          })
   

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



}
