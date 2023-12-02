import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RegisterRequest } from '../models/account/register-request.model';
import { Observable } from 'rxjs';
import { BaseResponse } from '../models/common/interface/base-response.model';
import { RegisterResponse } from '../models/account/register-response.model';
import { InformationResponse } from '../models/account/information-response.model';
import { MenuListResponse } from '../models/account/menu-list-response.model';
import { CollaboratorCompanyListResponse } from '../models/admin/collaborator-company-list-response.model';
import { DailyActivityRequest } from '../models/activity/daily-activity-request.model';
import { Activity } from '../models/activity/activity.model';
import { DailyActivityListRequest } from '../models/activity/daily-activity-list-request.model';
import { DailyActivityListResponse } from '../models/activity/daily-activity-list-response.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiUrl = environment.app.apiUrl;
  header = new HttpHeaders().set('Content-Type', 'application/json')

  constructor(
    private http: HttpClient
  ) { }

  Register(request: RegisterRequest): Observable<BaseResponse<RegisterResponse>> {
   

    return this.http.post<BaseResponse<RegisterResponse>>(this.apiUrl + `Account/Register`, request,{headers: this.header, withCredentials:true });

  }

  Information(request: string) {   

    return this.http.get<BaseResponse<InformationResponse>>(this.apiUrl + `Account/Information/${request}`,{headers: this.header, withCredentials:true });

  }

  MenuList(userId: string) {   

    return this.http.get<BaseResponse<MenuListResponse>>(this.apiUrl + `Account/MenuList/${userId}`,{headers: this.header, withCredentials:true });

  }

  
  CollaboratorCompanyList(personId:string) {

    return this.http.get<CollaboratorCompanyListResponse[]>(this.apiUrl + `Account/Company/List/${personId}`,{headers: this.header, withCredentials:true });
  }

  RegisterDailyActivity(request: DailyActivityRequest) {
   

    return this.http.post<BaseResponse<Activity[]>>(this.apiUrl + `Account/Company/Daily-Activity/Register`, request,{headers: this.header, withCredentials:true });

  }

  DailyActivityList(request: DailyActivityListRequest) {
   

    return this.http.post<BaseResponse<DailyActivityListResponse>>(this.apiUrl + `Account/Company/Daily-Activity/List`, request,{headers: this.header, withCredentials:true });

  }

}
