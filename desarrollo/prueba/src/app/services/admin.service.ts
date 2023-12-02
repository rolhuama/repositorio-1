import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserListResponse } from '../models/admin/user-list-response.model';
import { BaseResponse } from '../models/common/interface/base-response.model';
import { Role } from '../models/admin/role.model';
import { CreateUserRequest } from '../models/admin/create-user-request.model';
import { RegisterUserResponse } from '../models/admin/register-user-response.model';
import { Company } from '../models/admin/company.model';
import { CreateCompanyResponse } from '../models/admin/create-company-response.model';
import { CompanyRequest } from '../models/admin/company-request.model';
import { CompanyInformationResponse } from '../models/admin/company-information-response.model';
import { CompanyService } from '../models/admin/company-service.model';
import { CreateCompanyServiceResponse } from '../models/admin/create-company-service-response.model';
import { CostCenter } from '../models/admin/cost-center.model';
import { CreateCostCenterResponse } from '../models/admin/create-cost-center-response.model';
import { CollaboratorListResponse } from '../models/admin/collaborator-list-response.model';
import { CollaboratorCompanyListResponse } from '../models/admin/collaborator-company-list-response.model';
import { AddCollaboratorCompanyRequest } from '../models/admin/add-collaborator-company-request.model';
import { AddCollaboratorCompanyResponse } from '../models/admin/add-collaborator-company-response.model';
import { EditCollaboratorCompanyRequest } from '../models/admin/edit-collaborator-company-request.model';
import { WorkArea } from '../models/admin/work-area.model';
import { CreateWorkAreaResponse } from '../models/admin/create-work-area-response.model';
import { WorkAreaTeam } from '../models/admin/work-area-team.model';
import { CreateWorkAreaTeamResponse } from '../models/admin/create-work-area-team-response.model';
import { WorkInfo } from '../models/admin/work-info.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private apiUrl = environment.app.apiUrl;
  private header = new HttpHeaders().set('Content-Type', 'application/json')

  constructor(
    private http: HttpClient
  ) { }

  UserList(): Observable<BaseResponse<UserListResponse[]>> {



    return this.http.get<BaseResponse<UserListResponse[]>>(this.apiUrl + `Admin/UserList`, { headers: this.header, withCredentials: true });
  }

  RoleList(): Observable<Role[]> {


    return this.http.get<Role[]>(this.apiUrl + `Admin/RoleList`, { headers: this.header, withCredentials: true });
  }

  CreateUser(request: CreateUserRequest): Observable<BaseResponse<RegisterUserResponse>> {



    return this.http.post<BaseResponse<RegisterUserResponse>>(this.apiUrl + `Admin/CreateUser`, request, { headers: this.header, withCredentials: true });
  }

  EditUser(request: CreateUserRequest): Observable<BaseResponse<RegisterUserResponse>> {



    return this.http.patch<BaseResponse<RegisterUserResponse>>(this.apiUrl + `Admin/EditUser`, request, { headers: this.header, withCredentials: true });
  }

  CompanyList() {

    return this.http.get<Company[]>(this.apiUrl + `Admin/CompanyList`, { headers: this.header, withCredentials: true });
  }

  CreateCompany(request: CompanyRequest): Observable<BaseResponse<CreateCompanyResponse>> {

    return this.http.post<BaseResponse<CreateCompanyResponse>>(this.apiUrl + `Admin/CreateCompany`, request, { headers: this.header, withCredentials: true });
  }

  EditCompany(request: CompanyRequest): Observable<BaseResponse<CreateCompanyResponse>> {

    return this.http.post<BaseResponse<CreateCompanyResponse>>(this.apiUrl + `Admin/EditCompany`, request, { headers: this.header, withCredentials: true });
  }

  CompanyInformation(request: string) {

    return this.http.get<BaseResponse<CompanyInformationResponse>>(this.apiUrl + `Admin/Company/Information/${request}`, { headers: this.header, withCredentials: true });

  }

  CreateCompanyService(request: CompanyService) {

    return this.http.post<BaseResponse<CreateCompanyServiceResponse>>(this.apiUrl + `Admin/Company/Services/Create`, request, { headers: this.header, withCredentials: true });
  }

  EditCompanyService(request: CompanyService) {

    return this.http.post<BaseResponse<CreateCompanyServiceResponse>>(this.apiUrl + `Admin/Company/Services/Edit`, request, { headers: this.header, withCredentials: true });
  }

  CostCenterList() {

    return this.http.get<CostCenter[]>(this.apiUrl + `Admin/CostCenter/List`, { headers: this.header, withCredentials: true });
  }

  CreateCostCenter(request: CostCenter) {

    return this.http.post<BaseResponse<CreateCostCenterResponse>>(this.apiUrl + `Admin/CostCenter/Create`, request, { headers: this.header, withCredentials: true });
  }

  EditCostCenter(request: CostCenter) {

    return this.http.post<BaseResponse<CreateCostCenterResponse>>(this.apiUrl + `Admin/CostCenter/Edit`, request, { headers: this.header, withCredentials: true });
  }

  CollaboratorList() {

    return this.http.get<CollaboratorListResponse[]>(this.apiUrl + `Admin/Collaborator/List`, { headers: this.header, withCredentials: true });
  }

  CollaboratorCompanyList(CollaboratorId: number) {

    return this.http.get<CollaboratorCompanyListResponse[]>(this.apiUrl + `Admin/Collaborator/Company/List/${CollaboratorId}`, { headers: this.header, withCredentials: true });
  }

  AddCollaboratorCompany(request: AddCollaboratorCompanyRequest) {

    return this.http.post<BaseResponse<AddCollaboratorCompanyResponse>>(this.apiUrl + `Admin/Collaborator/Company/Add`, request, { headers: this.header, withCredentials: true });
  }

  EditCollaboratorCompany(request: EditCollaboratorCompanyRequest) {

    return this.http.post<BaseResponse<AddCollaboratorCompanyResponse>>(this.apiUrl + `Admin/Collaborator/Company/Edit`, request, { headers: this.header, withCredentials: true });
  }

  DeleteCollaboratorCompany(request: AddCollaboratorCompanyRequest) {

    return this.http.post<BaseResponse<AddCollaboratorCompanyResponse>>(this.apiUrl + `Admin/Collaborator/Company/Delete`, request, { headers: this.header, withCredentials: true });

  }

  WorkAreaList() {

    return this.http.get<WorkArea[]>(this.apiUrl + `Admin/Work-Area/List`, { headers: this.header, withCredentials: true });
  }

  CreateWorkArea(request: WorkArea) {

    return this.http.post<BaseResponse<CreateWorkAreaResponse>>(this.apiUrl + `Admin/Work-Area/Create`, request, { headers: this.header, withCredentials: true });
  }

  EditWorkArea(request: WorkArea) {

    return this.http.post<BaseResponse<CreateWorkAreaResponse>>(this.apiUrl + `Admin/Work-Area/Edit`, request, { headers: this.header, withCredentials: true });
  }

  WorkAreaTeamList() {

    return this.http.get<WorkAreaTeam[]>(this.apiUrl + `Admin/Work-Area-Team/List`, { headers: this.header, withCredentials: true });
  }

  CreateWorkAreaTeam(request: WorkAreaTeam) {

    return this.http.post<BaseResponse<CreateWorkAreaTeamResponse>>(this.apiUrl + `Admin/Work-Area-Team/Create`, request, { headers: this.header, withCredentials: true });
  }

  DeleteWorkAreaTeam(request: WorkAreaTeam) {

    return this.http.post<BaseResponse<CreateWorkAreaTeamResponse>>(this.apiUrl + `Admin/Work-Area-Team/Delete`, request, { headers: this.header, withCredentials: true });
  }

  WorkInfo(CollaboratorId: number) {

    return this.http.get<BaseResponse<WorkInfo>>(this.apiUrl + `Admin/Work-info/${CollaboratorId}`, { headers: this.header, withCredentials: true });

  }

  EditWorkInfo(request: WorkInfo) {

    return this.http.patch<BaseResponse<WorkInfo>>(this.apiUrl + `Admin/Work-Info/Edit`, request, { headers: this.header, withCredentials: true });
  }



}
