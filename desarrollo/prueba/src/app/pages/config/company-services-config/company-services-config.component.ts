import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbTypeaheadModule, NgbPaginationModule, NgbModalRef, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbComponent } from 'src/app/shared/breadcrumb/breadcrumb.component';
import { Company } from 'src/app/models/admin/company.model';
import { Country } from 'src/app/models/common/country.model';
import { HelperFunction } from 'src/app/shared/functions/helper-function';
import { startWith, map } from 'rxjs';
import { AdminService } from 'src/app/services/admin.service';
import { HelperService } from 'src/app/services/helper.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-services-config',
  standalone: true,
  imports: [CommonModule, BreadcrumbComponent, NgbTypeaheadModule, NgbPaginationModule, FormsModule, ReactiveFormsModule],
  templateUrl: './company-services-config.component.html',
  styleUrls: ['./company-services-config.component.scss']
})
export class CompanyServicesConfigComponent implements OnInit {
  PageName: string = 'Clientes'
  EntityName: string = 'Cliente'

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


  ListAll: Company[] = []
  List: Company[] = []
  page = 1;
  pageSize = 10;
  collectionSize = this.List.length;
  rowInitIndex: number = 0

  isRegisterForm: boolean = false
  RegisterFormTitle: string = 'Editar ' + this.EntityName

  helper = HelperFunction;
  private modalRef: NgbModalRef | undefined;

  companyForm = new FormGroup({
    id: new FormControl(0),
    legalName: new FormControl('', [Validators.required]),
    commercialName: new FormControl('', [Validators.required]),
    fiscalAddress: new FormControl('', [Validators.required]),
    taxIdentificationNumber: new FormControl('', [Validators.required]),
    economicSector: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required]),
    isActive: new FormControl(false)
  })

  countryList: Country[] = []

  constructor(
    private adminService: AdminService,
    private helperService: HelperService,
    config: NgbModalConfig,
    private route: Router,
  ){
        // customize default values of modals used by this component tree
        config.backdrop = 'static'
        config.keyboard = false
    
        this.refreshList()
    
        this.filter.valueChanges.pipe(
          startWith(''),
          map((text) => this.search(text))
        ).subscribe(filteredData => {
          this.List = filteredData;
          this.collectionSize = filteredData.length;
        })
  }

  ngOnInit(): void {

    this.helperService.Countries().subscribe(
      response => this.countryList = response
    )
  }

  refreshList() {

    this.adminService.CompanyList().subscribe((response: Company[]) => {
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

  search(text: string): Company[] {
    return this.ListAll.filter((item) => {
      const term = text.toLowerCase();
      return (
        item.legalName.toLowerCase().includes(term) ||
        item.commercialName.toLowerCase().includes(term) ||
        item.taxIdentificationNumber.toLowerCase().includes(term) 
        // pipe.transform(user.email).includes(term) ||
        // pipe.transform(user.roleName).includes(term)
      );
    });
  }

  openEdit(item: Company) {

    this.route.navigate([`/config/company-config/${item.id}`])
 
  }



  closeModal() {
    if (this.modalRef) {
      this.modalRef.close();
    }
  }

}
