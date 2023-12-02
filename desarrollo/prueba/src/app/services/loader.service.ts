import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  isLoading$ = new Subject<boolean>()

  Show():void{
    this.isLoading$.next(true)
  }

  Hide():void{
    this.isLoading$.next(false)
  }
}
