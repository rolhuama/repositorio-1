import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Month } from 'src/app/models/common/month.model';
import { Company } from 'src/app/models/admin/company.model';
import { AdminService } from 'src/app/services/admin.service';
import Swal from 'sweetalert2';
import { ReportService } from 'src/app/services/report.service';
import { DailyHoursInputRequest } from 'src/app/models/reports/daily-hours-input-request.model';
import { DailyHoursInputResponse } from 'src/app/models/reports/daily-hours-input-response.model';
import * as XLSX from 'xlsx';



import DataTable from 'datatables.net';
import 'datatables.net-bs5';


@Component({
  selector: 'app-daily-hours-input',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './daily-hours-input.component.html',
  styleUrls: ['./daily-hours-input.component.scss']
})
export class DailyHoursInputComponent implements OnInit {

  PageName: string = 'Imputación de Horas'
  EntityName: string = 'Reporte'
  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Reportes',
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


  currentYear: number = new Date().getFullYear()
  currentMonth: number = new Date().getMonth() + 1;
  companyList: Company[] = []
  monthList: Month[] = []
  reportResponse: DailyHoursInputResponse[] = []


  requestForm = new FormGroup({
    companyId: new FormControl(-1, [Validators.required, Validators.min(0)]),
    year: new FormControl(this.currentYear, [Validators.required, Validators.min(0)]),
    month: new FormControl(this.currentMonth, [Validators.required, Validators.min(0)]),

  })


  constructor(
    private adminService: AdminService,
    private reportService: ReportService
  ) {

  }

  ngOnInit(): void {

    this.loadList()

  }



  loadList() {
    this.monthList = HelperFunction.GetMonths()

    this.adminService.CompanyList().subscribe((response: Company[]) => {
      this.companyList = response
    });


  }


  OnSubmit() {


    if (!this.requestForm.valid) {
      let controlNames = Object.keys(this.requestForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.requestForm)

      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'Por favor, complete los datos.',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    let request: DailyHoursInputRequest = {
      companyId: this.requestForm.value.companyId!,
      year: this.requestForm.value.year!,
      month: this.requestForm.value.month!
    };


    this.reportService.DailyHoursInput(request).subscribe(result => {
      this.reportResponse = result.data

      this.loadTable()

    }

    )


  }

  loadTable() {

    let table = new DataTable('#myTable', {
      dom: "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
      // buttons: [
      //   {
      //     extend: 'excel',
      //     text: '<i class="bi bi-file-earmark-excel"></i>',
      //     titleAttr: 'Excel',
      //     title: 'Inputacion de Horas'
      //   }
      // ],
      destroy: true,
      lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
      processing: true,
      data: this.reportResponse,
      columns: [
        { "data": "periodId" },
        { "data": "maximumHours" },
        { "data": "legalName" },
        { "data": "commercialName" },
        { "data": "countryName" },
        { "data": "workAreaName" },
        { "data": "workAreaTeamName" },
        { "data": "activityTypeName" },
        { "data": "companyServiceName" },
        { "data": "ticketCode" },
        { "data": "fullLastName" },
        { "data": "fullFirstName" },
        { "data": "description" },
        { "data": "durationHours" },

      ],
      language: { url: "assets/js/Datatables/Spanish.json" }

    });
  }

  ExportToExcel() {

    if (this.reportResponse.length == 0) {
      Swal.fire({
        position: 'center',
        icon: 'warning',
        title: 'No hay datos para exportar!',
        showConfirmButton: false,
        timer: 3500
      })
      return
    }

    let dataList = this.reportResponse

    // Crear el libro de Excel
    const wb: XLSX.WorkBook = XLSX.utils.book_new();

    // Crear una nueva hoja de trabajo para almacenar los datos
    const ws: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet([
      [
        'Periodo',
        'Horas Tope',
        'Cliente Raz. Soc.',
        'Cliente Nom. Comercial',
        'País',
        'Área',
        'Equipo',
        'Tipo',
        'Servicio/Proyecto',
        'Ticket',
        'Apellidos',
        'Nombres',
        'Actividad',
        'Duración'
      ]
    ]);


    // Iterar sobre los registros agregar los datos a la hoja de trabajo
    dataList.forEach((row, rowIndex) => {
      const rowData = [
        row.periodId,
        row.maximumHours,
        row.legalName,
        row.commercialName,
        row.countryName,
        row.workAreaName,
        row.workAreaTeamName,
        row.activityTypeName,
        row.companyServiceName,
        row.ticketCode,
        row.fullLastName,
        row.fullFirstName,
        row.description,
        row.durationHours

      ];

      XLSX.utils.sheet_add_aoa(ws, [rowData], { origin: -1 });
    });



    // Agregar la hoja de trabajo al libro
    XLSX.utils.book_append_sheet(wb, ws, 'Hoja1');

    // Generar el nombre del archivo con la fecha actual
    const currentDate = new Date();
    const year = currentDate.getFullYear().toString().padStart(4, '0');
    const month = (currentDate.getMonth() + 1).toString().padStart(2, '0');
    const day = currentDate.getDate().toString().padStart(2, '0');
    const hours = currentDate.getHours().toString().padStart(2, '0');
    const minutes = currentDate.getMinutes().toString().padStart(2, '0');
    const seconds = currentDate.getSeconds().toString().padStart(2, '0');

    const fileName = `Inputacion_Horas_${year}${month}${day}_${hours}${minutes}${seconds}.xlsx`;

    // Generar el archivo Excel
    XLSX.writeFile(wb, fileName);

  }






}
