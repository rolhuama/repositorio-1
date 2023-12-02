import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InformationResponse } from 'src/app/models/account/information-response.model';

@Component({
  selector: 'app-overview-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './overview-profile.component.html',
  styleUrls: ['./overview-profile.component.scss']
})
export class OverviewProfileComponent {
  @Input()
  Info:InformationResponse=new InformationResponse

}
