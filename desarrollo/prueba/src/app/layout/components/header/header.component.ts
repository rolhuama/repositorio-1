import { ChangeDetectionStrategy, Component, OnInit, Renderer2 } from '@angular/core';
import { CommonModule } from '@angular/common';
import { environment } from 'src/environments/environment';
import { RouterLink } from '@angular/router';
import { UserResponse } from 'src/app/models/auth/user-response.model';
import { UserService } from 'src/app/services/user.service';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink, NgbDropdownModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit {
  appName = environment.app.name

  User: UserResponse = new UserResponse()

  constructor(
    private renderer: Renderer2,
    private userService: UserService
  ) {

    this.User = this.userService.getUser()
  }

  ngOnInit(): void {

    const toggleSidebarBtn = document.querySelector('.toggle-sidebar-btn');
    const body = document.querySelector('body');

    if (toggleSidebarBtn) {
      this.renderer.listen(toggleSidebarBtn, 'click', () => {
        body?.classList.toggle('toggle-sidebar');
      });
    }
    
  }



}
