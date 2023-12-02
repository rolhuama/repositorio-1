import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BaseResponse } from '../models/common/interface/base-response.model';
import { DailyHoursInputRequest } from '../models/reports/daily-hours-input-request.model';
import { DailyHoursInputResponse } from '../models/reports/daily-hours-input-response.model';
import { DailyActivityListResponse } from '../models/activity/daily-activity-list-response.model';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private apiUrl = environment.app.apiUrl;
  private header = new HttpHeaders().set('Content-Type', 'application/json')

  constructor(
    private http: HttpClient
  ) { }


  DailyHoursInput(request: DailyHoursInputRequest) {
   

    return this.http.post<BaseResponse<DailyHoursInputResponse[]>>(this.apiUrl + `Report/Company/Collaborator/daily-hours-input`, request,{headers: this.header, withCredentials:true });

  }

}
