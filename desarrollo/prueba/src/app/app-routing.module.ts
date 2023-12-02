import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MasterLayoutComponent } from './layout/master-layout/master-layout.component';
import { authGuard } from './services/guards/auth.guard';

const routes: Routes = [
  {
    path: '', redirectTo:'login' , pathMatch: 'full'
   
  },
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'signup',
    canActivate:[authGuard],
    loadChildren: () => import('./pages/signup/signup.module').then(m => m.SignupModule)
  },
  {
    path: 'welcome',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule)
  },
  {
    path: 'activities',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/activities/activities.module').then(m => m.ActivitiesModule)
  },
  {
    path: 'people',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/people/people.module').then(m => m.PeopleModule)
  },
  {
    path: 'reports',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/reports/reports.module').then(m => m.ReportsModule)
  },
  {
    path: 'profile',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/profile/profile.module').then(m => m.ProfileModule)
  },
  {
    path: 'config',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/config/config.module').then(m => m.ConfigModule)
  },
  {
    path: 'admin',
    canActivate:[authGuard],
    component:MasterLayoutComponent,
    loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: '**',
    redirectTo: 'login'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
