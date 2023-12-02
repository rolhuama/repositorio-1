import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AccountListResponse } from '../models/helper/account-list-response.model';
import { Ubigeo } from '../models/common/ubigeo.model';
import { Country } from '../models/common/country.model';
import { MasterDetailTable } from '../models/common/master-detail-table.model';
import { Company } from '../models/admin/company.model';
import { CompanyService } from '../models/admin/company-service.model';
import { ServiceType } from '../models/common/service-type.model';
import { ActivityType } from '../models/common/activity-type.model';
import { PeriodWeekResponse } from '../models/activity/period-week-response.model';


@Injectable({
  providedIn: 'root'
})
export class HelperService {

  private apiUrl = environment.app.apiUrl;
  private header = new HttpHeaders().set('Content-Type', 'application/json')

  constructor(
    private http: HttpClient
  ) { }

  AccountLists(): Observable<AccountListResponse> {

    return this.http.get<AccountListResponse>(this.apiUrl + `Helper/AccountLists`, { headers: this.header, withCredentials: true });

  }

  Provinces(departmentCode: string): Observable<Ubigeo[]> {

    return this.http.get<Ubigeo[]>(this.apiUrl + `Helper/Provinces?DepartmentCode=` + departmentCode, { headers: this.header, withCredentials: true });

  }

  Districts(departmentCode: string, provinceCode: string): Observable<Ubigeo[]> {

    return this.http.get<Ubigeo[]>(this.apiUrl + `Helper/Districts?DepartmentCode=${departmentCode}&ProvinceCode=${provinceCode}`, { headers: this.header, withCredentials: true });

  }

  Countries() {

    return this.http.get<Country[]>(this.apiUrl + `Helper/Countries`, { headers: this.header, withCredentials: true });

  }

  MasterTableList(TableName: string, TableCode: string) {

    return this.http.get<MasterDetailTable[]>(this.apiUrl + `Helper/MasterTable/${TableName}/${TableCode}`, { headers: this.header, withCredentials: true });

  }

  CompanyList() {

    return this.http.get<Company[]>(this.apiUrl + `Helper/Company/List`, { headers: this.header, withCredentials: true });
  }

  ServicesTypesList() {

    return this.http.get<ServiceType[]>(this.apiUrl + `Helper/Services/Types/List`, { headers: this.header, withCredentials: true });
  }

  CompanyServicesList(CompanyId: number) {

    return this.http.get<CompanyService[]>(this.apiUrl + `Helper/Company/Services/List/${CompanyId}`, { headers: this.header, withCredentials: true });
  }

  CompanyActivityTypeList(CompanyId: number) {

    return this.http.get<ActivityType[]>(this.apiUrl + `Helper/Company/ActivityType/List/${CompanyId}`, { headers: this.header, withCredentials: true });
  }

  
  PeriodWeekList() {

    return this.http.get<PeriodWeekResponse[]>(this.apiUrl + `Helper/Period/Week/List`, { headers: this.header, withCredentials: true });
  }


}
