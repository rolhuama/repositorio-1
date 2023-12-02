import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, finalize } from 'rxjs';
import { LoaderService } from '../loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {

  private activeRequests: number =0

  constructor(
    private readonly loaderSvc:LoaderService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (this.activeRequests===0) {
      this.loaderSvc.Show()
   }

  this.activeRequests++

   return next.handle(request).pipe(finalize(()=>  this.stopLoader()));
  }

  private stopLoader(){
    this.activeRequests--
    
    if (this.activeRequests===0) {
      this.loaderSvc.Hide()
   }
  

  }
}
