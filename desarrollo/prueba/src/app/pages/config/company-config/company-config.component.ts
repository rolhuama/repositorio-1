import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { EditCompanyServicesComponent } from '../components/edit-company-services/edit-company-services.component';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { CompanyInformationResponse } from 'src/app/models/admin/company-information-response.model';
import { OverviewCompanyComponent } from '../components/overview-company/overview-company.component';
import { EditCompanyAreasComponent } from '../components/edit-company-areas/edit-company-areas.component';
import { EditCompanyContactsComponent } from '../components/edit-company-contacts/edit-company-contacts.component';

@Component({
  selector: 'app-company-config',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent,OverviewCompanyComponent, EditCompanyServicesComponent, EditCompanyAreasComponent,EditCompanyContactsComponent],
  templateUrl: './company-config.component.html',
  styleUrls: ['./company-config.component.scss']
})
export class CompanyConfigComponent {
  PageName: string = 'Configurar Cliente'
  EntityName: string = 'Cliente'

  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Configuración',
      link: '',
      active: false
    },
    {
      name: this.EntityName,
      link: '',
      active: true
    }
  ]

  private informationSubject = new BehaviorSubject<CompanyInformationResponse | null>(null);
  information$ = this.informationSubject.asObservable();


  constructor(
    private route: ActivatedRoute,
    private adminService:AdminService

  ) {
    // Obtener el valor de personId de la URL
    this.route.paramMap.subscribe((params) => {
      let id = params.get('companyId') ?? '';

      // Ahora puedes usar this.personId en tu componente
      this.GetInformation(id)

    });
  }

  GetInformation(id: string): void {
    this.adminService.CompanyInformation(id).subscribe(
      response => this.informationSubject.next(response.data)
    )

  }

}
