import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { InformationResponse } from 'src/app/models/account/information-response.model';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { OverviewProfileComponent } from '../components/overview-profile/overview-profile.component';
import { EditProfileComponent } from '../components/edit-profile/edit-profile.component';
import { ChangePasswordProfileComponent } from '../components/change-password-profile/change-password-profile.component';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-information',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, OverviewProfileComponent, EditProfileComponent, ChangePasswordProfileComponent],
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.scss']
})
export class InformationComponent {
  PageName: string = 'Información'
  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Perfil',
      link: '',
      active: false
    },
    {
      name: this.PageName,
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
