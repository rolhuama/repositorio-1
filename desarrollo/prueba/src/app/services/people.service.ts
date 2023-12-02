import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Holiday } from '../models/activity/holiday.model';
import { CreateHolidayResponse } from '../models/activity/create-holiday-response.model';
import { BaseResponse } from '../models/common/interface/base-response.model';
import { Period } from '../models/activity/period.model';
import { CreatePeriodResponse } from '../models/activity/create-period-response.model';
import { CreateActivityTypeResponse } from '../models/common/create-activity-type-response.model';
import { ActivityType } from '../models/common/activity-type.model';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  private apiUrl = environment.app.apiUrl;
  private header = new HttpHeaders().set('Content-Type', 'application/json')

  constructor(
    private http: HttpClient
  ) { }

  HolidayList() {

    return this.http.get<Holiday[]>(this.apiUrl + `People/Holiday/List`,{headers: this.header, withCredentials:true });
  }

  CreateHoliday(request:Holiday) {

    return this.http.post<BaseResponse<CreateHolidayResponse>>(this.apiUrl + `People/Holiday/Create`,request,{headers: this.header, withCredentials:true });
  }

  EditHoliday(request:Holiday){

    return this.http.post<BaseResponse<CreateHolidayResponse>>(this.apiUrl + `People/Holiday/Edit`,request,{headers: this.header, withCredentials:true });
  }

  PeriodList() {

    return this.http.get<Period[]>(this.apiUrl + `People/Period/List`,{headers: this.header, withCredentials:true });
  }

  CreatePeriod(request:Period) {

    return this.http.post<BaseResponse<CreatePeriodResponse>>(this.apiUrl + `People/Period/Create`,request,{headers: this.header, withCredentials:true });
  }

  EditPeriod(request:Period){

    return this.http.post<BaseResponse<CreatePeriodResponse>>(this.apiUrl + `People/Period/Edit`,request,{headers: this.header, withCredentials:true });
  }

  ActivityTypeList() {

    return this.http.get<ActivityType[]>(this.apiUrl + `People/ActivityType/List`,{headers: this.header, withCredentials:true });
  }

  CreateActivityType(request:ActivityType) {

    return this.http.post<BaseResponse<CreateActivityTypeResponse>>(this.apiUrl + `People/ActivityType/Create`,request,{headers: this.header, withCredentials:true });
  }

  EditActivityType(request:ActivityType){

    return this.http.post<BaseResponse<CreateActivityTypeResponse>>(this.apiUrl + `People/ActivityType/Edit`,request,{headers: this.header, withCredentials:true });
  }


}
