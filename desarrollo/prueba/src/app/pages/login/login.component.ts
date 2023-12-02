import { AfterViewInit, Component, NgZone } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { GoogleResponse } from 'src/app/models/auth/google-response.model';
import { UserRequest } from 'src/app/models/auth/user-request.model';
import { UserResponse } from 'src/app/models/auth/user-response.model';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2'

declare let google: any

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements AfterViewInit {

  appName: string = environment.app.name

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    rememberMe: new FormControl(false, []),
  })

  helper = HelperFunction;

  constructor(
    private authService: AuthService,
    private route: Router,
    private userService: UserService,
    private ngZone: NgZone
  ) {

    this.userService.clearAll()
  }



  ngAfterViewInit(): void {


    google.accounts.id.initialize({
      client_id: environment.googleConfig.client_id,
      callback: this.handleCredentialResponse.bind(this)
    })

    google.accounts.id.renderButton(
      document.getElementById("btn-google"),
      { theme: "outline", size: "large", width: "368" }  // customization attributes
    )

    google.accounts.id.prompt();



  }

  handleCredentialResponse(response: any) {

    let request: GoogleResponse = new GoogleResponse()

    request.clientId = response.clientId
    request.credential = response.credential

    try {

      const observer: Observer<UserResponse> = {
        next: (response) => {
          this.redirectUser(response);
        },
        error: (error) => {
          console.error(error);
          Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Error ingresando sus credenciales. Por favor, intente nuevamente.',
            showConfirmButton: false,
            timer: 3500
          });
        },
        complete: () => {
          // Opcionalmente, puedes manejar la finalización aquí
        }
      };

      this.authService.loginGoogle(request).subscribe(observer)


    } catch (error) {

      Swal.fire({
        title: 'Error!',
        text: 'Do you want to continue',
        icon: 'error',
        confirmButtonText: 'Cool'
      })
    }


  }

  redirectUser(user: UserResponse) {

    this.userService.setUser(user)

    this.ngZone.run(() => {

      if (user.isRegistered) {
        this.route.navigate(['/welcome'])
      } else {
        this.route.navigate(['/signup'])
      }

    });


  }

  async onSubmit() {

    try {

      let controlNames = Object.keys(this.loginForm.controls);
      HelperFunction.validateFirstGroup(controlNames, this.loginForm)

      if (!this.loginForm.valid) {
        Swal.fire({
          position: 'center',
          icon: 'warning',
          title: 'Por favor complete los datos!',
          showConfirmButton: false,
          timer: 3500
        })

        return
      }

      const observer: Observer<UserResponse> = {
        next: (response) => {
          this.redirectUser(response);
        },
        error: (error) => {
          console.error(error);
          Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Error ingresando sus credenciales. Por favor, intente nuevamente.',
            showConfirmButton: false,
            timer: 3500
          });
        },
        complete: () => {
          // Opcionalmente, puedes manejar la finalización aquí
        }
      };

      let user: UserRequest = {
        userName: this.loginForm.controls.username.value ?? '',
        password: this.loginForm.controls.password.value ?? ''
      }

      this.authService.login(user).subscribe(observer)

    } catch (error) {
      Swal.fire({
        position: 'center',
        icon: 'error',
        title: 'Ocurrio un error intentelo nuevamente!',
        showConfirmButton: false,
        timer: 3500
      })
    }

  }

}
