import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterLink } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { UserResponse } from 'src/app/models/auth/user-response.model';
import { AccountService } from 'src/app/services/account.service';
import { MenuListResponse } from 'src/app/models/account/menu-list-response.model';
import { Menu } from 'src/app/models/account/menu.model';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, NgbDropdownModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SidebarComponent implements AfterViewInit{

  user: UserResponse = new UserResponse()
  menuList: MenuListResponse = new MenuListResponse()

  constructor(
    private cdr: ChangeDetectorRef,
    private userService: UserService,
    private accountService: AccountService
  ) {

    this.user = this.userService.getUser()

    if (this.user) {

      this.accountService.MenuList(this.user.id).subscribe(
        response => {
          this.menuList = response.data
          this.cdr.detectChanges()
        }
      )

    }

    // console.log("SIDEBAR")
    // console.log(this.User)


  }
  ngAfterViewInit(): void {
  //  this.cdr.detectChanges()
  }

  // Método para filtrar enlaces por grupo
  filterLinksByGroup(groupId: number): Menu[] {
    return this.menuList.links.filter(link => link.groupId === groupId);
  }


}
