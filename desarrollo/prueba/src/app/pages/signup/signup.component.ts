import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbNavChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { RegisterRequest } from 'src/app/models/account/register-request.model';
import { UserResponse } from 'src/app/models/auth/user-response.model';
import { Ubigeo } from 'src/app/models/common/ubigeo.model';
import { AccountListResponse } from 'src/app/models/helper/account-list-response.model';
import { AccountService } from 'src/app/services/account.service';
import { HelperService } from 'src/app/services/helper.service';
import { UserService } from 'src/app/services/user.service';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import Swal from 'sweetalert2';
import JSConfetti from 'js-confetti'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['.././login/login.component.scss', './signup.component.scss']
})
export class SignupComponent implements OnInit {

  Lists: AccountListResponse = new AccountListResponse()
  ListProvince: Ubigeo[] = []
  ListDistrict: Ubigeo[] = []

  activeTab: number = 1;

  RegisterForm = new FormGroup({
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

  controlNamesFirstGroup: string[] = ['DocumentTypes', 'DocumentNumber', 'Birthday', 'LastName1', 'LastName2', 'FirstName1', 'FirstName2', 'Nationality', 'Gender'];
  controlNamesSecondGroup: string[] = ['Address', 'ReferenceAddress', 'Department', 'Province', 'District'];

  UserLoged: UserResponse = new UserResponse;

  constructor(
    private helperService: HelperService,
    private accountService: AccountService,
    private route: Router,
    private userService: UserService

  ) {


  }
  ngOnInit(): void {

    this.userService.user$.subscribe(user => {
      if (user) {
        this.UserLoged = user; // Asigna los datos del usuario al objeto
        this.RegisterForm.controls.WorkEmail.setValue(this.UserLoged.email)
        let familyName = this.UserLoged.familyName;
        let LastName1 = familyName ? familyName.split(' ')[0] : null
        let LastName2 = familyName ? familyName.split(' ')[1] : null
        let givenName = this.UserLoged.givenName;
        let FirstName1 = givenName ? givenName.split(' ')[0] : null
        let FirstName2 = givenName ? givenName.split(' ')[1] : null

        this.RegisterForm.controls.LastName1.setValue(LastName1)
        this.RegisterForm.controls.LastName2.setValue(LastName2)
        this.RegisterForm.controls.FirstName1.setValue(FirstName1)
        this.RegisterForm.controls.FirstName2.setValue(FirstName2)

        if (this.UserLoged.email.includes('@admin')) {
          this.route.navigate(['/welcome'])
        }

      }
    });

    this.AccountLists()
  }

  AccountLists(): void {

    this.helperService.AccountLists().subscribe(
      response => {
        this.Lists = response

      }
    )

  }

  onNavChange(changeEvent: NgbNavChangeEvent) {
    if (changeEvent.nextId > 3) {
      changeEvent.preventDefault();
    }
  }

  Next() {

    if (this.activeTab < 3) {
      let isValid: boolean = false

      if (this.activeTab == 1) {
        isValid = this.validateFirstGroup(this.controlNamesFirstGroup)
      }

      if (this.activeTab == 2) {
        isValid = this.validateFirstGroup(this.controlNamesSecondGroup)
      }

      if (isValid) {
        this.activeTab++
      }

    }

  }

  Last() {
    if (this.activeTab > 1) {
      this.activeTab--
    }

  }

  hasErrorControl(controlName: string) {
    const control = this.RegisterForm.get(controlName)
    return control?.touched && (control.hasError('required') || control.hasError('email') || control.hasError('minlength'))
  }

  validateFirstGroup(controlGroup: string[]) {
    let isValid: boolean = false

    controlGroup.forEach((controlName) => {
      const control = this.RegisterForm.get(controlName);
      if (control) {
        control.markAsTouched();
      }
    });

    if (controlGroup.every((controlName) => this.RegisterForm.get(controlName)?.valid)) {
      isValid = true
    }

    return isValid
  }

  async onSubmit() {
    try {

      if (!this.RegisterForm.valid) {
        let controlNames = Object.keys(this.RegisterForm.controls);
        HelperFunction.validateFirstGroup(controlNames, this.RegisterForm)

        Swal.fire({
          position: 'center',
          icon: 'warning',
          title: 'Por favor complete los datos!',
          showConfirmButton: false,
          timer: 3500
        })

        return
      }

      this.Register()

    } catch (error) {
      Swal.fire({
        position: 'center',
        icon: 'error',
        title: 'Ocurrio un error intentelo nuevamente!',
        showConfirmButton: false,
        timer: 3500
      })
    }
  }

  Register(): void {

    const formControls = this.RegisterForm.controls

    let person: RegisterRequest = {
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

    this.accountService.Register(person).subscribe(response => {
      if (response.success) {

        let user = this.userService.getUser()
        user.isRegistered = true
        user.personId = response.data.uid

        this.userService.setUser(user)

        let jsConfetti = new JSConfetti()

        jsConfetti.addConfetti({
          confettiColors: [
            '#00182a', '#7eb3dd', '#ff5001', '#75c9a6', '#d9eedf', '#eb4f87'
          ],
          confettiNumber: 500
        }).then(() => {
          jsConfetti.clearCanvas()
        })

        Swal.fire({
          position: 'center',
          icon: 'success',
          title: 'Bienvenido!',
          showConfirmButton: false,
          timer: 3000
        }).finally(() => {
          this.route.navigate(['/welcome'])
        })
      }
    })
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
    let selectedDepartment = this.RegisterForm.controls.Department.value ?? '';
    let selectedProvince = event.target.value;


    this.helperService.Districts(selectedDepartment, selectedProvince).subscribe(
      response => {
        this.ListDistrict = response
      }
    )

  }

}
