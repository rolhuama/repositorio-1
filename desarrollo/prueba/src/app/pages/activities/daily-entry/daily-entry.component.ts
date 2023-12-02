import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { AccountService } from 'src/app/services/account.service';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { CollaboratorCompanyListResponse } from 'src/app/models/admin/collaborator-company-list-response.model';
import { UserService } from 'src/app/services/user.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HelperService } from 'src/app/services/helper.service';
import { ActivityType } from 'src/app/models/common/activity-type.model';
import { PeriodWeekResponse } from 'src/app/models/activity/period-week-response.model';
import { CompanyService } from 'src/app/models/admin/company-service.model';
import Swal from 'sweetalert2';
import { Activity } from 'src/app/models/activity/activity.model';
import { ActivityDetail } from 'src/app/models/activity/activity-detail.model';
import { DailyActivityRequest } from 'src/app/models/activity/daily-activity-request.model';
import { UserResponse } from 'src/app/models/auth/user-response.model';
import { DailyActivityListRequest } from 'src/app/models/activity/daily-activity-list-request.model';

@Component({
  selector: 'app-daily-entry',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './daily-entry.component.html',
  styleUrls: ['./daily-entry.component.scss']
})
export class DailyEntryComponent implements OnInit {

  PageName: string = 'Registro Diario'
  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Actividades',
      link: '',
      active: false
    },
    {
      name: this.PageName,
      link: '',
      active: true
    }
  ]

  helper = HelperFunction;

  companyList: CollaboratorCompanyListResponse[] = []

  addActivityForm = new FormGroup({
    companyId: new FormControl(-1, [Validators.required, Validators.min(0)]),
    weekNumber: new FormControl(-1, [Validators.required, Validators.min(0)]),

  })

  activityForm = new FormGroup({})

  activityList: Activity[] = [];
  activityTypeList: ActivityType[] = [];
  companyServiceList: CompanyService[] = [];

  weeksInMonthList: PeriodWeekResponse[] = []
  dayList: any[] = [
    {
      id: 'Lun',
      name: 'Lun',
      hours: 0,
      day: 0,
      month: 0
    },
    {
      id: 'Mar',
      name: 'Mar',
      hours: 0,
      day: 0,
      month: 0
    },
    {
      id: 'Mie',
      name: 'Mie',
      hours: 0,
      day: 0,
      month: 0
    },
    {
      id: 'Jue',
      name: 'Jue',
      hours: 0,
      day: 0,
      month: 0
    },
    {
      id: 'Vie',
      name: 'Vie',
      hours: 0,
      day: 0,
      month: 0
    },
    {
      id: 'Sab',
      name: 'Sab',
      hours: 0,
      month: 0
    },
    {
      id: 'Dom',
      name: 'Dom',
      hours: 0,
      day: 0,
      month: 0
    }
  ]

  actualWeek: PeriodWeekResponse = new PeriodWeekResponse
  hoursTotal: number = 0

  user: UserResponse = new UserResponse

  errors: string[] = []

  constructor(
    private accountService: AccountService,
    private userService: UserService,
    private helperService: HelperService
  ) {



  }

  ngOnInit(): void {
    this.LoadLists()
    this.LoadWeeks()
  }

  LoadLists() {

    this.user = this.userService.getUser()

    this.accountService.CollaboratorCompanyList(this.user.personId).subscribe(result => this.companyList = result)
  }

  LoadWeeks() {

    this.helperService.PeriodWeekList().subscribe(result => {
      this.weeksInMonthList = result
    })
  }

  AddActivity() {

    if (!this.addActivityForm.valid) {
      let controlNames = Object.keys(this.addActivityForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.addActivityForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }



    let newActivity = new Activity

    newActivity.id = this.activityList.length
    newActivity.activityType.id = -1
    newActivity.companyService.id = -1
    newActivity.week = this.actualWeek.weekNumber

    this.dayList.forEach(element => {

      let newDay = new ActivityDetail
      newDay.dayName = element.id
      newDay.week = this.actualWeek.weekNumber
      newDay.day = element.day
      newDay.month = element.month
      newActivity.detail.push(newDay)

    });

    this.activityList.push(newActivity)

    this.activityList.forEach((item, index) => {
      item.order = index + 1;
    });


    // this.cd.detectChanges()
    console.log(this.activityList)

  }

  DeleteActivity(index: number) {

    this.activityList.splice(index, 1);

  }


  CompanyChange(event: any) {
    let selectItem = event.target.value

    this.helperService.CompanyActivityTypeList(selectItem).subscribe(result => this.activityTypeList = result)

    this.helperService.CompanyServicesList(selectItem).subscribe(result => this.companyServiceList = result)

  }

  WeekChange(event: any) {
    let selectItem = event.target.value

    if (selectItem > -1) {
      let week = this.weeksInMonthList.filter(i => i.weekNumber == selectItem)[0]
      let currentDay = new Date(week.startDate)

      this.dayList.forEach(day => {

        // Obtenemos el día y el mes en formato dd/mm
        const formattedDate = (currentDay?.getDate() < 10 ? '0' : '') + currentDay?.getDate() + '/' +
          ((currentDay?.getMonth() + 1) < 10 ? '0' : '') + (currentDay?.getMonth() + 1);

        day.name = day.id + ' ' + formattedDate
        day.day = formattedDate.split('/').at(0)
        day.month = formattedDate.split('/').at(1)
        // Aumenta un día
        currentDay.setDate(currentDay.getDate() + 1);

      });

      this.actualWeek = week

      let request: DailyActivityListRequest = {
        userId: this.user.id,
        companyId: this.addActivityForm.get('companyId')?.value ?? 0,
        week: this.actualWeek.weekNumber
      }

      this.accountService.DailyActivityList(request).subscribe(result => {
        this.activityList = result.data.activities

        this.DaysSumTotal()
      })
    }


  }

  getDayDetail(item: Activity, dayName: string) {
    // Filtra el array para encontrar el elemento correspondiente al día
    return item.detail.find((detail: ActivityDetail) => detail.dayName === dayName) ?? new ActivityDetail;
  }

  SumTotal(item: Activity) {

    // Usamos reduce para sumar las horas de todos los detalles
    const totalHours = item.detail
      .map((detail) => detail.hours) // Obtén un array de todas las horas
      .reduce((total, hours) => (hours !== undefined ? total + hours : total), 0)

    // Asignamos la suma total a la propiedad durationHours del objeto item
    item.durationHours = totalHours;

    this.hoursTotal = 0

    this.DaysSumTotal()

    // console.log(this.dayList)

  }

  DaysSumTotal() {

    this.dayList.forEach(day => {

      day.hours = this.activityList
        .map(activity => activity.detail.find(detail => detail.dayName === day.id))
        .filter(foundDetail => foundDetail !== undefined)
        .map(foundDetail => foundDetail!.hours) // Usamos el operador '!' para indicar que no será 'undefined'
        .reduce((total, hours) => (hours !== undefined ? total + hours : total), 0);

      this.hoursTotal += day.hours

    })
  }

  onSubmit() {

    if (!this.addActivityForm.valid) {
      let controlNames = Object.keys(this.addActivityForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.addActivityForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }


    if (!this.IsValidData()) {
      const errorMessages = this.errors.map(error => `- ${error}`).join('<br>');

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor revise, hay datos incorrectos.',
        html: errorMessages,
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    let request: DailyActivityRequest = new DailyActivityRequest

    request.userId = this.user.id
    request.companyId = this.addActivityForm.get('companyId')?.value ?? 0
    request.period.year = this.actualWeek.year
    request.period.month = this.actualWeek.month
    request.weekNumber = this.actualWeek.weekNumber

    request.activities = this.activityList


    this.accountService.RegisterDailyActivity(request).subscribe(

      result => {
        if (result.success) {

          Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Guardado correctamente!',
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

  IsValidData() {

    let isValid = false

    this.errors = []

    if (this.hoursTotal == 0) {
      this.errors.push("Debe ingresar horas.")
    }

    if (this.hoursTotal < 0 && this.hoursTotal > 48) {
      this.errors.push("El total de horas debe estar entre 0 y 48.")
    }

    let invalitList = this.activityList.filter(i => i.description == '' || i.description == null)

    if (invalitList.length != 0) {
      this.errors.push("Toda actividad debe tener una descripción.")
    }

    invalitList = this.activityList.filter(i => i.activityType.id == -1)

    if (invalitList.length != 0) {
      this.errors.push("Toda actividad debe tener un tipo.")
    }

    invalitList = this.activityList.filter(i => i.companyService.id == -1)

    if (invalitList.length != 0) {
      this.errors.push("Toda actividad debe tener un Proyecto / Servicio asociado.")
    }

    if (!this.IsSumByDayValid()) {
      this.errors.push("Las horas por dia no deben superar las 8 hrs.")
    }


    if (this.errors.length == 0) {
      isValid = true
    }

    return isValid
  }

  IsSumByDayValid() {

    let isValid = false

    // Crea un objeto para almacenar las sumas de horas por día
    let sumByDay: { [dayId: number]: number } = {};
    const overload: string[] = [];

      // Itera sobre la lista de días
    this.dayList.forEach(day => {
      // Filtra las actividades que corresponden al día actual
      let activitiesForDay = this.activityList.filter(activity =>
        activity.detail.some(detail => detail.dayName === day.id)
      );

      // Suma las horas de las actividades para el día actual
      let totalHoursForDay = activitiesForDay.reduce(
        (sum, activity) =>
          sum + (activity.detail?.find(detail => detail.dayName === day.id)?.hours ?? 0),
        0
      );

      // Almacena la suma en el objeto sumByDay
      // sumByDay[day.id] = totalHoursForDay;

      if (totalHoursForDay > 8) {
         overload.push(day.id)
      }
     
    });

    if (overload.length==0) {
       isValid=true
    }

    // console.log(overload)
   


    return isValid

  }

  IsInvalidHours(item: Activity, day: any) {

    let isInvalid = true

    isInvalid = this.getDayDetail(item, day.id).hours > 8

    return isInvalid

  }

}
