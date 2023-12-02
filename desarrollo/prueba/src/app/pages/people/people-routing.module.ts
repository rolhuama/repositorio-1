import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PeopleComponent } from './people.component';

const routes: Routes = [
  {
    path: '',  
    component: PeopleComponent
  },
  { path: 'holidays-config', loadComponent: () => import('./holidays-config/holidays-config.component').then(mod => mod.HolidaysConfigComponent) },
  { path: 'periods-config', loadComponent: () => import('./periods-config/periods-config.component').then(mod => mod.PeriodsConfigComponent) },
  { path: 'activity-type-config', loadComponent: () => import('./activity-type-config/activity-type-config.component').then(mod => mod.ActivityTypeConfigComponent) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PeopleRoutingModule { }
