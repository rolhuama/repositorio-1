import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-step-indicator',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './step-indicator.component.html',
  styleUrls: ['./step-indicator.component.scss']
})
export class StepIndicatorComponent implements OnInit{


  @Input()
  Steps!: number;
  @Input()
  ActualStep!: number;

  StepsList:number[]=[];

  constructor(){}


  ngOnInit(): void {
    
    if (!this.Steps) {
      this.Steps=1
    }

    for (let index = 1; index <= this.Steps; index++) {
      this.StepsList.push(index)      
    }
  }

}
