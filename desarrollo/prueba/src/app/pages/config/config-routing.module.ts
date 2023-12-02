import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigComponent } from './config.component';
import { CollaboratorManagementComponent } from './collaborator-management/collaborator-management.component';
import { CompanyServicesConfigComponent } from './company-services-config/company-services-config.component';

const routes: Routes = [
  {
    path: '',  
    component: ConfigComponent,

  },
  { path: 'collaborator-managment', component: CollaboratorManagementComponent },
  { path: 'company-config', component: CompanyServicesConfigComponent },
  { path: 'company-config/:companyId', loadComponent: () => import('./company-config/company-config.component').then(mod => mod.CompanyConfigComponent) },
  { path: 'collaborator-config/:personId', loadComponent: () => import('./collaborator-config/collaborator-config.component').then(mod => mod.CollaboratorConfigComponent) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigRoutingModule { }
