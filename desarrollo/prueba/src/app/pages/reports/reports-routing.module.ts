import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportsComponent } from './reports.component';

const routes: Routes = [
  {
    path: '',  
    component: ReportsComponent
  },
  { path: 'collaborator/daily-hours-input', loadComponent: () => import('./collaborator/daily-hours-input/daily-hours-input.component').then(mod => mod.DailyHoursInputComponent) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportsRoutingModule { }
