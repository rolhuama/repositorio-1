import { CompanyService } from "./company-service.model";

export class Company {

    id!: number;
    legalName!: string;
    commercialName!: string;
    fiscalAddress!: string;
    taxIdentificationNumber!: string;
    economicSector!: string | null;
    country!: string;
    // costCenter: CostCenter | null;
    isInterCompany!: boolean;
    isActive!: boolean;
    // areas!: CompanyArea[];
    services!: CompanyService[];
    // contacts!: ContactService[];

}
