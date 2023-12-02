import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyInformationResponse } from 'src/app/models/admin/company-information-response.model';

@Component({
  selector: 'app-overview-company',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './overview-company.component.html',
  styleUrls: ['./overview-company.component.scss']
})
export class OverviewCompanyComponent {
  @Input()
  Info:CompanyInformationResponse=new CompanyInformationResponse

}
