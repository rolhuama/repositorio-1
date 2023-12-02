import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { MasterLayoutComponent } from 'src/app/layout/master-layout/master-layout.component';
import { ProfileComponent } from './profile.component';

const routes: Routes = [
  {
    path: '',  
    component: ProfileComponent,
    // children: [
    //   { path: '', component: ProfileComponent },
    //   { path: 'information/:personId', component: InformationComponent }
    // ]
  },
  { path: 'information/:personId', loadComponent: () => import('./information/information.component').then(mod => mod.InformationComponent) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
