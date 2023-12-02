import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { EditProfileComponent } from '../../profile/components/edit-profile/edit-profile.component';
import { OverviewProfileComponent } from '../../profile/components/overview-profile/overview-profile.component';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { InformationResponse } from 'src/app/models/account/information-response.model';
import { AccountService } from 'src/app/services/account.service';
import { EditCollaboratorCompanyComponent } from '../components/edit-collaborator-company/edit-collaborator-company.component';
import { EditCollaboratorWorkInfoComponent } from '../components/edit-collaborator-work-info/edit-collaborator-work-info.component';

@Component({
  selector: 'app-collaborator-config',
  standalone: true,
  imports: [CommonModule,BreadcrumbComponent, OverviewProfileComponent, EditProfileComponent,EditCollaboratorCompanyComponent,EditCollaboratorWorkInfoComponent],
  templateUrl: './collaborator-config.component.html',
  styleUrls: ['./collaborator-config.component.scss']
})
export class CollaboratorConfigComponent {
  PageName: string = 'Configura Perfil'
  EntityName: string = 'Colaborador'
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

  private informationSubject = new BehaviorSubject<InformationResponse | null>(null);
  information$ = this.informationSubject.asObservable();

  constructor(
    private route: ActivatedRoute,
    private accountService: AccountService
  ) {
    // Obtener el valor de personId de la URL
    this.route.paramMap.subscribe((params) => {
      let personId = params.get('personId') ?? '';

      // Ahora puedes usar this.personId en tu componente
      this.GetInformation(personId)

    });
  }


  GetInformation(personId: string): void {
  this.accountService.Information(personId).subscribe(
      response => this.informationSubject.next(response.data)
    )

  }

}
