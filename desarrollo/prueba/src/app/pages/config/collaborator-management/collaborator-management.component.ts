import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { Company } from 'src/app/models/admin/company.model';
import { AdminService } from 'src/app/services/admin.service';
import { HelperService } from 'src/app/services/helper.service';
import { CollaboratorListResponse } from 'src/app/models/admin/collaborator-list-response.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-collaborator-management',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, FormsModule, ReactiveFormsModule, NgbTypeaheadModule, NgbPaginationModule, NgSelectModule],
  templateUrl: './collaborator-management.component.html',
  styleUrls: ['./collaborator-management.component.scss']
})
export class CollaboratorManagementComponent implements OnInit {

  PageName: string = 'Gestion de Colaboradores'
  EntityName: string = 'Colaborador'
  Pages: any[] = [
    {
      name: 'Inicio',
      link: '/welcome',
      active: false
    },
    {
      name: 'Configuración',
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

  List: any[] = []
  ListAll: any[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  dropdownList: any[] = []
  selectedItems: any[] = []

  constructor(
    private adminService: AdminService,
    private helperService: HelperService,
    private route: Router
  ){

    this.refreshList()

  }


  ngOnInit() {

    this.dropdownList = [
      { item_id: 1, item_text: 'Estudios' },
      { item_id: 2, item_text: 'Universidad' },
      { item_id: 3, item_text: 'Certificaciones' },
      { item_id: 4, item_text: 'Habilidades Blandas' },
      { item_id: 5, item_text: 'Idiomas' }
    ];


  }


  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


  refreshList(): void {
    this.adminService.CollaboratorList().subscribe((response: CollaboratorListResponse[]) => {
      this.List = response;
      this.ListAll = response;
      this.collectionSize = response.length;

      this.List = this.ListAll.map((item, i) => ({ index: i + 1, ...item })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize,
      );

      this.rowInitIndex = (this.page - 1) * this.pageSize + 1;

    });

  }

  search(): void {
    console.log(this.selectedItems)

  }

  openEdit(item: CollaboratorListResponse) {

    this.route.navigate([`/config/collaborator-config/${item.personUid}`])

  }

}
