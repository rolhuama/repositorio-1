import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, from, switchMap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  private apiUrl = environment.app.apiUrl;
  private activeRefreshRequests: number = 0
  private renewMin: number = 5 //Minutos para renovar Token

  constructor(private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const authToken = localStorage.getItem('tokenExpires');

    if (authToken) {

      let expires = JSON.parse(authToken);
      const dateExpires = new Date(expires);
      const currentDate = new Date();
      const oneMinuteAgo = new Date(currentDate.getTime() + (this.renewMin * 60 * 1000)); //Si caduca en 1 minuto o menos lo renueva

      if (dateExpires <= oneMinuteAgo && this.activeRefreshRequests == 0) {
        this.activeRefreshRequests++

        return this.handleRequestWithoutToken(request, next);
      }
      else {

        return this.handleRequestWithToken(request, next, '');
      }
    }
    else {

      return this.handleRequestWithToken(request, next, '');
    }

  }

  private handleRequestWithToken(request: HttpRequest<any>, next: HttpHandler, authToken: string): Observable<HttpEvent<any>> {
    const clonedRequest = request.clone({
      setHeaders: { Authorization: `Bearer ${authToken}` }
    });

    return next.handle(clonedRequest).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          // Error 401: No autorizado
          // Redireccionar a la página de inicio de sesión
          this.router.navigate(['/login/out'])
          // window.location.reload();
        }
        // Puedes manejar otros tipos de errores aquí si es necesario
  
        // Reenviar el error para que se propague
        return throwError(error);
      })
    )
  }

  private handleRequestWithoutToken(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Realiza la solicitud para obtener el token nuevamente
    return from(this.fetchNewToken()).pipe(
      switchMap((newToken: any) => {
        // Almacena el nuevo token en el Session Storage
        // sessionStorage.setItem('authToken', newToken);
        // Continúa la solicitud original con el nuevo token
        return this.handleRequestWithToken(request, next, newToken);
      })
    );
  }

  private async fetchNewToken(): Promise<string> {
    // Realiza la solicitud al servidor para obtener el nuevo token
    // Puedes usar HttpClient para hacer la solicitud al endpoint de autenticación
    try {

      this.activeRefreshRequests = 0

      const response = await fetch(this.apiUrl + `auth/RefreshToken`, {
        method: 'GET',
        credentials: 'include' // Establecer credentials en 'include'
      });

      if (response.status === 401) {
        // Capturar el error 401 aquí y manejarlo según tus necesidades
        // console.log('Error 401: No Autorizado');
        // Puedes lanzar una excepción personalizada, redirigir a una página de inicio de sesión, etc.
        throw new Error('Error 401: No Autorizado');
      }

      if (response.ok) {
        const data = await response.json();
        localStorage.setItem('tokenExpires', JSON.stringify(data.tokenExpires));
      }
      else {
        throw new Error(`Error RefreshToken: ${response.status}`);
      }


    } catch (error) {

      // localStorage.clear()
      this.router.navigate(['/login/out']);
      // window.location.reload();

    }


    return ''; // Asume que el servidor devuelve el token en una propiedad "token"
  }
}
