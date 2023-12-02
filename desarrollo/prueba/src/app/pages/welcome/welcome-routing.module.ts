import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MasterLayoutComponent } from 'src/app/layout/master-layout/master-layout.component';
import { WelcomeComponent } from './welcome.component';

const routes: Routes = [
  {
    path:'',
    component: WelcomeComponent,
    // children: [
    //   // Definir rutas hijas si es necesario
    //   { path: '', component: WelcomeComponent },
    // ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WelcomeRoutingModule { }
