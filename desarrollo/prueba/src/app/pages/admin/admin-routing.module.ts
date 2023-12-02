import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { MasterLayoutComponent } from 'src/app/layout/master-layout/master-layout.component';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  {
    path: '',  
    component: AdminComponent,

  },
  { path: 'users', loadComponent: () => import('./users/users.component').then(mod => mod.UsersComponent) },
  { path: 'roles', loadComponent: () => import('./roles/roles.component').then(mod => mod.RolesComponent) },
  { path: 'companies', loadComponent: () => import('./companies/companies.component').then(mod => mod.CompaniesComponent) },
  { path: 'ceco', loadComponent: () => import('./ceco/ceco.component').then(mod => mod.CecoComponent) },
  { path: 'work-areas', loadComponent: () => import('./work-areas/work-areas.component').then(mod => mod.WorkAreasComponent) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
