import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WelcomeRoutingModule } from './welcome-routing.module';
import { WelcomeComponent } from './welcome.component';
// import { MasterLayoutModule } from 'src/app/layout/master-layout/master-layout.module';


@NgModule({
  declarations: [
    WelcomeComponent
  ],
  imports: [
    CommonModule,
    WelcomeRoutingModule,
    // MasterLayoutModule
  ]
})
export class WelcomeModule { }
