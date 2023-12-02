import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignupRoutingModule } from './signup-routing.module';
import { SignupComponent } from './signup.component';
import { StepIndicatorComponent } from "../../shared/step-indicator/step-indicator.component";
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
    declarations: [
        SignupComponent
    ],
    imports: [
        CommonModule,
        SignupRoutingModule,
        StepIndicatorComponent,
        NgbNavModule,
        ReactiveFormsModule
    ]
})
export class SignupModule { }
