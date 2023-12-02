import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivitiesComponent } from './activities.component';

const routes: Routes = [
  {
    path: '',  
    component: ActivitiesComponent,
  },
  { path: 'daily', loadComponent: () => import('./daily-entry/daily-entry.component').then(mod => mod.DailyEntryComponent) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActivitiesRoutingModule { }
