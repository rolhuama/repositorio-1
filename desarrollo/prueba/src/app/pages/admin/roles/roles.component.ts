import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { Role } from 'src/app/models/admin/role.model';
import { AdminService } from 'src/app/services/admin.service';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { map, startWith } from 'rxjs';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent {
  PageName: string = 'Configurar Roles'

  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Admistracion',
      link: '',
      active: false
    },
    {
      name: this.PageName,
      link: '',
      active: true
    }
  ]

  filter = new FormControl('', { nonNullable: true })


  RoleListAll: Role[] = []
  RoleList: Role[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.RoleList.length;
  rowInitIndex: number = 0

  constructor(
    private adminService: AdminService
  ) {
    this.refreshList()

    this.filter.valueChanges.pipe(
      startWith(''),
      map((text) => this.search(text))
    ).subscribe(filteredData => {
      this.RoleList = filteredData;
      this.collectionSize = filteredData.length;
    })
  }

  refreshList() {

    this.adminService.RoleList().subscribe((response: Role[]) => {
      this.RoleList = response;
      this.RoleListAll = response;
      this.collectionSize = response.length;

      this.RoleList = this.RoleListAll.map((item, i) => ({ index: i + 1, ...item })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize,
      );

      this.rowInitIndex = (this.page - 1) * this.pageSize + 1;

    });
  }

  search(text: string): Role[] {
    return this.RoleListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.name.toLowerCase().includes(term)
        // pipe.transform(user.email).includes(term) ||
        // pipe.transform(user.roleName).includes(term)
      );
    });
  }

}
