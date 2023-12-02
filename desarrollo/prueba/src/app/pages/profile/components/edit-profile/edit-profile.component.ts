import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InformationResponse } from 'src/app/models/account/information-response.model';
import { AccountService } from 'src/app/services/account.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { AccountListResponse } from 'src/app/models/helper/account-list-response.model';
import { Ubigeo } from 'src/app/models/common/ubigeo.model';
import { HelperService } from 'src/app/services/helper.service';
import Swal from 'sweetalert2';
import { RegisterRequest } from 'src/app/models/account/register-request.model';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

  @Input()
  Info: InformationResponse = new InformationResponse

  helper = HelperFunction;
  Lists: AccountListResponse = new AccountListResponse
  ListProvince: Ubigeo[] = []
  ListDistrict: Ubigeo[] = []

  editForm = new FormGroup({
    DocumentTypes: new FormControl('', [Validators.required]),
    DocumentNumber: new FormControl('', [Validators.required, Validators.minLength(8)]),
    Birthday: new FormControl('', [Validators.required]),
    LastName1: new FormControl('', [Validators.required]),
    LastName2: new FormControl('', [Validators.required]),
    FirstName1: new FormControl('', [Validators.required]),
    FirstName2: new FormControl('', [Validators.required]),
    Nationality: new FormControl('', [Validators.required]),
    Address: new FormControl('', [Validators.required]),
    ReferenceAddress: new FormControl('', [Validators.required]),
    Department: new FormControl('', [Validators.required]),
    Province: new FormControl('', [Validators.required]),
    District: new FormControl('', [Validators.required]),
    PersonalEmail: new FormControl('', [Validators.required, Validators.email]),
    PersonalCellPhone: new FormControl('', [Validators.required]),
    WorkEmail: new FormControl('', [Validators.required, Validators.email]),
    WorkCellPhone: new FormControl(''),
    Gender: new FormControl('', [Validators.required]),
    HasChildren: new FormControl(false, [])
  });

  constructor(
    private helperService: HelperService,
    private accountService: AccountService
  ) {

  }


  ngOnInit(): void {

    this.AccountLists()

  }

  LoadInfo() {

    this.editForm.patchValue({
      Department: this.Info.department
    })

    this.GetProvinces({ target: { value: this.Info.department } })
    this.GetDistricts({ target: { value: this.Info.province } })

    this.editForm.patchValue({
      DocumentTypes: this.Info.documentTypeId,
      DocumentNumber: this.Info.documentNumber,
      Birthday: this.Info.birthday.toString().split('T')[0],
      LastName1: this.Info.lastName1,
      LastName2: this.Info.lastName2,
      FirstName1: this.Info.firstName1,
      FirstName2: this.Info.firstName2,
      Nationality: this.Info.nationality,
      Gender: this.Info.gender,
      HasChildren: this.Info.hasChildren,
      Address: this.Info.address,
      ReferenceAddress: this.Info.referenceAddress,
      Province: this.Info.province,
      District: this.Info.district,
      PersonalEmail: this.Info.personalEmail,
      PersonalCellPhone: this.Info.personalCellPhone,
      WorkEmail: this.Info.workEmail,
      WorkCellPhone: this.Info.workCellPhone
    })

  }

  onSubmit() {

    if (!this.editForm.valid) {
      let controlNames = Object.keys(this.editForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.editForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor complete los datos!',
        showConfirmButton: false,
        timer: 3500
      })

      return

    }

    const formControls = this.editForm.controls

    let request: RegisterRequest = {
      firstName1: formControls.FirstName1.value ?? '',
      firstName2: formControls.FirstName2.value ?? '',
      lastName1: formControls.LastName1.value ?? '',
      lastName2: formControls.LastName2.value ?? '',
      documentTypeId: formControls.DocumentTypes.value ?? '',
      documentNumber: formControls.DocumentNumber.value ?? '',
      birthday: formControls.Birthday.value ?? '',
      personalEmail: formControls.PersonalEmail.value ?? '',
      workEmail: formControls.WorkEmail.value ?? '',
      personalCellPhone: formControls.PersonalCellPhone.value ?? '',
      workCellPhone: formControls.WorkCellPhone.value ?? '',
      gender: formControls.Gender.value ?? '',
      address: formControls.Address.value ?? '',
      referenceAddress: formControls.ReferenceAddress.value ?? '',
      district: formControls.District.value ?? '',
      province: formControls.Province.value ?? '',
      department: formControls.Department.value ?? '',
      nationality: formControls.Nationality.value ?? '',
      hasChildren: formControls.HasChildren.value === true
    }


    this.accountService.Register(request).subscribe(
      response => {
        if (response.success) {
          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Guardado!',
            showConfirmButton: false,
            timer: 3000
          })
        }

      }
    )

  }

  AccountLists(): void {

    this.helperService.AccountLists().subscribe(
      response => {
        this.Lists = response
        this.LoadInfo()

      }
    )

  }

  GetProvinces(event: any) {
    let selectedDepartment = event.target.value;

    this.helperService.Provinces(selectedDepartment).subscribe(
      response => {
        this.ListProvince = response

      }
    )

  }

  GetDistricts(event: any) {
    let selectedDepartment = this.editForm.controls.Department.value ?? '';
    let selectedProvince = event.target.value;

    if (selectedDepartment != '') {
      this.helperService.Districts(selectedDepartment, selectedProvince).subscribe(
        response => {
          this.ListDistrict = response
        }
      )
    }




  }


}
